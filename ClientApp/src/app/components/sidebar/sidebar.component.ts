import { Login } from './../user/login';
import { Component, OnInit } from '@angular/core';
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { faCircleArrowUp } from '@fortawesome/free-solid-svg-icons';
import { faCircleUser } from '@fortawesome/free-solid-svg-icons';
import { UserService } from '../user/user.service';
import { jwtDecode } from 'jwt-decode';

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
  constructor(private userService: UserService){}

  ngOnInit(){
    this.getUserData();
  }

  loginUser(){
    var login : Login = {
      username : "testeUser4",
      password : "Abc1234;"
    }
    this.userService.login(login).subscribe((token) => {
    }, 
    err => {
      sessionStorage.setItem("jwt-session", err.error.text);
      this.getUserData();
    })
  }

  getUserData(){
    if(this.userToken != null){
      this.userJson = jwtDecode(this.userToken);

      this.username = this.userJson.username
    }
  }
}
