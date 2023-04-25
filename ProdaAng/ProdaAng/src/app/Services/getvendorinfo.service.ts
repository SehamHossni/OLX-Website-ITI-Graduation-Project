import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { data } from 'jquery';



@Injectable({
  providedIn: 'root'
})
export class GetvendorinfoService {

  private apiUrl = 'https://localhost:44327/api/Account/userinfo?email=';

  constructor(private http: HttpClient) { }

  getvendor(email:string): Observable<any[]> {
    const apiurla=this.apiUrl+ email;
    return this.http.get<any>(apiurla).pipe(
      map(response => response)
    );
  }

}
