import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Favorise } from 'src/app/Models/Favorise';
import { PartialAward } from 'src/app/Models/PartialAward';
import { Producer } from 'src/app/Models/Producer';
import { ProducerCreate } from 'src/app/Models/ProducerCreate';
import { ProducerService } from 'src/app/Services/producer.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-producer',
  templateUrl: './producer.component.html',
  styleUrls: ['./producer.component.css']
})
export class ProducerComponent implements OnInit {

  safeDefaultURL = this.dom.bypassSecurityTrustResourceUrl("/assets/Sample.jpg")
  makeMyUrlSafe(url : string): SafeUrl {
    
    if(url == "") return this.safeDefaultURL
    else
    return this.dom.bypassSecurityTrustUrl(url)
  }
  awardList : PartialAward[] = []
  
  producerForm = new FormGroup({
    fName : new FormControl("", Validators.required),
    lName: new FormControl("", Validators.required),
    doB : new FormControl(new Date, Validators.required),
    bio : new FormControl("", Validators.required),
    photo : new FormControl(""),
  })

  userType : string = ""

  amIModerator() : boolean {
    return this.userType == "Moderator"
  }


  addProducer() : void {
    let producer = new ProducerCreate()

    producer.fName = this.producerForm.get("fName")?.value ?? ""
    producer.lName = this.producerForm.get("lName")?.value ?? ""
    producer.bio = this.producerForm.get("bio")?.value ?? ""
    producer.doB = new Date(this.producerForm.get("doB")?.value ?? new Date)
    if(this.producerPhoto != null)
    producer.photo =  this.producerPhoto
     else 
    return
    
    this.producerService.addProducer(producer).subscribe(elem => {
      console.log(elem)
    })
  }

  constructor(private userService:UserService,private producerService : ProducerService, private dom:DomSanitizer, private route:ActivatedRoute) { }
  Producers : Producer[] = []
  singleDataFlag : boolean = false
  singleProducer : Producer = new Producer
  ngOnInit(): void {
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
        
        this.producerService.getProducer(id).subscribe(elem =>{
          this.singleProducer = elem
          this.awardList = []
          console.log("single producer:")
          console.log(this.singleProducer)
          elem.producings.forEach(producing =>
            {
              producing.producingAwards.forEach(award =>
                {
                  this.awardList.push(award)
                })
            })
          this.singleDataFlag = true
        })

      } else {
        this.singleDataFlag = false
        this.awardList = []
        this.producerService.getProducers().subscribe(elem => {
          this.Producers = elem;
          this.searchData = elem;
          console.log(this.Producers)
        })
      }
    })
  }


  amIGeneral() : boolean {
    if(localStorage.getItem("UserType") == "General") return true
    return false
  }


  favoriseProducer(id : number) {
    let data = new Favorise
    data.id = id
    data.mode = "Producer"
    this.userService.favorise(data)
  }

  producerPhoto = null

  onChange(event : any) {
    this.producerPhoto = event.target.files[0]
    console.log(this.producerPhoto)
  }

  
  updatePhoto = null
  updateProducerId = 0


  setProducerId(id : number) {
    this.updateProducerId = id;

  }

  onUpdateChange(event : any) {
    this.updatePhoto = event.target.files[0]
    console.log(this.updatePhoto)
    console.log(this.updateProducerId)
  }

  updateProducerPhoto() {
    let data : File
    if(this.updatePhoto != null) {
    data = this.updatePhoto
    this.producerService.updatePhoto(this.updateProducerId, data)
    console.log("sent request")
    } else
    console.log("Update failed, no photo")
  }




  updateProducerData = {
    fName : "",
    lName : "",
    bio : "",
    date : new Date,

  }

  setProducerData() {
    this.updateProducerData.fName = this.singleProducer.fName;
    
    this.updateProducerData.lName = this.singleProducer.lName;
    
    this.updateProducerData.bio = this.singleProducer.bio;
    
    this.updateProducerData.date = this.singleProducer.doB;
  }

  updateProducer() {
    if(this.updateProducerData.fName == "") {
      console.log("Empty first name")
      return
    }
    if(this.updateProducerData.lName == "") {
      console.log("Empty last name")
      return
    }
    if(this.updateProducerData.bio == "") {
      console.log("Empty bio")
      return
    }
   
    let Producer = this.singleProducer
    Producer.fName = this.updateProducerData.fName
    Producer.lName = this.updateProducerData.lName
    Producer.bio = this.updateProducerData.bio
    Producer.doB = this.updateProducerData.date

    Producer.producings = []
    
    console.log(Producer)
    this.producerService.updateProducer(Producer).subscribe(elem => console.log(elem))

  }

  gimmeDate(date:Date) : Date {
    return new Date(date)
  }

  searchData : Producer[] = []

  searchField = ""

  search() {
this.searchData = this.Producers.filter(x => (x.fName.toLowerCase().includes(this.searchField.toLowerCase()) || (x.lName.toLowerCase().includes(this.searchField.toLowerCase()))))
    console.log(this.searchData);
  }
}


