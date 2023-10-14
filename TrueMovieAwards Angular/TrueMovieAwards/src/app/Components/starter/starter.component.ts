import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs/internal/Observable';
import { Actor } from 'src/app/Models/Actor';

@Component({
  selector: 'app-starter',
  templateUrl: './starter.component.html',
  styleUrls: ['./starter.component.css']
})
export class StarterComponent implements OnInit {

  constructor() { }
  Actors! : Observable<Actor[]> 
  ngOnInit(): void {
    
  }

}
