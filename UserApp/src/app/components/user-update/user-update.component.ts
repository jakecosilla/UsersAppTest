import { Component } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router"

import { UserService } from '../../services/user.service';

import { User } from '../../models/user';

@Component({
  templateUrl: './user-update.component.html'
})

export class UserUpdateComponent {
  user: User;
  private _id: number;

  constructor(private _activatedRoute: ActivatedRoute, private _router: Router, private _userService: UserService) { }

  ngOnInit() {
    this.user = {} as User;
  }

  ngAfterContentInit() {
    this._id = this._activatedRoute.snapshot.params.id;
    this.refresh();
  }

  submit() {
    this._userService.update(this._id, this.user).subscribe(result => {
        this._router.navigate([`/user`]);
    });
  }

  private refresh() {
    this._userService.get(this._id).subscribe(result => {
        this.user = result;
    });
  }
}
