import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GetallcatigoriesService } from 'src/app/Services/getallcatigories.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {

  cats:any[]=[];

  constructor(private router: Router,private getall:GetallcatigoriesService){}

  ngOnInit() {

    this.getall.getall().subscribe(data => {
      this.cats = data;
      
    });

  }

}
