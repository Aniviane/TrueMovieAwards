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
    return this.http.post<Studio>(BaseUrl + "api/Studio", formData)
  }
}