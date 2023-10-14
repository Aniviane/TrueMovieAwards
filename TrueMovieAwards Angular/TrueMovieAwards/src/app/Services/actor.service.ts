import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { Actor } from '../Models/Actor';
import { ActorCreate } from '../Models/ActorCreate';

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

  addActor(actor : ActorCreate) : Observable<Actor> {
    let formData = new FormData
    formData.append("FName", actor.fName)
    formData.append("LName", actor.lName)
    formData.append("DoB", actor.doB.toISOString())
    formData.append("APhoto", actor.aPhoto)
    formData.append("Bio", actor.bio)
    
    return this.http.post<Actor>(BaseUrl + "api/Actor/", formData)
    
  }

  updatePhoto(id:number, photo : File) {
    let formData = new FormData;
    formData.append("ID", id.toString())
    formData.append("Photo", photo)
    this.http.put(BaseUrl + "api/Actor/UpdatePhoto", formData).subscribe(ele => console.log("put request done" + ele))
  }


  deleteActor(id : number) {
    this.http.delete(BaseUrl + "api/Actor/" + id).subscribe(elem => console.log(elem))
  }

  updateActor(data : Actor) : Observable<Actor> {
    return this.http.put<Actor>(BaseUrl + "api/Actor/"+ data.id, data)
  }
}
