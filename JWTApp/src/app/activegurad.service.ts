import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class ActiveguradService implements CanActivate
{

  constructor(private loginServicess:LoginService,private router:Router,private JwtHelperServicess:JwtHelperService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
      if(this.loginServicess.IsAuthenticated()){
            return true;
      }
      else{
        alert("you are not authorized");
        this.router.navigateByUrl("/login");
        return false;
      }
      
  }
}
