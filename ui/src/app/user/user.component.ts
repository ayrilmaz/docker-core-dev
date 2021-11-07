import { Component, OnInit } from "@angular/core";

import { UserModel } from "../models/user-model";
import { UserService } from "../user.service";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  userList: UserModel[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.list().subscribe(result => {
      this.userList = result;
    });

  }

}
