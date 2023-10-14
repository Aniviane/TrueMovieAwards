import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Studio } from '../Models/Studio';
import { StudioCreate } from '../Models/StudioCreate';

@Injectable({
  providedIn: 'root'
})
export class StudioService {

  constructor(private http:HttpClient) { }
 
  getStudios() : Observable<Studio[]>{
    return this.http.get<Studio[]>(BaseUrl + "api/Studio")
  }

  getStudio(id : number) : Observable<Studio>{
    return this.http.get<Studio>(BaseUrl + "api/Studio/" + id)
  }

  addStudio(studio:any) : Observable<Studio> {

    let formData = new FormData
    formData.append('name', studio.name)
    formData.append('description', studio.description)
    formData.append('photo', studio.file)
    console.log("sent data ")
    console.log(formData)
    return this.http.post<Studio>(BaseUrl + "api/Studio", formData)
  }


  updatePhoto(id:number, photo : File) {
    let formData = new FormData;
    formData.append("ID", id.toString())
    formData.append("Photo", photo)
    this.http.put(BaseUrl + "api/Studio/UpdatePhoto", formData).subscribe(ele => console.log("put request done" + ele))
  }

  updateStudio(data : Studio) : Observable<Studio> {
    return this.http.put<Studio>(BaseUrl + "api/Studio/"+ data.id, data)
  }
}