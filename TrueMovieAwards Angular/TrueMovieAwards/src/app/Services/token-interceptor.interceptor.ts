import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptorInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
   
    if(localStorage.getItem('token') != undefined) {

      const newrequest = request.clone({
       headers: request.headers.append('Authorization', 'bearer ' + localStorage.getItem("token"))
       
     })
     

   
    return next.handle(newrequest);
  } else {
    return next.handle(request.clone())
  }
}}
