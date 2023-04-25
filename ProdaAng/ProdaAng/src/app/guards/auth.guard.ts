import { Injectable } from '@angular/core';
import {  CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../authservice/auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth:AuthService,private router:Router){}
  canActivate( ):boolean{
    if(this.auth.islogin()){
      return true;
    }else{
      this.router.navigate(['login'])
      return false;
    }

  }

}
