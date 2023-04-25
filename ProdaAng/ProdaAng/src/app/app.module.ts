import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavheaderbarComponent } from './navheaderbar/navheaderbar.component';
import { HomebodyComponent } from './homebody/homebody.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { CatigorypageComponent } from './catigorypage/catigorypage.component';
import { SearchforprodComponent } from './searchforprod/searchforprod.component';
import * as $ from 'jquery';
import { VendorprofileComponent } from './vendorprofile/vendorprofile.component';
import { MyaaccountpageComponent } from './myaaccountpage/myaaccountpage.component';
import { UpdateprodinfoComponent } from './updateprodinfo/updateprodinfo.component';
import { SingleproductpageComponent } from './singleproductpage/singleproductpage.component';
import { CommentComponent } from './comment/comment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddNewproductComponent } from './add-newproduct/add-newproduct.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { FooterComponent } from './footer/footer/footer.component';
import { ChatshomeallComponent } from './chatshomeall/chatshomeall.component';
import { PrivateChatcompComponent } from './private-chatcomp/private-chatcomp.component';
import { DateFormatPipe } from 'src/Pipes/DateTransform';
import { UploadimageComponent } from './uploadimage/uploadimage.component';
import { NgxPaginationModule } from 'ngx-pagination';


@NgModule({
  declarations: [
    AppComponent,
    NavheaderbarComponent,
    HomebodyComponent,
    CatigorypageComponent,
    SearchforprodComponent,
    VendorprofileComponent,
    MyaaccountpageComponent,
    UpdateprodinfoComponent,
    SingleproductpageComponent,
    CommentComponent,
    AddNewproductComponent,
    RegisterComponent,
    LoginComponent,
    FooterComponent,
    ChatshomeallComponent,
    PrivateChatcompComponent,
    DateFormatPipe,
    UploadimageComponent



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgxPaginationModule

  ],
  providers: [{ provide: "window", useValue: window }],
  bootstrap: [AppComponent]
})
export class AppModule { }
