import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { Festival } from '../Models/Festival';

@Injectable({
  providedIn: 'root'
})
export class FestivalService {

  constructor(private http:HttpClient) { }
 
  getFestivals() : Observable<Festival[]>{
    return this.http.get<Festival[]>(BaseUrl + "api/Festival")
  }

  getFestival(id : number) : Observable<Festival>{
    return this.http.get<Festival>(BaseUrl + "api/Festival/" + id)
  }
 
  addFestival(data : Festival) : Observable<Festival> {
    return this.http.post<Festival>(BaseUrl + "api/Festival", data)
  }
}
