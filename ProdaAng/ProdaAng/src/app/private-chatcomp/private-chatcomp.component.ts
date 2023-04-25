import { Component } from '@angular/core';
import { AuthService } from '../authservice/auth.service';
import { ActivatedRoute } from '@angular/router';
import { ChatservicesService } from '../Services/chatservices.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-private-chatcomp',
  templateUrl: './private-chatcomp.component.html',
  styleUrls: ['./private-chatcomp.component.scss']
})
export class PrivateChatcompComponent {

  id!: number;
  twoTokens:any='';
  token:string='';
  messages:any[]=[];
  currentuser:any;
  form!:FormGroup;
  userid:number=0;
  

  constructor(private build:FormBuilder,private chatserv:ChatservicesService,private route: ActivatedRoute,private auth:AuthService){}

  ngOnInit(): void {
    this.form=this.build.group({
      toUserId: ['',Validators.required],
      message: ['',Validators.required],
    })
    this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.chattoken;
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      console.log(this.id);

      this.chatserv.GetUsermessages(this.id,this.token).subscribe(data => {
        this.messages=data as any[];
        console.log(this.messages);

        this.chatserv.GetCurrentUser(this.token).subscribe(dato => {
          this.currentuser=dato;
          this.userid=this.currentuser.id;
          console.log("This user ID");
          console.log(this.userid);
          

        });
  
        
      });


    });
    
  }



  sendMessage(){

    this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.chattoken;
    this.form.controls['toUserId'].setValue(this.id);
    const model=this.form.value
    console.log("This is what I see");
    console.log(model);
    this.chatserv.postMessage(model,this.token).subscribe(res =>{
      console.log(this.form.value)
      console.log("Sent Succefully");
     location.reload()
  
    })


  }

}
