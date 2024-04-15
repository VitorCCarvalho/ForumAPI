import { FthreadReactionService } from './fthread-reaction.service';
import { Component, Input, OnInit } from '@angular/core';

import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { faHeartBroken } from '@fortawesome/free-solid-svg-icons';
import { FthreadReaction } from './fthread-reaction';
@Component({
  selector: 'app-fthread-reaction',
  templateUrl: './fthread-reaction.component.html',
  styleUrls: ['./fthread-reaction.component.css']
})
export class FthreadReactionComponent implements OnInit{
  faHeart = faHeart
  faHeartBroken = faHeartBroken

  constructor(private service : FthreadReactionService){}

  @Input() threadId: number = 0
  @Input() userId: string = ""
  listaFthreadReactions : FthreadReaction[] = []

  likeCount: number = 0
  dislikeCount: number = 0
  ngOnInit(): void {
    this.service.listarPorFThread(this.threadId).subscribe((listaFthreadReactions) => {
      this.listaFthreadReactions = listaFthreadReactions

      console.log(this.listaFthreadReactions)
    })
  }
}
