import { Component } from '@angular/core';
import { Login } from '../login';
import { LoginService } from '../login.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
user:Login=new Login();
constructor(private loginservicess:LoginService,private router:Router){}
loginCheck(){
  //alert(this.user.username);
  this.loginservicess.checkUser(this.user).subscribe(
    (response)=>{
      this.router.navigateByUrl("/home");
    },
    (err)=>{
      console.log(err);
      this.user.username="";
      this.user.password="";
    }
  )
}
}
