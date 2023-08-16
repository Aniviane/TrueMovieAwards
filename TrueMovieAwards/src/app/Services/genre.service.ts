import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Genre } from '../Models/Genre';
import { BaseUrl } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private http:HttpClient) { }
 
  getGenres() : Observable<Genre[]>{
    return this.http.get<Genre[]>(BaseUrl + "api/Genre")
  }

  getGenre(id : number) : Observable<Genre>{
    return this.http.get<Genre>(BaseUrl + "api/Genre/" + id)
  }
 
}
