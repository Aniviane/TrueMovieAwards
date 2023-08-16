import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Series } from '../Models/Series';

@Injectable({
  providedIn: 'root'
})
export class SeriesService {

  constructor(private http:HttpClient) { }
 
  getSeries() : Observable<Series[]>{
    return this.http.get<Series[]>(BaseUrl + "api/Series")
  }

  getSerie(id : number) : Observable<Series>{
    return this.http.get<Series>(BaseUrl + "api/Series/" + id)
  }
}