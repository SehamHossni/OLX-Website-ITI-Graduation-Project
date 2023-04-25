import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Token } from '@angular/compiler';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseurl:string="https://localhost:44327/api/Account/"
  private chatApiUrl:string="https://localhost:44330/api/Account/"

  constructor(private http:HttpClient ,private rout:Router) { }

 register(userobj:any){
  return this.http.post<any>(`${this.baseurl}register`,userobj)
 }

 registerforchat(userobj:any){
  return this.http.post<any>(`${this.chatApiUrl}register`,userobj)
 }

 login(loginobj:any){
  return this.http.post<any>(`${this.baseurl}login`,loginobj)
 }

 loginforchat(loginobj:any){
  return this.http.post<any>(`${this.chatApiUrl}login`,loginobj)
 }
 signout(){
  localStorage.clear();
  this.rout.navigate(['login'])
 }

 storetoken(Tokenvalue:string,TokenChat:string){
  localStorage.setItem('token',Tokenvalue)
  localStorage.setItem('chatToken',TokenChat)
 }

 gettoken(){
  let token = localStorage.getItem('token');
  let chattoken =localStorage.getItem('chatToken');
  return {token,chattoken};

 }

 islogin():boolean{
  return !!localStorage.getItem('token')
 }
}
