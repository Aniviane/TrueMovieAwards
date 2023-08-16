import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { DownProducingMovie } from 'src/app/Models/DownProducingMovie';
import { DownRole } from 'src/app/Models/DownRole';
import { Festival } from 'src/app/Models/Festival';
import { Holding } from 'src/app/Models/Holding';
import { Movie } from 'src/app/Models/Movie';
import { MovieAward } from 'src/app/Models/MovieAward';
import { ProducerAward } from 'src/app/Models/ProducerAward';
import { RoleAward } from 'src/app/Models/RoleAward';
import { AwardService } from 'src/app/Services/award.service';
import { FestivalService } from 'src/app/Services/festival.service';
import { HoldingService } from 'src/app/Services/holding.service';
import { MovieService } from 'src/app/Services/movie.service';

@Component({
  selector: 'app-festival',
  templateUrl: './festival.component.html',
  styleUrls: ['./festival.component.css']
})
export class FestivalComponent implements OnInit {

  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  singleDataFlag : boolean = false
  singleFestival : Festival = new Festival

  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }


  constructor(private movieService:MovieService, private awardService: AwardService, private router:Router,private holdingService:HoldingService, private festivalService : FestivalService, private dom:DomSanitizer, private route: ActivatedRoute) { }
  Festivals : Festival[] = []
  ngOnInit(): void {
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
        
        this.festivalService.getFestival(id).subscribe(elem =>{
          this.singleFestival = elem
          console.log("single festival:" + this.singleFestival)
          this.singleDataFlag = true
        })

      } else {
        this.singleDataFlag = false
        this.festivalService.getFestivals().subscribe(elem => {
          this.Festivals = elem;
          
          console.log(this.Festivals)
        })
      }
    })

  
  }

  makeMyUrlSafe(url : string): SafeUrl {
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }


  festivalForm = new FormGroup({
    name : new FormControl("", Validators.required),
    description: new FormControl("", Validators.required),
    photo : new FormControl(""),
  })

  addFestival() {
    let festival = new Festival()
    festival.name = this.festivalForm.get("name")?.value ?? ""
    festival.description = this.festivalForm.get("description")?.value ?? ""
    festival.photo = ""

    this.festivalService.addFestival(festival).subscribe(elem => console.log(elem))

  }


  festivalId : number = 0


  holdingForm = new FormGroup({
    name : new FormControl("", Validators.required),
    city: new FormControl("", Validators.required),
    year : new FormControl(2023, Validators.compose([Validators.min(1900), Validators.max(2023)])),
  })


  setFestivalId(id : number) {
    this.festivalId = id
    console.log("Festival id set to : " + this.festivalId)
  }


  addHolding() {
    let holding = new Holding()
    if(this.festivalId == 0) return
    holding.festivalId =this.festivalId

    holding.name = this.holdingForm.get("name")?.value ?? ""
    holding.city = this.holdingForm.get("city")?.value ?? ""
    holding.year = +(this.holdingForm.get("year")?.value ?? 0)

    this.holdingService.addHolding(holding).subscribe(elem => console.log(elem))
   
    this.festivalId = 0
    
    this.singleFestival.holdings.push(holding)
   }




   awardType = "Movie Award"
   Roles: DownRole[] = []
   Producings: DownProducingMovie[] = []
   Movies : Movie[] = []
   roleId : number = 0
   producingId : number = 0
   holdingId : number = 0
   movieId : number = 0

   setHoldingId(num : number) {
    this.movieService.getRoles().subscribe(elem => this.Roles = elem)
    this.movieService.getProducings().subscribe(elem => this.Producings = elem)
    this.movieService.getMovies().subscribe(elem => this.Movies = elem)
    this.holdingId = num
    console.log("Holding id set :" + this.holdingId)
    
   }

   movieForm = new FormGroup({
    awardName : new FormControl("", Validators.required),
    movieId : new FormControl(-1, Validators.required)
   })

   roleForm = new FormGroup({
    awardName : new FormControl("", Validators.required),
    roleId : new FormControl(-1, Validators.required)
   })

   producingForm = new FormGroup({
    awardName : new FormControl("", Validators.required),
    producingIndex : new FormControl(-1, Validators.required)
   })

   addProducingAward() {
      let award = new ProducerAward()
      console.log(this.producingForm.get("producingIndex"))
      
      award.awardType = "Producer"
      award.holdingId = this.holdingId
      award.name = this.producingForm.get("awardName")?.value ?? ""
      let id = this.producingForm.get("producingIndex")?.value ?? -1
    if(id == -1 || award.name == "" || this.holdingId == 0){
      console.log("Data not valid." + id + "- id," + award.name + "- award name" + this.holdingId + " - holding id")
      return
    }
      if(this.Producings.length <= id ) {
      console.log("bad value")
      return
      }
      award.producings.push(this.Producings[id])
      this.awardService.addProducerAward(award).subscribe(elem => { 
        console.log(elem)
        this.singleFestival.holdings[this.holdingId].producerAwards.push(award)
      })
      

    

   }

   addMovieAward() {
    let award = new MovieAward()
    console.log(this.movieForm.get("movieId"))
    award.awardType = "Movie"
    award.holdingId = this.holdingId
    award.name = this.movieForm.get("awardName")?.value ?? ""
    let id = this.movieForm.get("movieId")?.value ?? -1
  if(id == -1 || award.name == "" || this.holdingId == 0){
    console.log("Data not valid." + id + "- id," + award.name + "- award name" + this.holdingId + " - holding id")
    return
  }
    
  let help = this.Movies.find(elem => elem.id == id)
  if(!help) {
    console.log("No such movie. ID - " + id)
    return
  }

  award.movies.push(help)

  this.awardService.addMovieAward(award).subscribe(elem =>{ 
    console.log(elem)
    this.singleFestival.holdings[this.holdingId].movieAwards.push(award)
  })
 

  }

   addRoleAward() {
    let award = new RoleAward()
    console.log(this.roleForm.get("roleId"))
    award.awardType = "Role"
    award.holdingId = this.holdingId
    award.name = this.roleForm.get("awardName")?.value ?? ""
    let id = this.roleForm.get("roleId")?.value ?? -1
  if(id == -1 || award.name == "" || this.holdingId == 0){
    console.log("Data not valid." + id + "- id," + award.name + "- award name" + this.holdingId + " - holding id")
    return
  }
    
  let help = this.Roles.find(elem => elem.id == id)
  if(!help) {
    console.log("No such movie. ID - " + id)
    return
  }

  award.roles.push(help)
  this.awardService.addRoleAward(award).subscribe(elem =>{ 
    console.log(elem)
    this.singleFestival.holdings[this.holdingId].roleAwards.push(elem)
  })
  

   }
}
