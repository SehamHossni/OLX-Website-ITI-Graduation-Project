import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { data } from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class ChatservicesService {

  private apiUrl = 'https://localhost:44330/api/Users/chats';
  constructor(private http: HttpClient) { }

  getallchats(token: string) {
    const headers = new HttpHeaders()
      .set('Authorization', `Bearer ${token}`);
    return this.http.get(this.apiUrl, { headers });
  }

  GetUsermessages(userid:number,token: string) {
    let apiUrla = 'https://localhost:44330/api/Messages/'+userid.toString();
    const headers = new HttpHeaders()
      .set('Authorization', `Bearer ${token}`);
    return this.http.get(apiUrla, { headers });
  }

  GetCurrentUser(token: string) {
    let apiUrla = 'https://localhost:44330/api/Account/me'
    const headers = new HttpHeaders()
      .set('Authorization', `Bearer ${token}`);
    return this.http.get(apiUrla, { headers });
  }

  getuserbymail(email:string): Observable<any> {
    let apiUrla = 'https://localhost:44330/api/Account/getuser?email='+email;
    return this.http.get<any>(apiUrla).pipe(
      map(response => response)
    );
  }



  postMessage(formData: any, token: string): Observable<any> {
    let apiUrla = 'https://localhost:44330/api/Messages'
    const headers = new HttpHeaders()
    .set('Authorization', `Bearer ${token}`);
    return this.http.post<any>(apiUrla, formData, { headers });
  }



}
