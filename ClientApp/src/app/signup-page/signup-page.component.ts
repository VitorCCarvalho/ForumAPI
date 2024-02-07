import { UserService } from './../components/user/user.service';
import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { SignUp } from '../components/user/signup';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent {

  constructor(private service: UserService,
              private router: Router){}

  public signupForm = new FormGroup({
    username: new FormControl(),
    name: new FormControl(),
    email: new FormControl(),
    password: new FormControl(),
    repassword: new FormControl()
  });

  onSubmit(){
    var signup: SignUp ={
      username: this.signupForm.controls.username.value,
      name: this.signupForm.controls.name.value,
      email: this.signupForm.controls.email.value,
      password: this.signupForm.controls.password.value,
      repassword: this.signupForm.controls.repassword.value
    }
    
    this.service.criar(signup).subscribe(() => {
      this.router.navigate([''])
    })

  }
}
