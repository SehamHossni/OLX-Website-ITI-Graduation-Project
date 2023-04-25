import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommentService } from './comment.service';


@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent {

  form!:FormGroup
  constructor(private build:FormBuilder ,private service:CommentService){}

  ngOnInit():void{
    this.form=this.build.group({
      id: ['',Validators.required],
      email: ['',Validators.required],
      content: ['',Validators.required],
      productID: ['',Validators.required],
    })
  }
  addCOMMENT(){

    
    const model=this.form.value
    console.log(model)
    this.service.createcomment(model).subscribe(res =>{
      console.log(this.form.value)
     alert("add success")
    })

  }

}
