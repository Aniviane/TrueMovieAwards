import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Genre } from 'src/app/Models/Genre';
import { GenreMovie } from 'src/app/Models/GenreMovie';
import { Movie } from 'src/app/Models/Movie';
import { GenreService } from 'src/app/Services/genre.service';
import { MovieService } from 'src/app/Services/movie.service';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {

  constructor(private movieService : MovieService,private genreService : GenreService, private dom:DomSanitizer, private route:ActivatedRoute) { }
 
  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  makeMyUrlSafe(url : string): SafeUrl {
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }

  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }

  
  Genres : Genre[] = []
  singleDataFlag: boolean = false
  singleGenre! : Genre
  
  ngOnInit(): void {
    this.movieService.getMovies().subscribe(elem => this.Movies = elem)
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
      
        this.genreService.getGenre(id).subscribe(elem =>{
          this.singleGenre = elem
          console.log("single serie:")
          console.log(this.singleGenre)
          this.singleDataFlag = true
        })

      } else {
        this.singleDataFlag = false
        this.genreService.getGenres().subscribe(elem => {
          this.Genres = elem;
          this.searchData = elem;
          
          console.log(this.Genres)
        })
      }
    })
  }

  genreForm = new FormGroup({
    name : new FormControl("", Validators.required)
  })

  onSubmit() {
    let genre = new Genre()

    genre.fName = this.genreForm.get("name")?.value ?? ""

    this.genreService.addGenre(genre).subscribe(elem => this.Genres.push(elem))
  }

  Movies! : Movie[]

  addMovieData = {
    movieId : 0,
    genreId : 0
  }

  setMovieId() {
    this.addMovieData.genreId = this.singleGenre.id
  }

  addMovieToGenre() {
    let data = new GenreMovie()

    if(this.addMovieData.movieId == 0 || this.addMovieData.genreId == 0) {
      return
    }
    data.movieId = this.addMovieData.movieId
    data.genreId = this.addMovieData.genreId

    this.genreService.addMovie(data).subscribe(elem => {
      if(elem) {
        this.singleGenre = elem
      }
    })

  }
  
  updateGenreName = ""

  setGenreName() {
    this.updateGenreName = this.singleGenre.fName
  }

  updateGenre() {
    let genre = this.singleGenre
 
    genre.fName = this.updateGenreName

    this.genreService.updateGenre(genre).subscribe(elem => console.log(elem))


  }



  searchData : Genre[] = []

  searchField = ""

  search() {
this.searchData = this.Genres.filter(x =>  (x.fName.toLowerCase().includes(this.searchField.toLowerCase())))
    console.log(this.searchData);
  }



}
