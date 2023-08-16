import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Studio } from 'src/app/Models/Studio';
import { StudioCreate } from 'src/app/Models/StudioCreate';
import { StudioService } from 'src/app/Services/studio.service';

@Component({
  selector: 'app-studio',
  templateUrl: './studio.component.html',
  styleUrls: ['./studio.component.css']
})
export class StudioComponent implements OnInit {
  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  makeMyUrlSafe(url : string): SafeUrl {
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }


  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }


  studioToAdd  = {
    name : '',
    description : '',
    file : null
  }

  onSubmit() {
    this.studioService.addStudio(this.studioToAdd).subscribe(elem => console.log(elem))
  }

  onPhotoChange(event : any) {
    this.studioToAdd.file = event.target.files[0]
    console.log(this.studioToAdd)
  }

  constructor(private studioService:StudioService, private dom:DomSanitizer, private route: ActivatedRoute) { }

  Studios : Studio[] = []
  singleDataFlag : boolean = false
  singleStudio! : Studio

  ngOnInit(): void {
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
        
        this.studioService.getStudio(id).subscribe(elem =>{
          this.singleStudio = elem
          console.log("single studio:")
          console.log(this.singleStudio)
          this.singleDataFlag = true
        })

      } else {
        this.singleDataFlag = false
        this.studioService.getStudios().subscribe(elem => {
          this.Studios = elem;
          
          console.log(this.Studios)
        })
      }
    })
  }
 

}
