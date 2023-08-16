import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { DownRole } from '../Models/DownRole';
import { DownProducingMovie } from '../Models/DownProducingMovie';

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

  addMovie(movie : Movie) : Observable<Movie> {
    return this.http.post<Movie>(BaseUrl+"api/Movie",movie)
  }


  getRoles() : Observable<DownRole[]> {
    return this.http.get<DownRole[]>(BaseUrl + "api/Movie/Roles")
  }

  getProducings() : Observable<DownProducingMovie[]> {
    return this.http.get<DownProducingMovie[]>(BaseUrl + "api/Movie/Producings")
  }
}