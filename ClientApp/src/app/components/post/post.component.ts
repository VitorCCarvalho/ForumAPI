import { UserService } from './../user/user.service';
import { PostService } from './post.service';
import { Component, Input, OnInit } from '@angular/core';
import { Post } from './post';
import { User } from '../user/user';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit{

  constructor(private postService: PostService, private userService: UserService){}

  @Input() id : number = 0
  
  post : Post = {
    "id": 2,
    "threadId": 10,
    "text": "TestePost2",
    "userId": "90654662-ac60-474d-9265-f1119cb43638",
    "dateCreated": new Date("2024-01-25T11:23:31.3875008-03:00"),
    "locked": false
  }

  user!: User 

  ngOnInit(): void {
    this.postService.buscarPorId(this.id).subscribe((post) => {
      this.post = post
    })

    this.userService.buscarPorId(this.post.userId).subscribe((user) => {
      this.user = user
    })
  }
}
