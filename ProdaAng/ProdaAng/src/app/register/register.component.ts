import { Component } from '@angular/core';
import {FormBuilder,FormGroup ,Validators,FormControl, ValidationErrors} from '@angular/forms'
import { Router } from '@angular/router';
import { AuthService } from '../authservice/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfirmPasswordValidator } from '../custom/confpassword';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private fb: FormBuilder,private auth:AuthService ,private router:Router){}
  registerform!:FormGroup;
  chatregisterform!:FormGroup;
  get password(){
    return this.registerform.get('password')
  }
  get displayName(){
    return this.registerform.get('displayName')
  }
  get firstName(){
    return this.registerform.get('firstName')
  }
  get lastName(){
    return this.registerform.get('lastName')
  }
  get email(){
    return this.registerform.get('email')
  }
  get phoneNumber(){
    return this.registerform.get('phoneNumber')
  }
  get zipCode(){
    return this.registerform.get('zipCode')
  }
  get city(){
    return this.registerform.get('city')
  }
  get country(){
    return this.registerform.get('country')
  }
  get street(){
    return this.registerform.get('street')
  }
  get confirmPassword(){
    return this.registerform.get('confiarmpassword')
  }
  ngOnInit(): void{
    this.registerform=this.fb.group({
      displayName:['',Validators.required],
      password:['',Validators.required],
      confirmPassword:['',Validators.required],
      lastName:['',Validators.required],
      firstName:['',Validators.required],
      email:['',Validators.required],
      phoneNumber:['',Validators.required],
      zipCode:['',Validators.required],
      city:['',Validators.required],
      country:['',Validators.required],
      street:['',Validators.required],
  },{validator:[ConfirmPasswordValidator]})


  this.chatregisterform=this.fb.group({
    name:[''],
    username:[''],
    password:[''],
})

}
// onregister(){
//   console.log("fsdfd");
//   if(this.registerform.valid){
//      console.log("valid")
//     this.auth.register(this.registerform.value)
//     .subscribe({
//       next:(res=>{
//         alert(res.message)
//       }),
//       error:(err=>{
//         alert(err?.error.message)
//       })
//     })
//   }else{
//      console.log("form is not valid")
//     this.validdataallformfileds(this.registerform)

//     // alert("your form is not valid")
//   }
// }
onregister(){
  if(this.registerform.valid){
    // console.log(this.loginform.value)
    console.log(this.registerform.value)
    this.auth.register(this.registerform.value)
    .subscribe({
      next:(res)=>{
        // alert(res.message)



        this.chatregisterform.controls['name'].setValue(this.registerform.controls['displayName'].value);
        this.chatregisterform.controls['username'].setValue(this.registerform.controls['email'].value);
        this.chatregisterform.controls['password'].setValue(this.registerform.controls['password'].value);

        console.log("This is the register form");
        console.log(this.registerform.value);
        console.log("This is the chat register form");
        console.log(this.chatregisterform.value);
        this.registerform.reset();
        this.auth.registerforchat(this.chatregisterform.value)
        .subscribe({
          next:(resa)=>{

          }
        })
        this.router.navigate(['login'])
      },
      error:(err)=>{
        alert(err?.error.message)
      }
    })
  }else{
    // console.log("form is not valid")
    this.validdataallformfileds(this.registerform)

    alert("your form is not valid");

    this.getFormValidationErrors();


  }
}

getFormValidationErrors() {
  console.log('%c ==>> Validation Errors: ', 'color: red; font-weight: bold; font-size:25px;');

  let totalErrors = 0;

  Object.keys(this.registerform?.controls ?? {}).forEach(key => {
    const controlErrors: ValidationErrors | null = this.registerform?.get(key)?.errors ?? null;
    if (controlErrors != null) {
       totalErrors++;
       Object.keys(controlErrors).forEach(keyError => {
         console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        });
    }
  });

  console.log('Number of errors: ' ,totalErrors);
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
