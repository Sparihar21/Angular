import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from './login';
import { Observable,map } from 'rxjs';
import { Route, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  currentUserName:string="";
  constructor(private httpClient:HttpClient,private router:Router,private JwthelperService:JwtHelperService){ }
  checkUser(login:Login):Observable<any>{
    return this.httpClient.post<any>("https://localhost:7066/api/Account/Authenticate",login).pipe(map(u=>{
      if(u){
        this.currentUserName=u.username;
        sessionStorage["currentUser"]=JSON.stringify(u);
      }
      return null;
    }))
  }
  public IsAuthenticated():boolean{
    if (this.JwthelperService.isTokenExpired()){
      return false;
    }
    else{
      return true;
    }
  }
  Exit(){
    this.currentUserName="";
    sessionStorage.clear();
    this.router.navigateByUrl("/login");
    
  }
}
