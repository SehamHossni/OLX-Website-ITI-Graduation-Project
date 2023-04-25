import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { data } from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class GetmyaccountinformationService {
  private apiUrl = 'https://localhost:44327/api/Account';

  constructor(private http: HttpClient) { }

  getProtectedResource(token: string) {
    const headers = new HttpHeaders()
      .set('Authorization', `Bearer ${token}`);

    

    return this.http.get(this.apiUrl, { headers });
  }
}
