import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ActorService } from './Services/actor.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StarterComponent } from './Components/starter/starter.component';
import { UserService } from './Services/user.service';
import { TokenInterceptorInterceptor } from './Services/token-interceptor.interceptor';
import { MovieComponent } from './Components/movie/movie.component';
import { ActorComponent } from './Components/actor/actor.component';
import { ProducerComponent } from './Components/producer/producer.component';
import { UserComponent } from './Components/user/user.component';
import { RouterModule } from '@angular/router';
import { FestivalComponent } from './Components/festival/festival.component';
import { SeriesComponent } from './Components/series/series.component';
import { StudioComponent } from './Components/studio/studio.component';
import { GenreComponent } from './Components/genre/genre.component';
import { MovieCreateComponent } from './Components/movie-create/movie-create.component';
import { AwardComponent } from './Components/award/award.component';

@NgModule({
  declarations: [
    AppComponent,
    StarterComponent,
    MovieComponent,
    ActorComponent,
    ProducerComponent,
    UserComponent,
    FestivalComponent,
    SeriesComponent,
    StudioComponent,
    GenreComponent,
    MovieCreateComponent,
    AwardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [ActorService, UserService, {provide: HTTP_INTERCEPTORS,useClass: TokenInterceptorInterceptor,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
