import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Token } from '@angular/compiler';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private url1:string="https://localhost:44327/api/Comment"
  constructor(private http:HttpClient ,private rout:Router ) { }


  createcomment(model:any){
    return this.http.post<any>(`${this.url1}`,model)
  }
}
