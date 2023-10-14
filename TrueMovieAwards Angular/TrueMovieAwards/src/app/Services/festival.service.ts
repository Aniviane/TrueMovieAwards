import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { Festival } from '../Models/Festival';
import { FestivalCreate } from '../Models/FestivalCreate';

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
 
  addFestival(data : FestivalCreate) : Observable<Festival> {
    let formData = new FormData
    formData.append("Name",data.name)
    formData.append("Description",data.description)
    formData.append("Photo",data.photo)
    return this.http.post<Festival>(BaseUrl + "api/Festival", formData)
  }




  updatePhoto(id:number, photo : File) {
    let formData = new FormData;
    formData.append("ID", id.toString())
    formData.append("Photo", photo)
    this.http.put(BaseUrl + "api/Festival/UpdatePhoto", formData).subscribe(ele => console.log("put request done" + ele))
  }

  updateFestival(data : Festival) : Observable<Festival> {
    return this.http.put<Festival>(BaseUrl + "api/Festival/"+ data.id, data)
  }
}
