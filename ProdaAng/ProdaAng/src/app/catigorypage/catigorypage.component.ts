import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetallprodsService } from '../Services/getallprods.service';


@Component({
  selector: 'app-catigorypage',
  templateUrl: './catigorypage.component.html',
  styleUrls: ['./catigorypage.component.scss']
})
export class CatigorypageComponent {


  id: string ='';
  prods: any[] = [];
  filtrprod:any[]=[];
  catigoryname:string='';

  constructor(private route: ActivatedRoute,private getall:GetallprodsService) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      // Do something with the ID here

      this.getall.getall().subscribe(data => {
        this.prods = data;
        console.log("in function");
        console.log(this.prods);
        console.log(this.id)
        this.filtrprod = this.prods.filter((item) => item.productCategoryId == this.id);

        this.catigoryname=this.filtrprod[0].productCategory;
        console.log("aftr filtr");
        console.log(this.filtrprod);

      });

      

      
      
    });
  }

}
