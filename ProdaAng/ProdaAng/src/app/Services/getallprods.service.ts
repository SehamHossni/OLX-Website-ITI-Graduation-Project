import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { data } from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class GetallprodsService {

  private apiUrl = 'https://localhost:44327/api/Product';
  private catapiUrl = 'https://localhost:44327/api/Product?CategoryId=';

  constructor(private http: HttpClient) { }

  
  
  getall(): Observable<any[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map(response => response.data)
    );
  }

  search(search:string): Observable<any[]> {
    const apiurla="https://localhost:44327/api/Product?Search="+ search;
    return this.http.get<any>(apiurla).pipe(
      map(response => response.data)
    );
  }


  getvendorprods(vendormail:string): Observable<any[]> {
    const apiurla="https://localhost:44327/VendorProfile?vendorname="+ vendormail;
    return this.http.get<any>(apiurla).pipe(
      map(response => response.data)
    );
  }


  getprodalbum(prodid:any): Observable<any[]> {
    const apiurla="https://localhost:44327/products/images/"+ prodid;
    return this.http.get<any>(apiurla).pipe(
      map(response => response)
    );
  }


  deleteprod(prodid:string): Observable<any> {
    
    const apiurla="https://localhost:44327/api/Product/"+ prodid;
    return this.http.delete(apiurla);
  }


  getsingleProdBy(id: string): Observable<any> {
    const url = "https://localhost:44327/api/Product/"+id;
    return this.http.get<any>(url).pipe(
      map(response => response)
    );
  }


  

  getProdsBycatId(catId: string): Observable<any[]> {
    const url = this.catapiUrl+catId.toString();
    return this.http.get<any[]>(url).pipe(
      map((response) => {
        // Filter the comments array to only include those with a matching userId
        const matchingComments = response.filter((data) => data.productCategoryId === catId);
        return matchingComments;
      })
    );
  }

}
  

