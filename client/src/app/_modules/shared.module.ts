import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [],
  imports: [
    CommonModule, 
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toastr-bottom-centre'
    })
  ], 
  exports:[
    BsDropdownModule,
    ToastrModule
  ]
})
export class SharedModule { }
