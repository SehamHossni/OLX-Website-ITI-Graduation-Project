import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetallprodsService } from '../Services/getallprods.service';

@Component({
  selector: 'app-updateprodinfo',
  templateUrl: './updateprodinfo.component.html',
  styleUrls: ['./updateprodinfo.component.scss']
})
export class UpdateprodinfoComponent {
  id:string='';
constructor(private route: ActivatedRoute,private getall:GetallprodsService){}
ngOnInit(): void {
  this.route.params.subscribe((params) => {
    this.id = params['id'];
    // Do something with the ID here

    

    

    
    
  });
  
}
}
