import { LoginDialogComponent } from './../login-dialog/login-dialog.component';
import { Login } from './../user/login';
import { Component, Injectable, OnInit } from '@angular/core';
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { faCircleArrowUp } from '@fortawesome/free-solid-svg-icons';
import { faCircleUser } from '@fortawesome/free-solid-svg-icons';
import { UserService } from '../user/user.service';
import { jwtDecode } from 'jwt-decode';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ComponentType } from '@angular/cdk/portal';
import { SignupDialogComponent } from '../signup-dialog/signup-dialog.component';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit{
  faHouse = faHouse
  faCircleArrowUp = faCircleArrowUp
  faCircleUser = faCircleUser

  dialogSection: string = "login"

  userToken = sessionStorage.getItem("jwt-session")

  userJson : any
  username: string = "User"
  constructor(private userService: UserService, public dialog: MatDialog){
  }

  ngOnInit(){
    this.getUserData();
  }

  openLoginDialog(){
    if(this.dialogSection == "login"){
      const dialogAux = this.dialog.open(LoginDialogComponent);
    } else if (this.dialogSection == "signup"){
      const dialogAux = this.dialog.open(SignupDialogComponent);
    }
    

    
  }

  switchDialogSection(){
    if(this.dialogSection == "login"){
      this.dialog.closeAll();
      const dialogAux = this.dialog.open(SignupDialogComponent);
      this.dialogSection = "signup"
    } else if (this.dialogSection == "signup"){
      this.dialog.closeAll();
      const dialogAux = this.dialog.open(LoginDialogComponent);
      this.dialogSection = "login"
    }
  }

  getUserData(){
    if(this.userToken != null){
      this.userJson = jwtDecode(this.userToken);

      this.username = this.userJson.username
    }
  }
}
