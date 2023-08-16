import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService:UserService, private dom:DomSanitizer, private route:ActivatedRoute, private router:Router) { }
  singleDataFlag : boolean = false
  UserToDisplay! : User
  
  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  makeMyUrlSafe(url : string): SafeUrl {
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }

  gimmeDate(date:Date) : Date {
    return new Date(date)
  }

  amILoggedIn(linkId : number) : boolean {
    let localId = +(localStorage.getItem("Id") ?? 0)

    return localId == linkId
  }

  amIAdmin() : boolean {
    let userType = localStorage.getItem("UserType")
    return userType == "Admin"
  }

  loggedInFlag : boolean = false

  Users : User[] = []


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
        this.loggedInFlag = this.amILoggedIn(id)
        this.userService.getUser(id).subscribe(elem =>{
          this.UserToDisplay = elem
          console.log("single user:")
          console.log(this.UserToDisplay)
          this.singleDataFlag = true
        })

      } else {
        
       this.userService.getUsers().subscribe( elem => 
        {
          this.Users = elem
          this.singleDataFlag = false
       } )
      }
    })
  }


  removeUser(id : number, index : number) {
    this.userService.deleteUser(id)
    this.Users.splice(index,1)
    console.log("User with ID: " + id + " Has been deleted")

  }


  updateNotify(id : number) {
    let userId = +(localStorage.getItem("Id") ?? 0)
    if(userId == 0) return

    this.userService.updateNotify(id)
  }
}
