import { Login } from './../user/login';
import { Component, OnInit } from '@angular/core';
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { faCircleArrowUp } from '@fortawesome/free-solid-svg-icons';
import { faCircleUser } from '@fortawesome/free-solid-svg-icons';
import { UserService } from '../user/user.service';
import { jwtDecode } from 'jwt-decode';
import { MatDialog } from '@angular/material/dialog';

import { LoginDialogComponent } from '../login-dialog/login-dialog.component';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit{
  faHouse = faHouse
  faCircleArrowUp = faCircleArrowUp
  faCircleUser = faCircleUser

  userToken = sessionStorage.getItem("jwt-session")

  userJson : any
  username: string = "User"
  constructor(private userService: UserService, public dialog: MatDialog){}

  ngOnInit(){
    this.getUserData();
  }

  loginUser(){
    const dialogRef = this.dialog.open(LoginDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  getUserData(){
    if(this.userToken != null){
      this.userJson = jwtDecode(this.userToken);

      this.username = this.userJson.username
    }
  }
}
