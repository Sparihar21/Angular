import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  constructor(private router:Router){}
// ngOnInit(){
//   if(sessionStorage.getItem("currentUser")==null){
//   alert("You are not authorizedd");
//   this.router.navigateByUrl("/login");
//   }
// }
}
