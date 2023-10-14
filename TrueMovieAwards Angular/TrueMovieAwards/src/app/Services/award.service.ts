import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Award } from '../Models/Award';
import { BaseUrl } from 'src/environments/environment';
import { RoleAward } from '../Models/RoleAward';
import { MovieAward } from '../Models/MovieAward';
import { ProducerAward } from '../Models/ProducerAward';
import { AwardWrapper } from '../Models/AwardWrapper';

@Injectable({
  providedIn: 'root'
})
export class AwardService {

  constructor(private http:HttpClient) { }

  getAwards() : Observable<AwardWrapper[]> {
    return this.http.get<AwardWrapper[]>(BaseUrl + "api/Award")
  }

  getAward(id : number) : Observable<AwardWrapper> {
    return this.http.get<AwardWrapper>(BaseUrl + "api/Award/" + id)
  }

  addRoleAward(award : RoleAward): Observable<RoleAward> {
    return this.http.post<RoleAward>(BaseUrl + "api/Award/RoleAward", award)
  }
  addMovieAward(award : MovieAward): Observable<MovieAward> {
    return this.http.post<MovieAward>(BaseUrl + "api/Award/MovieAward", award)
  }
  addProducerAward(award : ProducerAward): Observable<ProducerAward> {
    return this.http.post<ProducerAward>(BaseUrl + "api/Award/ProducingAward", award)
  }


  updateAward(data : Award) : Observable<Award> {
    return this.http.put<Award>(BaseUrl + "api/Award/"+ data.id, data)
  }

}
