import { HttpClient } from '@angular/common/http';
import { Component,Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../authservice/auth.service';
import { GetallprodsService } from '../Services/getallprods.service';
import { GetmyaccountinformationService } from '../Services/getmyaccountinformation.service';
import { GetvendorinfoService } from '../Services/getvendorinfo.service';

@Component({
  selector: 'app-myaaccountpage',
  templateUrl: './myaaccountpage.component.html',
  styleUrls: ['./myaaccountpage.component.scss']
})
export class MyaaccountpageComponent {
  token:any='';

  accountinfo:any;
  vendor:any;
  prods: any[] = [];
  email:string='';
  twoTokens:any;

  constructor(private http: HttpClient,private getall:GetallprodsService,private getma:GetmyaccountinformationService,private getven:GetvendorinfoService,@Inject("window") private window: Window,private auth:AuthService){}
  ngOnInit(): void {
    this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.token;
    this.getma.getProtectedResource(this.token).subscribe(data => {
      this.accountinfo = data;
      console.log(this.accountinfo);

      this.getven.getvendor(this.accountinfo.email).subscribe(data => {
        this.vendor = data;
        console.log("AsVendor Info");
        console.log(this.vendor);
        this.email=this.vendor.email;

        this.getall.getvendorprods(this.email).subscribe(data => {
          this.prods = data;
          console.log(this.prods);
        });
      });

      
    });

    
    

    
    
  }


  copyPage() {
    // Get the current page URL without paths
  const pageUrl = window.location.origin+ "/sellerInfo/"+this.accountinfo.email;;

  // Create a temporary input element
  const inputElement = document.createElement("input");

  // Set the value of the input element to the page URL
  inputElement.setAttribute("value", pageUrl);

  // Add the input element to the document
  document.body.appendChild(inputElement);

  // Select the text in the input element
  inputElement.select();

  // Copy the selected text to the clipboard
  document.execCommand("copy");

  // Remove the input element from the document
  document.body.removeChild(inputElement);
  }


  onDeleteItem(itemId: string): void {
    if (confirm('Are you sure you want to delete this item?')) {
      this.http.delete('https://localhost:44327/api/Product/'+itemId)
      .subscribe({
          next: data => {
              console.log("Delete Sucess");
              location.reload();

          },
          error: error => {
              
              console.error(error);
          }
      });
  }

  }

}
