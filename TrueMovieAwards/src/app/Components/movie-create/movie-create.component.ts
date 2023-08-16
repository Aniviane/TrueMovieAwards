import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Actor } from 'src/app/Models/Actor';
import { Genre } from 'src/app/Models/Genre';
import { LeftProducingMovie } from 'src/app/Models/LeftProducingMovie';
import { Movie } from 'src/app/Models/Movie';
import { PartialActor } from 'src/app/Models/PartialActor';
import { PartialGenre } from 'src/app/Models/PartialGenre';
import { PartialProducer } from 'src/app/Models/PartialProducer';
import { PartialSeries } from 'src/app/Models/PartialSeries';
import { PartialStudio } from 'src/app/Models/PartialStudio';
import { Producer } from 'src/app/Models/Producer';
import { RightRole } from 'src/app/Models/RightRole';
import { Series } from 'src/app/Models/Series';
import { Studio } from 'src/app/Models/Studio';
import { ActorService } from 'src/app/Services/actor.service';
import { GenreService } from 'src/app/Services/genre.service';
import { MovieService } from 'src/app/Services/movie.service';
import { ProducerService } from 'src/app/Services/producer.service';
import { SeriesService } from 'src/app/Services/series.service';
import { StudioService } from 'src/app/Services/studio.service';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.css']
})
export class MovieCreateComponent implements OnInit {

  constructor(private dom:DomSanitizer, private movieService: MovieService, private actorService : ActorService, private producerService : ProducerService, private seriesService : SeriesService, private studioService : StudioService, private genreService : GenreService ) { }

  Actors! : Actor[] 
  Producers! : Producer[]
  Genres : Genre[]  = []
  Series! : Series[]
  Studios! : Studio[]
  RolesToAdd : RightRole[] = []
  ProducingsToAdd : LeftProducingMovie[] = []
  SeriesToAdd! : PartialSeries
  StudioToAdd! : PartialStudio
  GenresToAdd : PartialGenre[] = []

  ngOnInit(): void {
    this.actorService.getActors().subscribe(elem => this.Actors = elem)
    this.producerService.getProducers().subscribe(elem => this.Producers = elem)
    this.seriesService.getSeries().subscribe(elem => this.Series = elem)
    this.studioService.getStudios().subscribe(elem => this.Studios = elem)
   // this.genreService.getGenres().subscribe(elem => this.Genres = elem)

  }




 

  actorid : number = 0
  roleFName : string = ""
  roleLName : string = ""


  gimmeActor(id : number) : PartialActor {
    
    let actor = this.Actors.find(elem => elem.id == id)
    let partial = new PartialActor()
    partial.fname = actor?.fName ?? ""
    partial.lname = actor?.lName ?? ""
    partial.id = actor?.id ?? 0
    partial.photo = actor?.aPhoto ?? ""

    return partial

  }



  AddRole() : void {
    let role = new RightRole()
    console.log("ActorId : " + this.actorid)
    console.log("Role first name : " + this.roleFName)
    console.log("lastname : " + this.roleLName)
    if(this.actorid != 0) {
    let actor = this.gimmeActor(this.actorid)
    if(actor.id != 0) {
      role.actor = actor
      role.fName = this.roleFName
      role.lName = this.roleLName
       this.RolesToAdd.push(role)

       this.actorid = 0
       this.roleFName = ""
       this.roleLName = ""
    }else {
      console.log("NO ACTOR ID")
    }

    console.log(this.RolesToAdd)
  }
  }

  producingId : number = 0


  gimmeProducer(id : number) : PartialProducer {
    let producer = this.Producers.find(elem => elem.id == id)
    let partial = new PartialProducer()
    partial.fName = producer?.fName ?? ""
    partial.id = producer?.id ?? 0
    partial.lName = producer?.lName ?? ""
    partial.photo = producer?.photo ?? ""

    return partial

  }



  AddProducing() : void {
    let producing = new LeftProducingMovie()
    
    if (this.producingId != 0) {
      let partial = this.gimmeProducer(this.producingId)
      producing.producer = partial
      this.ProducingsToAdd.push(producing)

      console.log("Added a producing :")
      console.log(this.ProducingsToAdd)
    }

    
  }

  movieForm = new FormGroup({
    title : new FormControl("",Validators.required),
    description : new FormControl("",Validators.required),
    dateOfRelease : new FormControl(new Date,Validators.required),
    photo : new FormControl("",Validators.required),
    seriesId : new FormControl(0,Validators.required),
    studioId : new FormControl(0,Validators.required)
  })



  gimmeSeries(id : number): PartialSeries {
    let partial = new PartialSeries
    let serie = this.Series.find(elem => elem.id == id)
    partial.id = serie?.id ?? 0
    partial.fName = serie?.fName ?? ""
    return partial
  }
 
  addSeries() : void {
    let id = this.movieForm.get("seriesId")?.value ?? 0
    if(id) {
      let partial = this.gimmeSeries(id)

      this.SeriesToAdd = partial

      console.log("Added series with the ID:"+ partial.id)
      console.log(this.SeriesToAdd)
      
    }
  }

  gimmeStudio(id : number): PartialStudio {
    let partial = new PartialStudio
    let serie = this.Studios.find(elem => elem.id == id)
    partial.id = serie?.id ?? 0
    partial.name = serie?.name ?? ""
    return partial
  }

  addStudio() : void {
    let id = this.movieForm.get("studioId")?.value ?? 0
    if(id) {
      let partial = this.gimmeStudio(id)

      this.StudioToAdd = partial

      console.log("Added Studio with the ID:"+ partial.id)
      console.log(this.StudioToAdd)
    }
  }


  gimmeGenre(id : number): PartialGenre {
    let partial = new PartialGenre
    let genre = this.Genres.find(elem => elem.id == id)
    partial.id = genre?.id ?? 0
    partial.name = genre?.name ?? ""
    return partial
  }
  genreId : number = 0
  addGenre() : void {
    if(this.genreId) {
      let partial = this.gimmeStudio(this.genreId)

      this.GenresToAdd.push(partial)

      console.log("Added Genre with the ID:"+ partial.id)
      console.log(this.GenresToAdd)
    }
  }

  addMovie() : void {
    this.addSeries()
    this.addStudio()
    let movie = new Movie()
    movie.title = this.movieForm.get("title")?.value ?? ""
    movie.description = this.movieForm.get("description")?.value ?? ""
    movie.dateOfRelease = this.movieForm.get("dateOfRelease")?.value ?? new Date

    movie.genres = this.GenresToAdd
    movie.producings = this.ProducingsToAdd
    movie.roles = this.RolesToAdd
    movie.series = this.SeriesToAdd
    movie.studio = this.StudioToAdd

    movie.revCount = 0
    movie.revGrade = 0
    movie.photo = ""

    console.log("Movie built! Check it out:")
    console.log(movie)

    this.movieService.addMovie(movie).subscribe(elem => console.log(elem))
  }

  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")

  makeMyUrlSafe(url : string): SafeUrl {
   
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }



  removeProducing(num : number) {
    if(num + 1 <= this.ProducingsToAdd.length)
    this.ProducingsToAdd.splice(num,1)
  }

  removeRole(num : number) {
    console.log("index :" + num)
    console.log("length :" + this.RolesToAdd.length)
    if(num + 1 <= this.RolesToAdd.length)
    this.RolesToAdd.splice(num,1)
  }

  removeGenre(num : number) {
    if(num + 1 <= this.GenresToAdd.length)
    this.GenresToAdd.splice(num,1)
  }
}
