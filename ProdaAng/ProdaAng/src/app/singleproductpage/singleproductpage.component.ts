import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../authservice/auth.service';
import { CommentService } from '../comment/comment.service';
import { ChatservicesService } from '../Services/chatservices.service';
import { GetallprodsService } from '../Services/getallprods.service';
import { GetmyaccountinformationService } from '../Services/getmyaccountinformation.service';

@Component({
  selector: 'app-singleproductpage',
  templateUrl: './singleproductpage.component.html',
  styleUrls: ['./singleproductpage.component.scss']
})
export class SingleproductpageComponent {
  id:string='';
  catid:string='';
  product:any;
  prods: any[] = [];
  filtrprod:any[]=[];
  catigoryname:string='';
  form!:FormGroup;
  currentuser:any;
  token:any;
  twoTokens:any;
  publishermail:string='';
  chatid:any;
  album:any;

  constructor(private auth:AuthService,private getma:GetmyaccountinformationService,private service:CommentService,private build:FormBuilder,private route: ActivatedRoute,private getall:GetallprodsService,private chat:ChatservicesService){}

  
ngOnInit(): void {
   this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.token;

  this.form=this.build.group({
    id: ['',Validators.required],
    email: ['',Validators.required],
    content: ['',Validators.required],
    productID: ['',Validators.required],
  })
  this.route.params.subscribe((params) => {
    this.id = params['id'];
    // Do something with the ID here
    console.log(this.id);

    this.getall.getsingleProdBy(this.id).subscribe(data => {
      this.product = data;
      console.log(this.product);
      this.catid=this.product.productCategoryId;
      this.publishermail=this.product.publisher;


      this.getall.getprodalbum(this.id).subscribe(data => {
        this.album = data;
        console.log("Those are all my pictures");
        console.log(data);
        
      });
      


      


      this.getall.getall().subscribe(data => {
        this.prods = data;
        console.log("in function");
        console.log(this.prods);
        console.log(this.catid)
        this.filtrprod = this.prods.filter((item) => item.productCategoryId == this.catid);
  
        this.catigoryname=this.filtrprod[0].productCategory;
        console.log("aftr filtr");
        console.log(this.filtrprod);



        this.chat.getuserbymail(this.publishermail).subscribe(data => {
          this.chatid=data;
          console.log("This is how you can contact me******")
          console.log(this.chatid);
          
  
        });
      });

    });

    
    

    

    
    
  });
  
}

addCOMMENT(){
  this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.token;

  this.getma.getProtectedResource(this.token).subscribe(data => {
    this.currentuser = data;
    console.log(this.currentuser);
  


    this.form.controls['id'].setValue('0');
  this.form.controls['email'].setValue(this.currentuser.email);
  this.form.controls['productID'].setValue(this.id);
  const model=this.form.value
  console.log("This is what i sent");
  console.log(model)
  if(model.content==""){}
  else{
    console.log("iiiiiiiiiinnnnnn");
    this.service.createcomment(model).subscribe(res =>{
      console.log(this.form.value)
      console.log("Commented Succefully");
     //alert("add success")
     location.reload()
  
    })
  }
  


  });
  
  

}


}
