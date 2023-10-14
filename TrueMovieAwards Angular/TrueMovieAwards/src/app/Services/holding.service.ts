import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { Holding } from '../Models/Holding';

@Injectable({
  providedIn: 'root'
})
export class HoldingService {

  constructor(private http:HttpClient) { }
 
  getHoldings() : Observable<Holding[]>{
    return this.http.get<Holding[]>(BaseUrl + "api/Holding")
  }

  getHolding(id : number) : Observable<Holding>{
    return this.http.get<Holding>(BaseUrl + "api/Holding/" + id)
  }

  addHolding(Holding : Holding) : Observable<Holding> {
    return this.http.post<Holding>(BaseUrl + "api/Holding/", Holding)
    
  }

  updateHolding(data : Holding) : Observable<Holding> {
    return this.http.put<Holding>(BaseUrl + "api/Holding/"+ data.id, data)
  }
}
