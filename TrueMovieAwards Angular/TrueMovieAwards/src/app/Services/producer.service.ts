import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BaseUrl } from 'src/environments/environment';
import { Movie } from '../Models/Movie';
import { Producer } from '../Models/Producer';
import { ProducerCreate } from '../Models/ProducerCreate';

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

  addProducer(data : ProducerCreate) : Observable<Producer> {
    let formData = new FormData
    formData.append("FName", data.fName)
    formData.append("LName", data.lName)
    formData.append("DoB", data.doB.toISOString())
    formData.append("Photo", data.photo)
    formData.append("Bio", data.bio)
    
    return this.http.post<Producer>(BaseUrl + "api/Producer/",formData);
  }
 
  updatePhoto(id:number, photo : File) {
    let formData = new FormData;
    formData.append("ID", id.toString())
    formData.append("Photo", photo)
    this.http.put(BaseUrl + "api/Producer/UpdatePhoto", formData).subscribe(ele => console.log("put request done" + ele))
  }



  updateProducer(data : Producer) : Observable<Producer> {
    return this.http.put<Producer>(BaseUrl + "api/Producer/"+ data.id, data)
  }
}