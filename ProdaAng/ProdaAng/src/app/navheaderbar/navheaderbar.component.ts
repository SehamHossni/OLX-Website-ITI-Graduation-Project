import { Component } from '@angular/core';
import 'popper.js';
import 'bootstrap';
import { GetallcatigoriesService } from '../Services/getallcatigories.service';
import { Router } from '@angular/router';
import { AuthService } from '../authservice/auth.service';
import { GetmyaccountinformationService } from '../Services/getmyaccountinformation.service';


@Component({
  selector: 'app-navheaderbar',
  templateUrl: './navheaderbar.component.html',
  styleUrls: ['./navheaderbar.component.scss']
})
export class NavheaderbarComponent {


  cats: any[] = [];
  twoTokens:any;
  token:any;
  user:any;
  constructor(private getma:GetmyaccountinformationService,private getall:GetallcatigoriesService,private router: Router ,private auth:AuthService){}

  ngOnInit() {
    this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.token;
    
    
    this.getall.getall().subscribe(data => {
      this.cats = data;
      console.log(this.cats);
    });

    this.getma.getProtectedResource(this.token).subscribe(data => {
      this.user = data;
      console.log(this.user);
    });

  }
  logout(){
    this.auth.signout();
  }

  onEnter(value: string) {
    // Route to another component with the value as a parameter
    this.router.navigate(['/search', { queryParams: value }]);
  }
}


