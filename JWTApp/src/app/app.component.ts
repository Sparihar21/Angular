import { Component } from '@angular/core';
import { LoginService } from './login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'JWTApp';
  constructor(public loginServices:LoginService){}
  LogOutClick(){
    this.loginServices.Exit();
  }
}
