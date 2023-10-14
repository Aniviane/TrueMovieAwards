import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActorComponent } from './Components/actor/actor.component';
import { MovieComponent } from './Components/movie/movie.component';
import { ProducerComponent } from './Components/producer/producer.component';
import { UserComponent } from './Components/user/user.component';
import { SeriesComponent } from './Components/series/series.component';
import { StudioComponent } from './Components/studio/studio.component';
import { GenreComponent } from './Components/genre/genre.component';
import { FestivalComponent } from './Components/festival/festival.component';
import { MovieCreateComponent } from './Components/movie-create/movie-create.component';
import { AwardComponent } from './Components/award/award.component';

const routes: Routes = [  
  {path:"Actors", component: ActorComponent},
  {path:"Actors/:id", component: ActorComponent},
  {path:"Awards", component: AwardComponent},
  {path:"Awards/:id", component: AwardComponent},
  {path:"Movies", component: MovieComponent},
  {path:"Movies/:id", component: MovieComponent},
  {path:"AddMovie", component: MovieCreateComponent},
  {path:"Producers", component: ProducerComponent},
  {path:"Producers/:id", component: ProducerComponent},
  {path:"Users", component: UserComponent},
  {path:"Users/:id", component: UserComponent},
  {path:"Series", component: SeriesComponent},
  {path:"Series/:id", component: SeriesComponent},
  {path:"Studios", component: StudioComponent},
  {path:"Studios/:id", component: StudioComponent},
  {path:"Genres", component: GenreComponent},
  {path:"Genres/:id", component: GenreComponent},
  {path:"Festivals", component: FestivalComponent},
  {path:"Festivals/:id", component: FestivalComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
