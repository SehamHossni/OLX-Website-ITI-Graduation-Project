import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-uploadimage',
  templateUrl: './uploadimage.component.html',
  styleUrls: ['./uploadimage.component.scss']
})
export class UploadimageComponent {

  prodid:any;
  constructor(private http: HttpClient,private route: ActivatedRoute){}

  ngOnInit(): void {
    this.prodid = this.route.snapshot.queryParamMap.get('prodctid');
    console.log("This is the prodId I have now");
    console.log(this.prodid);
    
  }


  onFileSelected(event: any) {
    const file = event.target.files[0];
    const formData = new FormData();
    formData.append('photo', file, file.name);
    formData.append('id',this.prodid.toString());
  
    this.http.post('https://localhost:44327/api/Product/uploadproductalbum', formData).subscribe((response) => {
      console.log('Image uploaded:', response);
    });
  
    
  }

}


