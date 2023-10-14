import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Genre } from '../Models/Genre';
import { BaseUrl } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { GenreMovie } from '../Models/GenreMovie';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private http:HttpClient) { }
 
  getGenres() : Observable<Genre[]>{
    return this.http.get<Genre[]>(BaseUrl + "api/Genres")
  }

  getGenre(id : number) : Observable<Genre>{
    return this.http.get<Genre>(BaseUrl + "api/Genres/" + id)
  }
  addGenre(data : Genre) : Observable<Genre> {
    return this.http.post<Genre>(BaseUrl + "api/Genres", data)
  }

  updateGenre(data : Genre) : Observable<Genre> {
    return this.http.put<Genre>(BaseUrl + "api/Genres/"+ data.id, data)
  }

  addMovie(data : GenreMovie) : Observable<Genre>{
    return this.http.put<Genre>(BaseUrl + "api/Genres/AddMovie", data)
  }
}
