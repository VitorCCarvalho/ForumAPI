import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarComponent } from './snack-bar/snack-bar.component';
import { PostService } from './../components/post/post.service';
import { Component, OnInit } from '@angular/core';
import { FThread } from '../components/fthread/fthread';
import { Post } from '../components/post/post';
import { FThreadService } from '../components/fthread/fthread.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../components/user/user.service';
import { User } from '../components/user/user';

import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { faHeartBroken } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-fthread-page',
  templateUrl: './fthread-page.component.html',
  styleUrls: ['./fthread-page.component.css']
})
export class FthreadPageComponent implements OnInit{
  faHeart = faHeart
  faHeartBroken = faHeartBroken

  fthreadId : string | null = ""
  listaPosts : Post[] = [];
  fthread: FThread ={
    id: 0,
    forumID: 0,
    name: "testeFThread2",
    text: "testeTextFThread",
    sticky: false,
    active: true,
    dateCreated:  new Date("2024-01-25T11:23:31.3875008-03:00"),
    startedByUserId: "9239a0ee-71d6-4984-8a71-075d68bf31a7",
    locked: false,
    posts: []
  };

  user: User = {
    id: "teste",
    name: "teste",
    username: "teste",
    description: "testeD",
    email: "teste",
    lastLogin: new Date("2024-01-25T11:23:31.3875008-03:00"),
    dateJoined: new Date("2024-01-25T11:23:31.3875008-03:00")
  }

  constructor(private postService: PostService, 
              private fthreadService: FThreadService, 
              private userService: UserService, 
              private route: ActivatedRoute,
              private router: Router,
              private _snackBar: MatSnackBar){}
  
  ngOnInit(): void {
    this.fthreadId = this.route.snapshot.queryParamMap.get('fthreadId');
    if(this.fthreadId){
      var numberFThreadId : number = +this.fthreadId
      this.postService.listarPorFThread(numberFThreadId).subscribe((listaPosts) => {
        this.listaPosts = listaPosts
      })
      this.fthreadService.buscarPorId(numberFThreadId).subscribe((fthread) => {
        this.fthread = fthread

      })
      if(this.fthread.startedByUserId){
        this.userService.buscarPorId(this.fthread.startedByUserId).subscribe((user) =>{
          this.user = user
        })
      }
      
      
      
    }
  }

  sendReply(){
    var reply = (<HTMLInputElement>document.getElementById("text-reply")).value


    if(reply != "" && this.fthread.id){
      var newPost: Post = {
        "threadId": this.fthread.id,
        "text": reply,
        "userId": "7de22010-e975-409f-a4b1-5a4e5ac419bc",
        "dateCreated": new Date(),
        "locked": false
      }

      this.postService.criar(newPost).subscribe(() => {
        this.router.navigate(['fthread-page'], { queryParams: {fthreadId: this.fthread.id}})
        this.openSnackBar()
      })

    }
  }

  openSnackBar() {
    this._snackBar.openFromComponent(SnackBarComponent, {
      duration: 2000,
    });
  }
}
