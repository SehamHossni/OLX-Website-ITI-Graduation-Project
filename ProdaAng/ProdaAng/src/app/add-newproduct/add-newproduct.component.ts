import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../authservice/auth.service';
import { GetallcatigoriesService } from '../Services/getallcatigories.service';
import { GetmyaccountinformationService } from '../Services/getmyaccountinformation.service';
import { AddproductService } from './addproduct.service';

@Component({
  selector: 'app-add-newproduct',
  templateUrl: './add-newproduct.component.html',
  styleUrls: ['./add-newproduct.component.scss']
})
export class AddNewproductComponent {
  base64:any=''
  form!:FormGroup
  cats :any[]=[];
  currentuser:any;
  twoTokens:any='';
  token:any;
constructor(private router: Router,private http: HttpClient,private getma:GetmyaccountinformationService,private auth:AuthService,private build:FormBuilder ,private service:AddproductService,private getall:GetallcatigoriesService){}

ngOnInit():void{

  this.getall.getall().subscribe(data => {
    this.cats = data;
    console.log(this.cats);
  });

  // get name(){
  //   return this.form.get('name')
  // }
  this.form=this.build.group({
    name: ['',Validators.required],
    description: ['',Validators.required],
    publisher: ['',Validators.required],
    price: ['',Validators.required],
    pictureUrl: ['',Validators.required],
    productCategoryId:['',Validators.required],
    productTypeId: ['',Validators.required]
  })




}


onFileSelected(event: any) {
  const file = event.target.files[0];
  const formData = new FormData();
  formData.append('photo', file, file.name);

  this.http.post('https://localhost:44327/api/Product/uploadproductphoto', formData).subscribe((response) => {
    console.log('Image uploaded:', response);
    this.form.controls['pictureUrl'].setValue((response as any).fullman);
    console.log(this.form.controls['pictureUrl'].value);
  });


}



  addproduct(){

    this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.token;
    this.getma.getProtectedResource(this.token).subscribe(data => {
      this.currentuser = data;
      console.log(this.currentuser);
      this.form.controls['publisher'].setValue(this.currentuser.email);
      this.form.controls['productTypeId'].setValue(1);

      const model=this.form.value;
      console.log("This is what was sent");
      console.log(model);
    this.service.createproduct(model).subscribe(res =>{
      console.log(this.form.value)
      this.router.navigate(['/uploadalbums'], { queryParams: { prodctid: res.id } });
      //this.router.navigateByUrl('/product/uploadalbums/');
    })
    console.log(this.form)

    });




  }






}
