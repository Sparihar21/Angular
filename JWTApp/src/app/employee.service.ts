import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  constructor(private httpClient:HttpClient) { }
 getAll():Observable<any>{
   var currentUser={token:""};
   var headers=new HttpHeaders();
   var currentUserSession=sessionStorage.getItem("currentUser");
   if(currentUserSession!=null){
     currentUser=JSON.parse(currentUserSession);
     headers=headers.set("Authorization","Bearer "+currentUser.token);
   }
  return this.httpClient.get<any>("https://localhost:7066/api/Employee",{headers:headers});
 }
 AddEmployee(employee:Employee):Observable<any>{
  // var currentUser={token:""};
  //  var headers=new HttpHeaders();
  //  var currentUserSession=sessionStorage.getItem("currentUser");
  //  if(currentUserSession!=null){
  //    currentUser=JSON.parse(currentUserSession);
  //    headers=headers.set("Authorization","Bearer "+currentUser.token);
  //  }
  return this.httpClient.post<any>("https://localhost:7066/api/Employee",employee);//,{headers:headers});
 }
 UpdateEmployee(employee:Employee):Observable<any>{
  return this.httpClient.put<any>("https://localhost:7066/api/Employee",employee);
 }
 DeleteEmployee(id:number):Observable<any>{
  return this.httpClient.delete<any>("https://localhost:7066/api/Employee/"+id);
 }
}
