import { PostService } from './post.service';
import { Component, Input, OnInit } from '@angular/core';
import { Post } from './post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit{

  constructor(private service: PostService){}

  @Input() id : number = 0
  post : Post = {
    "id": 1,
    "threadId": 9,
    "text": "TestePost",
    "userId": "49f81fb8-93b3-4cd6-aca8-0a277021af2e",
    "dateCreated": new Date("2024-01-25T11:23:31.3875008-03:00"),
    "locked": false
  }

  ngOnInit(): void {
    this.service.buscarPorId(this.id).subscribe((post) => {
      this.post = post
    })
  }
}
