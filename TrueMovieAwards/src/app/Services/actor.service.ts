import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { Actor } from '../Models/Actor';

@Injectable({
  providedIn: 'root'
})
export class ActorService {

  constructor(private http:HttpClient) { }
 
  getActors() : Observable<Actor[]>{
    return this.http.get<Actor[]>(BaseUrl + "api/Actor")
  }

  getActor(id : number) : Observable<Actor>{
    return this.http.get<Actor>(BaseUrl + "api/Actor/" + id)
  }

  addActor(actor : Actor) : Observable<Actor> {
    return this.http.post<Actor>(BaseUrl + "api/Actor/", actor)
    
  }
}
