import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.scss'
})
export class EmployeeComponent {
  
  employeeList:Employee[]=[];
  newEmployee:Employee=new Employee();
  updateEmployee:Employee=new Employee();
constructor(private router:Router,private employeeServices:EmployeeService){}
ngOnInit(){
  // if(sessionStorage.getItem("currentUser")==null){
  //   alert("You are not auythorzie to this page");
  //   this.router.navigateByUrl("/login");
  // }
  this.getAll();
}
getAll(){
  this.employeeServices.getAll().subscribe(
    (res)=>{this.employeeList=res;},
    (err)=>{console.log(err);}
  )
}
SaveButtonhaiye(){
  this.employeeServices.AddEmployee(this.newEmployee).subscribe(
    (res)=>{this.getAll();},
    (err)=>{console.log(err)}
  )
  }
Editicon(employeekidetails:any){
  this.updateEmployee=employeekidetails;
}
updatedEmployee(){
  this.employeeServices.UpdateEmployee(this.updateEmployee).subscribe(
    (res)=>{this.getAll();},
    (err)=>{console.log(err)}
  )
}
DeleteEmployee(id:number){
  let ans=window.confirm("Do you really want to delete")
  if(!ans) return;
  this.employeeServices.DeleteEmployee(id).subscribe(
    (res)=>{this.getAll()},
    (err)=>{console.log(err)}
  )
}
}
