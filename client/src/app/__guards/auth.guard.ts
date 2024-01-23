import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const accountServices = inject(AccountService);
  const toastr = inject(ToastrService);


  return accountServices.currentUser$.pipe(
    map(user => {
      if (user) return true;
      else{
       toastr.error('you shall not pass!');
       return false;
      }
    })
  )
};
