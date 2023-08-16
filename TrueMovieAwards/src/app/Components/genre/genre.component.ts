import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {

  constructor() { }
  @Input() num! : number
  ngOnInit(): void {
    console.log(this.num)
    console.log("hello from modal")
  }

}
