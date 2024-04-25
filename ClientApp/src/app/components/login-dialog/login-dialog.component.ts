import { SidebarComponent } from './../sidebar/sidebar.component';
import { Component, OnInit } from '@angular/core';
import { Login } from '../user/login';
import { UserService } from '../user/user.service';
import { jwtDecode } from 'jwt-decode';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.css'],
})
export class LoginDialogComponent{

  textResponse: string = "" 

  userFormControl = new FormControl('', [Validators.required]);
  passwordFormControl = new FormControl('', [Validators.required]);

  userToken = sessionStorage.getItem("jwt-session")

  userJson : any
  username: string = "User"

  constructor(private userService: UserService, private sidebar: SidebarComponent){}


  loginUser(user: string | null, password: string | null){
    var login : Login = {
      username : user? user : "",
      password : password? password: ""
    }
    this.userService.login(login).subscribe((httpResponse: any) => {
      sessionStorage.setItem("jwt-session", httpResponse.response);
      this.getUserData();
      this.textResponse = "Login efetuado!";
      
    }, 
    err => {
      this.textResponse = err.error;
    })
  }

  getUserData(){
    if(this.userToken != null){
      this.userJson = jwtDecode(this.userToken);

      this.username = this.userJson.username
    }
  }

  onSubmit(){
    this.loginUser(this.userFormControl.value, this.passwordFormControl.value)
  }

  openSignUp(){
    this.sidebar.switchDialogSection()
  }

}

