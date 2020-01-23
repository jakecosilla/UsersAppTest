import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserComponent } from './components/user/user.component';
import { UserCreateComponent } from './components/user-create/user-create.component';
import { UserUpdateComponent } from './components/user-update/user-update.component';


const routes: Routes = [
  { path: 'user', component: UserComponent, pathMatch: 'full' },
  { path: 'user/create', component: UserCreateComponent },
  { path: 'user/update/:dd', component: UserUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
