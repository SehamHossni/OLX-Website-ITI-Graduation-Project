import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { AuthService } from '../authservice/auth.service';
import { GetallprodsService } from '../Services/getallprods.service';

@Component({
  selector: 'app-homebody',
  templateUrl: './homebody.component.html',
  styleUrls: ['./homebody.component.scss']
})
export class HomebodyComponent {

  allthing:any;
  prods: any[] = [];
  token:any;
  p:number = 1;
  totalRecords:number = 0;
  constructor(private getall:GetallprodsService,private auth:AuthService){}

  ngOnInit() {
    
    this.getall.getall().subscribe(data => {
      this.prods = data;
      console.log(this.prods);
    });
    this.token=this.auth.gettoken();
  }


}
