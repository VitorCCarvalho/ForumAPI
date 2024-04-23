import { Component, OnInit } from '@angular/core';
import { Login } from '../user/login';
import { UserService } from '../user/user.service';
import { jwtDecode } from 'jwt-decode';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SidebarComponent } from '../sidebar/sidebar.component';


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

  constructor(private userService: UserService, private route: Router){}


  loginUser(user: string | null, password: string | null){
    var login : Login = {
      username : user? user : "",
      password : password? password: ""
    }
    this.userService.login(login).subscribe((userToken: any) => {
      sessionStorage.setItem("jwt-session", userToken.token);
      this.getUserData();
      this.textResponse = "Login efetuado!";
    }, 
    err => {
      console.log("não foi");
      this.textResponse = err.error;
    })
  }

  getUserData(){
    if(this.userToken != null){
      this.userJson = jwtDecode(this.userToken);

      this.username = this.userJson.username
      this.route.navigate(['/']);
    }
  }

  onSubmit(){
    this.loginUser(this.userFormControl.value, this.passwordFormControl.value)
  }

}

