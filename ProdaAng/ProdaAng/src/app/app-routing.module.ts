import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewproductComponent } from './add-newproduct/add-newproduct.component';
import { CatigorypageComponent } from './catigorypage/catigorypage.component';
import { ChatshomeallComponent } from './chatshomeall/chatshomeall.component';
import { CommentComponent } from './comment/comment.component';
import { AuthGuard } from './guards/auth.guard';
import { HomebodyComponent } from './homebody/homebody.component';
import { LoginComponent } from './login/login.component';
import { MyaaccountpageComponent } from './myaaccountpage/myaaccountpage.component';
import { PrivateChatcompComponent } from './private-chatcomp/private-chatcomp.component';
import { RegisterComponent } from './register/register.component';
import { SearchforprodComponent } from './searchforprod/searchforprod.component';
import { SingleproductpageComponent } from './singleproductpage/singleproductpage.component';
import { UpdateprodinfoComponent } from './updateprodinfo/updateprodinfo.component';
import { UploadimageComponent } from './uploadimage/uploadimage.component';
import { VendorprofileComponent } from './vendorprofile/vendorprofile.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {path:'home',component:HomebodyComponent},
  {path: 'catigory/:id',component: CatigorypageComponent},
  {path: 'search',component: SearchforprodComponent},
  {path: 'sellerInfo/:email',component: VendorprofileComponent},
  {path: 'Myaccount',component: MyaaccountpageComponent,canActivate:[AuthGuard]},
  //{path: 'updateproduct/:id',component: UpdateprodinfoComponent,canActivate:[AuthGuard]},
  {path: 'productdetailes/:id',component: SingleproductpageComponent},
  {path: 'addnewproduct',component: AddNewproductComponent,canActivate:[AuthGuard]},
  {path: 'register',component: RegisterComponent},
  {path: 'login',component: LoginComponent},
  {path: 'chats',component: ChatshomeallComponent,canActivate:[AuthGuard]},
  {path: 'chat/userid/:id',component: PrivateChatcompComponent,canActivate:[AuthGuard]},
  {path: 'uploadalbums',component: UploadimageComponent,canActivate:[AuthGuard]}



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
