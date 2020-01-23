import { Component } from '@angular/core';

import { UserService } from '../../services/user.service';

import { User } from '../../models/user';

@Component({
  templateUrl: './user.component.html'
})
export class UserComponent {
  usersResult: User[];
  user: User;
  constructor(private _userService: UserService) { }

  ngOnInit() {
    this.usersResult = {} as User[];
    this.user = {} as User;
  }

  ngAfterContentInit() {
    this.refresh();
  }

  refresh() {    
    this._userService.getAll().subscribe(result => {
        this.usersResult = result;
        console.log(this.usersResult);
    });
  }

  delete(id: number) {
    this._userService.delete(id).subscribe(result => {
        this.refresh();
    });
  }
}
