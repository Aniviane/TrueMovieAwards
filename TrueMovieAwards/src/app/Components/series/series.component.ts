import { Component, OnInit } from '@angular/core';
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
  constructor(private seriesService : SeriesService, private dom:DomSanitizer, private route:ActivatedRoute) { }
  Series : Series[] = []
  singleDataFlag: boolean = false
  singleSeries! : Series
  ngOnInit(): void {

    this.route.params.subscribe(params => {
      let id = +params['id']
      if(id) {
        console.log("found id : " + id)
      
        this.seriesService.getSerie(id).subscribe(elem =>{
          this.singleSeries = elem
          console.log("single serie:" + this.singleSeries)
          this.singleDataFlag = true
        })

      } else {
        this.singleDataFlag = false
        this.seriesService.getSeries().subscribe(elem => {
          this.Series = elem;
          
          console.log(this.Series)
        })
      }
    })
  }

 


}
