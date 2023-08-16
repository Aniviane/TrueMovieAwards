import { Injectable } from '@angular/core';
import { User } from '../Models/User';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { UserLogin } from '../Models/UserLogin';
import { Favorise } from '../Models/Favorise';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  constructor(private httpClient : HttpClient) { }

  login(user:UserLogin) : Observable<User> {
    return this.httpClient.post<any>(BaseUrl + "api/User/Login",user)
  }

  register(user: User) : Observable<User> {
    return this.httpClient.post<any>(BaseUrl + "api/User" ,user)
  }

  getUser(id : number) : Observable<User> {
    return this.httpClient.get<User>(BaseUrl + "api/User/" + id)
  }
  getUsers() : Observable<User[]> {
    return this.httpClient.get<User[]>(BaseUrl + "api/User/")
  }

  deleteUser(id : number) : void {
    this.httpClient.delete(BaseUrl + "api/User/" + id).subscribe(elem => console.log(elem))
    console.log(BaseUrl + "api/User/" + id)
  }

  favorise(data : Favorise) : void{
    this.httpClient.put(BaseUrl + "api/User/Favorise", data).subscribe(elem => console.log(elem))
    console.log("Favorised :")
    console.log(data)
  }

  updateNotify(id : number) {
    this.httpClient.put(BaseUrl + "api/User/UpdateNotify", id)
    console.log("Notify Update notidicationId :" + id)
  }
}
