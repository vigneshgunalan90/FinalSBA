import { throwError } from 'rxjs'
import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppHttpService {

  constructor() { }

  public handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {     
      console.error('An error occurred:', error.error.message);
    } else {      
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }    
    return throwError(
      'Something bad happened; please try again later.');
  }

  public log(message: string) {
    console.log(message);
  }

}
