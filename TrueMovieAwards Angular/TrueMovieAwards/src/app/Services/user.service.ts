import { Injectable } from '@angular/core';
import { User } from '../Models/User';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseUrl } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { UserLogin } from '../Models/UserLogin';
import { Favorise } from '../Models/Favorise';
import { UserCreate } from '../Models/UserCreate';
import { UpReview } from '../Models/UpReview';
import { WatchList } from '../Models/WatchList';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  constructor(private httpClient : HttpClient) { }

  login(user:UserLogin) : Observable<User> {
    return this.httpClient.post<any>(BaseUrl + "api/User/Login",user)
  }

  register(user: UserCreate) : Observable<User> {
    let formData = new FormData
    formData.append("Username",user.username)
    formData.append("Password",user.password)
    formData.append("FName",user.fName)
    formData.append("LName",user.lName)
    formData.append("EMail",user.eMail)
    formData.append("UType",user.uType)
    formData.append("UPhoto",user.uPhoto)
    formData.append("Bio",user.bio)

    return this.httpClient.post<any>(BaseUrl + "api/User" ,formData)
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
    this.httpClient.put(BaseUrl + "api/User/UpdateNotify/", {}, {params: {id : id}}).subscribe(elem => {

      console.log(elem)
      console.log("Notify Update notidicationId :" + id)
    })
    
  }



  updatePhoto(id:number, photo : File) {
    let formData = new FormData;
    formData.append("ID", id.toString())
    formData.append("Photo", photo)
    this.httpClient.put(BaseUrl + "api/User/UpdatePhoto", formData).subscribe(ele => console.log("put request done" + ele))
  }

  updateUser(data : User) : Observable<User> {
    return this.httpClient.put<User>(BaseUrl + "api/User/", data)
  }

  addReview(data : UpReview) : Observable<UpReview> {
    return this.httpClient.post<UpReview>(BaseUrl+ "api/User/Review", data)
  }

  deleteReview(id : number) {
    this.httpClient.delete(BaseUrl + "api/User/Review", {params : {id : id}}).subscribe(elem => console.log(elem + " deleted"))
  }

  updateReview(data : UpReview) : Observable<UpReview> {
    return this.httpClient.put<UpReview>(BaseUrl + "api/User/Review", data)
  }

  registerModerator(data : UserLogin) : Observable<User> {
    return this.httpClient.post<User>(BaseUrl + "api/User/Moderator", data)
  }

  addToWatchlist(id : number) : Observable<WatchList> {
    
    return this.httpClient.put<WatchList>(BaseUrl + "api/User/Watchlist", {}, {params : {movieId : id}})
  }
}
