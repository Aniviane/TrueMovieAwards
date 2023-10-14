import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { DownProducingMovie } from 'src/app/Models/DownProducingMovie';
import { DownRole } from 'src/app/Models/DownRole';
import { Festival } from 'src/app/Models/Festival';
import { FestivalCreate } from 'src/app/Models/FestivalCreate';
import { Holding } from 'src/app/Models/Holding';
import { Movie } from 'src/app/Models/Movie';
import { MovieAward } from 'src/app/Models/MovieAward';
import { PartialMovie } from 'src/app/Models/PartialMovie';
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
          this.searchData = elem;
          
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
    
  })

  festivalPhoto = null

  onChange(event : any) {
    this.festivalPhoto = event.target.files[0]
    console.log(this.festivalPhoto)
  }

  
  addFestival() {
    let festival = new FestivalCreate()
    festival.name = this.festivalForm.get("name")?.value ?? ""
    festival.description = this.festivalForm.get("description")?.value ?? ""
    if(this.festivalPhoto != null)
    festival.photo = this.festivalPhoto
    else return

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

    this.holdingService.addHolding(holding).subscribe(elem => this.singleFestival.holdings.push(elem))
   
    this.festivalId = 0
    
    
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
    movieId : new FormControl(-1, Validators.compose([Validators.required, Validators.min(0)]))
   })

   roleForm = new FormGroup({
    awardName : new FormControl("", Validators.required),
    roleId : new FormControl(-1, Validators.compose([Validators.required, Validators.min(0)]))
   })

   producingForm = new FormGroup({
    awardName : new FormControl("", Validators.required),
    producingIndex : new FormControl(-1, Validators.compose([Validators.required, Validators.min(0)]))
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
     

      if(this.producingRecipients.length == 0) {
        console.log("no producings selected")
        return
      }
      award.producings = this.producingRecipients

      this.awardService.addProducerAward(award).subscribe(elem => { 
        console.log(elem)
        this.singleFestival.holdings[this.holdingId].producerAwards.push(elem)
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

  if(this.movieRecipients.length == 0) {
    console.log("no movies selected")
    return
  }
  award.movies = this.movieRecipients

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
    console.log("No such Role. ID - " + id)
    return
  }

  if(this.roleRecipients.length == 0) {
    console.log("No roles selected")
    return
  }
  award.roles = this.roleRecipients
  this.awardService.addRoleAward(award).subscribe(elem =>{ 
    console.log(elem)
    this.singleFestival.holdings[this.holdingId].roleAwards.push(elem)
  })
  

   }


   
  updatePhoto = null
  updateFestivalId = 0


  setFestivalUpdateId(id : number) {
    this.updateFestivalId = id;

  }

  onUpdateChange(event : any) {
    this.updatePhoto = event.target.files[0]
    console.log(this.updatePhoto)
    console.log(this.updateFestivalId)
  }
  
  updateFestivalPhoto() {
    let data : File
    if(this.updatePhoto != null) {
    data = this.updatePhoto
    this.festivalService.updatePhoto(this.updateFestivalId, data)
    console.log("sent request")
    } else
    console.log("Update failed, no photo")
  }
  

  updateFestivalData = {
    name : "",
    description: ""
  }


  setFestivalData() {
    this.updateFestivalData.name = this.singleFestival.name
    this.updateFestivalData.description = this.singleFestival.description
  }

  updateFestival() {
    let festival = this.singleFestival

    if(this.updateFestivalData.name == "") {
      console.log("Emptu name")
      return
    }

    if(this.updateFestivalData.description == "") {
      console.log("Emptu description")
      return
    }

    festival.name = this.updateFestivalData.name
    festival.description = this.updateFestivalData.description

    this.festivalService.updateFestival(festival).subscribe(elem => console.log(elem))

  }

  roleRecipients : DownRole[] = []

  addRole() {
    let id = this.roleForm.get("roleId")?.value ?? -1
    if(id == -1 || this.holdingId == 0){
      console.log("Data not valid." + id + "- id,"  + this.holdingId + " - holding id")
      return
    }
     
    let role = this.Roles.find(elem => elem.id == id)
    if(!role) {
      console.log("No such Role. ID - " + id)
      return
    }

    let helper = this.roleRecipients.find(elem => elem.id == id)
    if(!helper)
    this.roleRecipients.push(role)
  }



  
  movieRecipients : PartialMovie[] = []

  addMovie() {
    let id = this.movieForm.get("movieId")?.value ?? -1
    if(id == -1 ||  this.holdingId == 0){
      console.log("Data not valid." + id + "- id," + this.holdingId + " - holding id")
      return
    }
      
    let help = this.Movies.find(elem => elem.id == id)
    if(!help) {
      console.log("No such movie. ID - " + id)
      return
    }
    
    let helper = this.movieRecipients.find(elem => elem.id == id)
    if(!helper)
    this.movieRecipients.push(help)
  }


  
  producingRecipients : DownProducingMovie[] = []

  addProducing() {
    let id = this.producingForm.get("producingIndex")?.value ?? -1
    if(id == -1  || this.holdingId == 0){
      console.log("Data not valid." + id + "- id,"  + this.holdingId + " - holding id")
      return
    }
     
    if(this.Producings.length <= id ) {
      console.log("bad value")
      return
      }

      let help = this.Producings[id]
      let helper = this.producingRecipients.find(elem => {elem.producer.id == help.producer.id && elem.movie.id == help.movie.id})
      console.log(helper)
    if(!helper)
      this.producingRecipients.push(help)
  }



  searchData : Festival[] = []

  searchField = ""

  search() {
this.searchData = this.Festivals.filter(x => (x.name.toLowerCase().includes(this.searchField.toLowerCase())))
    console.log(this.searchData);
  }
}
