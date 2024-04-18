import { Component, Input, OnInit } from '@angular/core';
import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { faHeartBroken } from '@fortawesome/free-solid-svg-icons';
import { PostReaction } from './post-reaction';
import { PostReactionService } from './post-reaction.service';

@Component({
  selector: 'app-post-reaction',
  templateUrl: './post-reaction.component.html',
  styleUrls: ['./post-reaction.component.css']
})
export class PostReactionComponent {
  faHeart = faHeart
  faHeartBroken = faHeartBroken
  
  constructor(private service: PostReactionService){}

  @Input() postId: number = 0
  @Input() userId: string = ""
  listaPostReactions: PostReaction[] = []
  likes: PostReaction[] = []
  dislikes: PostReaction[] = []

  likeCount: number = 0
  dislikeCount: number = 0

  ngOnInit(): void{
    this.service.listarPorPost(this.postId).subscribe((listaPostReactions) => {
      this.listaPostReactions = listaPostReactions

      this.likes = this.listaPostReactions.filter(i => i.reaction == true)
      this.dislikes = this.listaPostReactions.filter(i => i.reaction == false)

      this.likeCount = this.likes.length
      this.dislikeCount = this.dislikes.length
    })
  }
}
