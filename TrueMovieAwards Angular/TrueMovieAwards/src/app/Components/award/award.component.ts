import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { AwardWrapper } from 'src/app/Models/AwardWrapper';
import { AwardService } from 'src/app/Services/award.service';

@Component({
  selector: 'app-award',
  templateUrl: './award.component.html',
  styleUrls: ['./award.component.css']
})
export class AwardComponent implements OnInit {

  constructor(private awardService : AwardService, private dom:DomSanitizer, private route:ActivatedRoute) { }


  Awards : AwardWrapper[] = []
  singleAward! : AwardWrapper
  singleDataFlag : boolean = false

  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }

  ngOnInit(): void {
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
       
        this.awardService.getAward(id).subscribe(elem =>{
          this.singleAward = elem
          console.log("single award:")
          console.log(this.singleAward)
          this.singleDataFlag = true
          })
         
        } else {
        this.singleDataFlag = false
        
        this.awardService.getAwards().subscribe(elem => {
          this.Awards = elem;
          
          console.log(this.Awards)
        })
      }
    })
    

  }
  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  makeMyUrlSafe(url : string): SafeUrl {
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }


  updateAwardName = ""

  setAwardName() {
    if(this.singleAward.awardType == "Movie")
    this.updateAwardName = this.singleAward.movieAward.name
    if(this.singleAward.awardType == "Producer")
    this.updateAwardName = this.singleAward.producerAward.name
    if(this.singleAward.awardType == "Role")
    this.updateAwardName = this.singleAward.roleAward.name

   

  }

  updateAward() {
    let award
    if(this.singleAward.awardType == "Movie") {
    award = this.singleAward.movieAward
    award.movies = []
    }
    if(this.singleAward.awardType == "Producer"){
    award= this.singleAward.producerAward
    award.producings = []
    }
    if(this.singleAward.awardType == "Role"){
    award = this.singleAward.roleAward
    award.roles = []
    }

    if(!award) {
      console.log("Update failed")
      return}

    award.name = this.updateAwardName

    this.awardService.updateAward(award).subscribe(elem => console.log(elem))


  }




}
