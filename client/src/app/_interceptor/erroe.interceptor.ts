import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import {  NavigationExtras, Router } from '@angular/router';
import {  ToastrService } from 'ngx-toastr';

@Injectable()
export class ErroeInterceptor implements HttpInterceptor {
  toastr: any;

  constructor(private router: Router, toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if(error){
          switch (error.status){
            case 400:
              if(error.error.errors){
                const modelstateErrors=[];
                for (const key in error.error.errors)
                {
                  if(error.error.error[key]){
                    modelstateErrors.push(error.error.error[key])
                  }
                }
                throw modelstateErrors;
              } else{
                this.toastr.error(error.error, error.status)
              }
              break;
              case 401:
                this.toastr.error('Unauthorised', error.status);
                break; 
                case 404:
                  this.router.navigateByUrl('/not-found');
                  break;
                  case 500:
                    const navigationExtras: NavigationExtras  = { state: {error: error.error}};
                    this.router.navigateByUrl('/server-error', navigationExtras);
                    break;
                    default:
                      this.toastr.error('Something unexpected went wrong ');
                      console.log(error);
                       break;

          }
        }
        throw error;
        })
    )
    
  }
}
