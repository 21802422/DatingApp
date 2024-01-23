import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
 baseUrl = 'http://localhost:5283/api'

  constructor(private Http: HttpClient){}

  ngOnInit(): void {   
  }
   get404Error(){
    this.Http.get(this.baseUrl + 'buggy/not-found').subscribe({
      next: Response => console.log(Response),
      error: error => console.log(error)
    })
   }

   get400Error(){
    this.Http.get(this.baseUrl + 'buggy/bad-request').subscribe({
      next: Response => console.log(Response),
      error: error => console.log(error)
    })
   }

   get500Error(){
    this.Http.get(this.baseUrl + 'buggy/server-error').subscribe({
      next: Response => console.log(Response),
      error: error => console.log(error)
    })
   }

   get401Error(){
    this.Http.get(this.baseUrl + 'buggy/auth').subscribe({
      next: Response => console.log(Response),
      error: error => console.log(error)
    })
   }
   get400ValidationError(){
    this.Http.post(this.baseUrl + 'account/register',{}).subscribe({
      next: Response => console.log(Response),
      error: error => console.log(error)
    })
   }

}
