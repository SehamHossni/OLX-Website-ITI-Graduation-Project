import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetallcatigoriesService {

  private apiUrl = 'https://localhost:44327/api/Product/categories';

  constructor(private http: HttpClient) { }

  getall(): Observable<any[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map(response => response)
    );
  }
}
