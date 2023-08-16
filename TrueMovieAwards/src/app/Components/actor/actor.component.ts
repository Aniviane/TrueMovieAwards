import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { single, throttle } from 'rxjs';
import { Actor } from 'src/app/Models/Actor';
import { Favorise } from 'src/app/Models/Favorise';
import { PartialAward } from 'src/app/Models/PartialAward';
import { ActorService } from 'src/app/Services/actor.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-actor',
  templateUrl: './actor.component.html',
  styleUrls: ['./actor.component.css']
})
export class ActorComponent implements OnInit {

  constructor(private userService:UserService,private actorService : ActorService, private dom: DomSanitizer, private route:ActivatedRoute) { }
  Actors : Actor[]= []
  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  singleDataFlag : boolean = false
  singleActor : Actor = new Actor
  awardList : PartialAward[] = []
  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }


  amIGeneral() : boolean {
    if(localStorage.getItem("UserType") == "General") return true
    return false
  }


  favoriseActor(id : number) {
    let data = new Favorise
    data.id = id
    data.mode = "Actor"
    this.userService.favorise(data)
  }

  actorForm = new FormGroup({
    fName : new FormControl("", Validators.required),
    lName: new FormControl("", Validators.required),
    doB : new FormControl(new Date, Validators.required),
    bio : new FormControl("", Validators.required),
    aPhoto : new FormControl(""),
  })


  addActor() : void {
    let actor = new Actor()

    actor.fName = this.actorForm.get("fName")?.value ?? ""
    actor.lName = this.actorForm.get("lName")?.value ?? ""
    actor.bio = this.actorForm.get("bio")?.value ?? ""
    actor.doB = this.actorForm.get("doB")?.value ?? new Date
    actor.aPhoto = this.actorForm.get("aPhoto")?.value ?? ""
    
    this.actorService.addActor(actor).subscribe(elem => {
      console.log(elem)
    })
  }


  ngOnInit(): void {
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
        this.awardList = []
        this.actorService.getActor(id).subscribe(elem =>{
          this.singleActor = elem
          this.singleActor.roles.forEach(role => {
            role.roleAwards.forEach(award => {
              this.awardList.push(award)
            })
          })
          console.log("single actor:")
          console.log(this.singleActor)
          console.log(this.singleActor.aPhoto)
          this.singleDataFlag = true
        })

      } else {
        this.singleDataFlag = false
        this.awardList = []
        this.actorService.getActors().subscribe(elem => {
          this.Actors = elem;
          
          console.log(this.Actors)
        })
      }
    })
    


  }

  makeMyUrlSafe(url : string): SafeUrl {
   
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }


}
