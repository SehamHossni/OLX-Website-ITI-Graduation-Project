import { Component } from '@angular/core';
import {FormBuilder,FormGroup ,Validators,FormControl} from '@angular/forms'
import { Router } from '@angular/router';
import { AuthService } from '../authservice/auth.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private fb: FormBuilder,private auth:AuthService, private router:Router){}
  loginform!:FormGroup;
  chatForm!:FormGroup;
  get password(){
    return this.loginform.get('password')
  }
  get email(){
    return this.loginform.get('email')
  }
  ngOnInit(): void{
    this.loginform=this.fb.group({
      email:['',Validators.required],
      password:['',Validators.required]
    })

    this.chatForm=this.fb.group({
      username:[''],
      password:['']
    })
  }

  onlogin(){
    if(this.loginform.valid){
      // console.log(this.loginform.value)
      this.auth.login(this.loginform.value)
      .subscribe({
        next:(res)=>{
          // alert(res.message);

          this.chatForm.controls['username'].setValue(this.loginform.controls['email'].value);
          this.chatForm.controls['password'].setValue(this.loginform.controls['password'].value);
          console.log(this.chatForm.value);
          this.loginform.reset();



          this.auth.loginforchat(this.chatForm.value).subscribe(
            {
              next:(resa)=>{

                this.auth.storetoken(res.token,resa.token);
                this.router.navigate(['home'])
              }
            }
          )




        },
        error:(err)=>{
          alert(err?.error.message)
        }
      })
    }else{
      // console.log("form is not valid")
      this.validdataallformfileds(this.loginform)

      alert("your form is not valid")
    }
  }

  private validdataallformfileds(formgrob:FormGroup){
    Object.keys(formgrob.controls).forEach(field=>{
      const control =formgrob.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true});
      }else if (control instanceof FormGroup){
        this.validdataallformfileds(control)
      }
    })
  }
}
