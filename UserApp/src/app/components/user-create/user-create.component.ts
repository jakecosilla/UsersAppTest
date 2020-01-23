import { Component } from '@angular/core';
import { Router } from "@angular/router"

import { UserService } from '../../services/user.service';
import { User } from '../../models/user';

@Component({
  templateUrl: './user-create.component.html'
})
export class UserCreateComponent {
  user: User;

  constructor(private _router: Router, private _userService: UserService) { }

  ngOnInit() {
    this.user = {} as User;
  }

  submit() {
    this._userService.create(this.user).subscribe(result => {
        this._router.navigate([`/user`]);
    });
  }

}
