import { Component } from '@angular/core';
import { AuthService } from '../authservice/auth.service';
import { ChatservicesService } from '../Services/chatservices.service';
@Component({
  selector: 'app-chatshomeall',
  templateUrl: './chatshomeall.component.html',
  styleUrls: ['./chatshomeall.component.scss']
})
export class ChatshomeallComponent {
  token:string='';
  twoTokens:any;
  chats:any[]=[];


  constructor(private chatserv:ChatservicesService,private auth:AuthService){}
  ngOnInit(): void {
    this.twoTokens=this.auth.gettoken();
    this.token=this.twoTokens.chattoken;

    this.chatserv.getallchats(this.token).subscribe(data => {
      this.chats=data as any[];
      console.log(this.chats);

      
    });
    
  }
}
