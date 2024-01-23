import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
 registerMode=false;
 users: any;
 readonly APIUrl = "http://localhost:5283/api"

constructor(private http: HttpClient){}

ngOnInit(): void { 
  this.getUsersList();
}
registerToggle(){
  this.registerMode=!this.registerMode;
}
getUsersList() {
  this.http.get(this.APIUrl + '/users').subscribe(data => {
    this.users = data;
    console.log(data)
  })
}
cancelRegisterMode(event: boolean){
  this.registerMode = event;
}
}
