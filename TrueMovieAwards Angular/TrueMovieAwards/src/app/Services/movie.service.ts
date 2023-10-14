import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { DownRole } from '../Models/DownRole';
import { DownProducingMovie } from '../Models/DownProducingMovie';
import { MovieCreate } from '../Models/MovieCreate';
import { LeftProducingMovie } from '../Models/LeftProducingMovie';
import { RightRole } from '../Models/RightRole';
import { UpReview } from '../Models/UpReview';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http:HttpClient) { }
 
  getMovies() : Observable<Movie[]>{
    return this.http.get<Movie[]>(BaseUrl + "api/Movie")
  }

  getMovie(id : number) : Observable<Movie>{
    return this.http.get<Movie>(BaseUrl + "api/Movie/" + id)
  }

  addMovie(movie : MovieCreate) : Observable<Movie> {

    let formData = new FormData
    formData.append("Title",movie.title)
    formData.append("Description",movie.description)
    formData.append("DateOfRelease",movie.dateOfRelease.toISOString())
    formData.append("Photo",movie.photo)
   
    movie.producings.forEach(producing => {
      formData.append("Producings[]", producing.producer.id.toString())
    })
    let seriesId = movie.series.id ?? 0
    formData.append("SeriesId",seriesId.toString())
    let studioId = movie.studio.id ?? 0
    formData.append("StudioId",studioId.toString())
    movie.genres.forEach(element => {
      formData.append("Genres[]", element.id.toString())
   
    });
    if(movie.genres.length == 0)
    formData.append("Genres[]", "")

 

    movie.roles.forEach((role,index) => {
      formData.append("Roles["+index.toString()+"].FName",role.fName)
      formData.append("Roles["+index.toString()+"].LName",role.lName)
      formData.append("Roles["+index.toString()+"].ActorID",role.actor.id.toString())
    })

    return this.http.post<Movie>(BaseUrl+"api/Movie",formData)
  }


  getRoles() : Observable<DownRole[]> {
    return this.http.get<DownRole[]>(BaseUrl + "api/Movie/Roles")
  }

  getProducings() : Observable<DownProducingMovie[]> {
    return this.http.get<DownProducingMovie[]>(BaseUrl + "api/Movie/Producings")
  }


   updatePhoto(id:number, photo : File) {
    let formData = new FormData;
    formData.append("ID", id.toString())
    formData.append("Photo", photo)
    this.http.put(BaseUrl + "api/Movie/UpdatePhoto", formData).subscribe(ele => console.log("put request done" + ele))
  }

  updateMovie(data : Movie) : Observable<Movie> {
    return this.http.put<Movie>(BaseUrl + "api/Movie/"+ data.id, data)
  }

  deleteRole(id : number) {
    this.http.delete(BaseUrl + "api/Movie/Roles/" + id)
  }

  deleteProducing(producing : DownProducingMovie) {
    this.http.put(BaseUrl + "api/Movie/Roles/", producing)
  }

  updateRole(data : RightRole) : Observable<RightRole> {
    return this.http.put<RightRole>(BaseUrl + "api/Movie/Roles/" + data.id, data)
  }


}