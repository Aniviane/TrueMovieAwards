import { formatCurrency } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from './Models/User';
import { UserLogin } from './Models/UserLogin';
import { UserService } from './Services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TrueMovieAwards';

  loginForm = new FormGroup({
    Username : new FormControl("",Validators.required),
    Password : new FormControl("",Validators.required)
  })


  registerForm = new FormGroup({
    Username : new FormControl("", Validators.required),
    Password: new FormControl("", Validators.required),
    FName : new FormControl("", Validators.required),
    LName : new FormControl("", Validators.required),
    EMail : new FormControl("",Validators.email),
    UType : new FormControl("General", Validators.required),
    UPhoto : new FormControl(""),
    Bio : new FormControl("")
  })

  constructor(private userService : UserService, private router:Router) {}
  register() : void{
    let user = new User()
    
    user.username = this.registerForm.get("Username")?.value ?? ""
    user.password = this.registerForm.get("Password")?.value ?? ""
    user.fName = this.registerForm.get("FName")?.value ?? ""
    user.lName = this.registerForm.get("LName")?.value ?? ""
    user.eMail = this.registerForm.get("EMail")?.value ?? ""
    user.uType = this.registerForm.get("UType")?.value ?? ""
    user.uPhoto = this.registerForm.get("UPhoto")?.value ?? ""
    user.bio = this.registerForm.get("Bio")?.value ?? ""

    console.log(user)
    console.log("vidi me")

    const ret = this.userService.register(user);
    ret.subscribe(elem => {
      console.log(elem)
    }

    )
    console.log("proso reg")
  }

  loggedIn : boolean = false

  login() : void {
    let logindata = new UserLogin()
    logindata.username = this.loginForm.get("Username")?.value ?? ""
    logindata.password = this.loginForm.get("Password")?.value ?? ""

    console.log("Vidi i mene")

    let ret = this.userService.login(logindata);
    ret.subscribe(elem => {
      
      localStorage.setItem("token",elem.token)
      localStorage.setItem("Id",elem.id.toString())
      localStorage.setItem("UserType", elem.uType)
      console.log(elem)
    })
    this.loggedIn = true
    this.router.navigate([""])
    console.log("login proso")
  }

  amIModerator() : boolean {
    if(localStorage.getItem("UserType") == "Moderator") return true
    return false
  }

  amIAdmin() : boolean {
    if(localStorage.getItem("UserType") == "Admin") return true
    return false
  }

  amIGeneral() : boolean {
    if(localStorage.getItem("UserType") == "General") return true
    return false
  }

  showMyProfile() {
    let id = localStorage.getItem("Id")
    if(id)
      this.router.navigate(["Users/" + id])
  }

  logOut() : void {
    localStorage.setItem("token", "")
    localStorage.setItem("Id", "")
    localStorage.setItem("UserType", "No User")
    this.loggedIn = false
    this.router.navigate([""])
  }
}
