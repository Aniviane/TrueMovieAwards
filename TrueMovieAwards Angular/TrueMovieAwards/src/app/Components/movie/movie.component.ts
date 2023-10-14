import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { DownProducingMovie } from 'src/app/Models/DownProducingMovie';
import { Favorise } from 'src/app/Models/Favorise';
import { Movie } from 'src/app/Models/Movie';
import { PartialMovie } from 'src/app/Models/PartialMovie';
import { UpReview } from 'src/app/Models/UpReview';
import { MovieService } from 'src/app/Services/movie.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  makeMyUrlSafe(url : string): SafeUrl {
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }




  constructor(private userService:UserService,private movieService : MovieService, private dom: DomSanitizer, private route:ActivatedRoute) { }
  
  Movies : Movie[] = []
  singleDataFlag : boolean = false
  singleMovie! : Movie
  
  ngOnInit(): void {
    this.reviewFlag = 0
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
        
        this.movieService.getMovie(id).subscribe(elem =>{
          this.singleMovie = elem
          console.log("single movie:")
          console.log(this.singleMovie)
          if(this.singleMovie.series)
          console.log(this.singleMovie.series.fName)
          this.singleDataFlag = true
          
          
        })

      } else {
        this.singleDataFlag = false
        this.movieService.getMovies().subscribe(elem => {
          this.Movies = elem;
          this.searchData = elem;
          console.log(this.Movies)
        })
      }
    })
  }

  gimmeDate(date:Date) : Date {
    return new Date(date)
  }

  amIGeneral() : boolean {
    if(localStorage.getItem("UserType") == "General") return true
    return false
  }



  favoriseMovie(id : number) {
    let data = new Favorise
    data.id = id
    data.mode = "Movie"
    this.userService.favorise(data)
  }

  reviewForm = new FormGroup({
    description : new FormControl("", Validators.required),
    revGrade : new FormControl(0,Validators.compose([Validators.required, Validators.min(1), Validators.max(5)]))

  })

  reviewFlag = 0

  leaveAReview() {
    let review = new UpReview
    let partial = new PartialMovie
    partial.id = this.singleMovie.id
    partial.title = this.singleMovie.title

    

    if(partial.id)
    {
      review.description = this.reviewForm.get("description")?.value ?? ""
      review.grade = +(this.reviewForm.get("revGrade")?.value ?? 0)
      review.revTime = new Date()
      review.movie = partial

      this.userService.addReview(review).subscribe(elem => {
        console.log(elem)
        if(elem) 
        this.reviewFlag = 1
        else
        this.reviewFlag = -1
      })
    }
  }

  
  updatePhoto = null
  updateMovieId = 0


  setMovieId(id : number) {
    this.updateMovieId = id;

  }

  onUpdateChange(event : any) {
    this.updatePhoto = event.target.files[0]
    console.log(this.updatePhoto)
    console.log(this.updateMovieId)
  }

  updateMoviePhoto() {
    let data : File
    if(this.updatePhoto != null) {
    data = this.updatePhoto
    this.movieService.updatePhoto(this.updateMovieId, data)
    console.log("sent request")
    } else
    console.log("Update failed, no photo")
  }

  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }

  updateMovieData = {
    title : "",
    description : "",
    dateOfRelease : new Date

  }

  setUpdateData() {
    this.updateMovieData.title = this.singleMovie.title
    this.updateMovieData.description = this.singleMovie.description
    this.updateMovieData.dateOfRelease = this.singleMovie.dateOfRelease
  }


  updateMovie() {
    let movie = this.singleMovie
    if(this.updateMovieData.title == "") {
      console.log("empty title")
      return
    }

    if(this.updateMovieData.description == "") {
      console.log("empty description")
      return
    }

   movie.title = this.updateMovieData.title
   movie.description = this.updateMovieData.description
   movie.dateOfRelease = this.updateMovieData.dateOfRelease

    this.movieService.updateMovie(movie).subscribe(elem => console.log(elem))
  }


  delRole(id : number) {
    this.movieService.deleteRole(id)
  }

  updateRoleId = 0

  updateRoleData = {
    fname : "",
    lname : ""
  }


  setRoleId(id : number) {
    this.updateRoleId = id
    let role = this.singleMovie.roles.find(elem => elem.id == id)

    this.updateRoleData.fname = role?.fName ?? ""
    this.updateRoleData.lname = role?.lName ?? ""


  }

  updateRole() {

    let role = this.singleMovie.roles.find(elem => elem.id == this.updateRoleId)

    if(!role) {
      console.log("Invalid request")
      return
    }

    if(this.updateRoleData.fname == "") {
      console.log("empty first name")
      return
    }

    if(this.updateRoleData.lname == "") {
      console.log("empty last name")
      return
    }
    role.fName = this.updateRoleData.fname
    role.lName = this.updateRoleData.lname

    this.movieService.updateRole(role).subscribe(elem => console.log(elem))
  }

  delProducing(id : number) {
    let delProducing = new DownProducingMovie
    
    let producing = this.singleMovie.producings[id]

    let partialMovie = new PartialMovie()

    partialMovie.id = this.singleMovie.id
    delProducing.producer = producing.producer

    this.movieService.deleteProducing(delProducing)
  }


  addToWatchlist(id : number) {
    console.log("adding to watchlist")
    this.userService.addToWatchlist(id).subscribe(elem => console.log(elem))
  }

  searchData : Movie[] = []

  searchField = ""

  search() {
this.searchData = this.Movies.filter(x =>  (x.title.toLowerCase().includes(this.searchField.toLowerCase())))
    console.log(this.searchData);
  }
}
