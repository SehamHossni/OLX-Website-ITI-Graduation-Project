import { Component,Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetallprodsService } from '../Services/getallprods.service';
import { GetvendorinfoService } from '../Services/getvendorinfo.service';

@Component({
  selector: 'app-vendorprofile',
  templateUrl: './vendorprofile.component.html',
  styleUrls: ['./vendorprofile.component.scss']
})
export class VendorprofileComponent {
  email: string ='';
  vendor:any;
  prods: any[] = [];
  

  constructor(private route: ActivatedRoute,private getall:GetallprodsService,private getven:GetvendorinfoService,@Inject("window") private window: Window) {}

  ngOnInit(): void {
    
    this.route.params.subscribe((params) => {
      this.email = params['email'];
      console.log(this.email);
      //do some

      this.getven.getvendor(this.email).subscribe(data => {
        this.vendor = data;
        console.log(this.vendor);
      });



    });


    this.getall.getvendorprods(this.email).subscribe(data => {
      this.prods = data;
      console.log(this.prods);
    });

    
  }


  copyPage() {
    // Get the current page URL
    const pageUrl = window.location.href;
  
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

}
