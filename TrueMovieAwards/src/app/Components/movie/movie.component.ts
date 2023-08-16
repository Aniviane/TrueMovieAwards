import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
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

      console.log(review)
    }
  }
}
