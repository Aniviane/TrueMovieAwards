import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Series } from 'src/app/Models/Series';
import { SeriesService } from 'src/app/Services/series.service';

@Component({
  selector: 'app-series',
  templateUrl: './series.component.html',
  styleUrls: ['./series.component.css']
})
export class SeriesComponent implements OnInit {
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


  seriesForm = new FormGroup({
    name : new FormControl("", Validators.required)
  })

  constructor(private seriesService : SeriesService, private dom:DomSanitizer, private route:ActivatedRoute) { }
  Series : Series[] = []
  singleDataFlag: boolean = false
  singleSeries! : Series
  ngOnInit(): void {
    this.userType = localStorage.getItem("UserType") ?? ""
    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
      
        this.seriesService.getSerie(id).subscribe(elem =>{
          this.singleSeries = elem
          console.log("single serie:")
          console.log(this.singleSeries)
          this.singleDataFlag = true
        })

      } else {
        this.singleDataFlag = false
        this.seriesService.getSeries().subscribe(elem => {
          this.Series = elem;
          this.searchData = elem;
          
          console.log(this.Series)
        })
      }
    })
  }

 
  onSubmit() {
    let series = new Series()

    series.fName = this.seriesForm.get("name")?.value ?? ""

    this.seriesService.addSeries(series).subscribe(elem => this.Series.push(elem))
  }


  
  updateSeriesName = ""

  setSeriesName() {
    this.updateSeriesName = this.singleSeries.fName
  }

  updateSeries() {
    let Series = this.singleSeries
 
    Series.fName = this.updateSeriesName

    this.seriesService.updateSeries(Series).subscribe(elem => console.log(elem))


  }

  searchData : Series[] = []

  searchField = ""

  search() {
this.searchData = this.Series.filter(x =>  (x.fName.toLowerCase().includes(this.searchField.toLowerCase())))
    console.log(this.searchData);
  }

}
