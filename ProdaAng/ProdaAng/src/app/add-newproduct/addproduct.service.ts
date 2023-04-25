import { EnvironmentInjector, Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Token } from '@angular/compiler';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AddproductService {
private url:string="https://localhost:44327/api/Product"
  constructor(private http:HttpClient ,private rout:Router ) { }


  createproduct(model:any){
    return this.http.post<any>(`${this.url}`,model)
  }

}
