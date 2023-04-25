import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetallprodsService } from '../Services/getallprods.service';

@Component({
  selector: 'app-searchforprod',
  templateUrl: './searchforprod.component.html',
  styleUrls: ['./searchforprod.component.scss']
})
export class SearchforprodComponent {

  searcha: string='';
  prods: any[] = [];
  

  constructor(private route: ActivatedRoute,private getall:GetallprodsService,private router: Router) {}

  ngOnInit() {
    

    this.route.queryParams.subscribe(params => {

      // Reload the component if the query parameters change
      

      console.log(this.route);
      console.log(this.route.snapshot.params['queryParams']);
      this.searcha=this.route.snapshot.params['queryParams'];

      this.getall.search(this.searcha).subscribe(data => {
        this.prods = data;
        console.log(this.prods);
      });



    });

  }
}
