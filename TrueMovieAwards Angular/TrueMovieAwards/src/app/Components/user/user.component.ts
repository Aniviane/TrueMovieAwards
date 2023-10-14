import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { DownReview } from 'src/app/Models/DownReview';
import { UpReview } from 'src/app/Models/UpReview';
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

  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }

  
  amIGeneral() : boolean {
    return this.userType == "General"
  }


  ngOnInit(): void {
    this.userType = localStorage.getItem("UserType") ?? ""
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
          this.searchData = elem;
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
    if(!userId || userId == 0) return
    console.log("Not id :" + id + " and userId : " + userId)
    this.userService.updateNotify(id)
  }


  
  
  updatePhoto = null
  updateUserId = 0


  setUserId(id : number) {
    this.updateUserId = id;

  }

  onUpdateChange(event : any) {
    this.updatePhoto = event.target.files[0]
    console.log(this.updatePhoto)
    console.log(this.updateUserId)
  }

  updateUserPhoto() {
    let data : File
    if(this.updatePhoto != null) {
    data = this.updatePhoto
    this.userService.updatePhoto(this.updateUserId, data)
    console.log("sent request")
    } else
    console.log("Update failed, no photo")
  }


  
  updateUserData = {
    username : "",
    newPassword: "",
    fName : "",
    lName : "",
    eMail : "",
    bio : ""
  }


  setUserData() {
  this.updateUserData.username = this.UserToDisplay.username  
  this.updateUserData.fName = this.UserToDisplay.fName  
  this.updateUserData.lName = this.UserToDisplay.lName  
  this.updateUserData.eMail = this.UserToDisplay.eMail  
  this.updateUserData.bio = this.UserToDisplay.bio  
  console.log(this.updateUserData)
  }

  updateUser() {
    let User = this.UserToDisplay

    


    if(this.updateUserData.username == "") {
      console.log("Emptu userName")
      return
    }

    if(this.updateUserData.fName  == "") {
      console.log("Emptu First Name")
      return
    }
    if(this.updateUserData.eMail  == "") {
      console.log("Emptu Email")
      return
    }
     if(this.updateUserData.bio  == "") {
      console.log("Emptu Bio")
      return
    }
    if(this.updateUserData.newPassword  == "") {
      console.log("Emptu password")
      return
    }

   User.username = this.updateUserData.username
   User.eMail = this.updateUserData.eMail
   User.fName = this.updateUserData.fName
   User.lName = this.updateUserData.lName
   User.bio = this.updateUserData.bio
   User.password = this.updateUserData.newPassword

    this.userService.updateUser(User).subscribe(elem => console.log(elem))

  }


  updateReviewData = {
    grade: 0,
    id: 0,
    description : ""
  }

  setReviewData(index : number) {
    this.showUpdateText = false
    let rev = this.UserToDisplay.reviews[index]
    this.updateReviewData.grade = rev.grade
    this.updateReviewData.description = rev.description
    this.updateReviewData.id = rev.id

  }

  showUpdateText = false

  updateReview() {
    let rev = new UpReview() 

    rev.id = this.updateReviewData.id
    rev.description = this.updateReviewData.description
    rev.grade = this.updateReviewData.grade

    this.userService.updateReview(rev).subscribe(elem => {console.log(elem)
       this.showUpdateText = true})
  }



  deleteReview(id : number) {
    
    console.log("Deleting")
      this.userService.deleteReview(id)
    
  }

  searchData : User[] = []

  searchField = ""

  search() {
this.searchData = this.Users.filter(x =>  (x.username.toLowerCase().includes(this.searchField.toLowerCase())))
    console.log(this.searchData);
  }
}
