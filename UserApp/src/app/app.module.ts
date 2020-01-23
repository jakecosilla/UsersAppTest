import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {NgbModule, NgbDropdown} from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UserComponent } from './components/user/user.component';
import { UserCreateComponent } from './components/user-create/user-create.component';
import { UserUpdateComponent } from './components/user-update/user-update.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent, UserCreateComponent, UserUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [NgbDropdown],
  bootstrap: [AppComponent]
})
export class AppModule { }