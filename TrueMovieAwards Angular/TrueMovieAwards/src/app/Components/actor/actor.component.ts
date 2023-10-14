import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { single, throttle } from 'rxjs';
import { Actor } from 'src/app/Models/Actor';
import { ActorCreate } from 'src/app/Models/ActorCreate';

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
    bio : new FormControl("", Validators.required)
   
  })


  actorPhoto = null

  onChange(event : any) {
    this.actorPhoto = event.target.files[0]
    console.log(this.actorPhoto)
  }

  addActor() : void {
    let actor = new ActorCreate()

    actor.fName = this.actorForm.get("fName")?.value ?? ""
    actor.lName = this.actorForm.get("lName")?.value ?? ""
    actor.bio = this.actorForm.get("bio")?.value ?? ""
    actor.doB = new Date(this.actorForm.get("doB")?.value ?? new Date)
    console.log(actor)
    if(this.actorPhoto != null)
    actor.aPhoto = this.actorPhoto 
  else return
    
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
          this.searchData = elem;
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

  updatePhoto = null
  updateActorId = 0


  setActorId(id : number) {
    this.updateActorId = id;

  }

  onUpdateChange(event : any) {
    this.updatePhoto = event.target.files[0]
    console.log(this.updatePhoto)
    console.log(this.updateActorId)
  }

  updateActorPhoto() {
    let data : File
    if(this.updatePhoto != null) {
    data = this.updatePhoto
    this.actorService.updatePhoto(this.updateActorId, data)
    console.log("sent request")
    } else
    console.log("Update failed, no photo")
  }



  updateActorData = {
    fName : "",
    lName : "",
    bio : "",
    date : new Date,

  }

  setActorData() {
    this.updateActorData.fName = this.singleActor.fName;
    
    this.updateActorData.lName = this.singleActor.lName;
    
    this.updateActorData.bio = this.singleActor.bio;
    
    this.updateActorData.date = this.singleActor.doB;
  }

  updateActor() {
    if(this.updateActorData.fName == "") {
      console.log("Empty first name")
      return
    }
    if(this.updateActorData.lName == "") {
      console.log("Empty last name")
      return
    }
    if(this.updateActorData.bio == "") {
      console.log("Empty bio")
      return
    }
   


    let actor = this.singleActor
    actor.fName = this.updateActorData.fName
    actor.lName = this.updateActorData.lName
    actor.bio = this.updateActorData.bio
    actor.doB = this.updateActorData.date

    actor.roles = []
    
    console.log(actor)
    //this.actorService.updateActor(actor).subscribe(elem => console.log(elem))

  }

  gimmeDate(date:Date) : Date {
    return new Date(date)
  }

  searchData : Actor[] = []

  searchField = ""

  deleteActor(id : number) {
    this.actorService.deleteActor(id);
  }


  search() {
this.searchData = this.Actors.filter(x => (x.fName.toLowerCase().includes(this.searchField.toLowerCase()) || (x.lName.toLowerCase().includes(this.searchField.toLowerCase()))))
    console.log(this.searchData);
  }
}
