import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { Producer } from '../Models/Producer';

@Injectable({
  providedIn: 'root'
})
export class ProducerService {

  constructor(private http:HttpClient) { }
 
  getProducers() : Observable<Producer[]>{
    return this.http.get<Producer[]>(BaseUrl + "api/Producer")
  }

  getProducer(id : number) : Observable<Producer>{
    return this.http.get<Producer>(BaseUrl + "api/Producer/" + id)
  }

  addProducer(data : Producer) : Observable<Producer> {
    return this.http.post<Producer>(BaseUrl + "api/Producer/",data);
  }
 
}