import { FthreadReactionService } from './fthread-reaction.service';
import { Component, Input, OnInit } from '@angular/core';

import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { faHeartBroken } from '@fortawesome/free-solid-svg-icons';
import { FthreadReaction } from './fthread-reaction';
import { jwtDecode } from 'jwt-decode';
@Component({
  selector: 'app-fthread-reaction',
  templateUrl: './fthread-reaction.component.html',
  styleUrls: ['./fthread-reaction.component.css']
})
export class FthreadReactionComponent implements OnInit{
  faHeart = faHeart
  faHeartBroken = faHeartBroken

  constructor(private service : FthreadReactionService){}

  @Input() fthreadId: string = ""
  @Input() userId: string = ""
  listaFthreadReactions : FthreadReaction[] = []
  likes : FthreadReaction[]  = []
  dislikes : FthreadReaction[] = [] 

  classLikes: string = "likes"
  classDislikes: string = "dislikes"
  likeCount: number = 0
  dislikeCount: number = 0
  ngOnInit(): void {
    var numberFThreadId : number = +this.fthreadId 
    this.service.listarPorFThread(numberFThreadId).subscribe((listaFthreadReactions) => {
      this.listaFthreadReactions = listaFthreadReactions
      this.likes = this.listaFthreadReactions.filter(i => i.reaction == true)
      this.dislikes = this.listaFthreadReactions.filter(i => i.reaction == false)
      
      this.likeCount = this.likes.length
      this.dislikeCount = this.dislikes.length

      this.verifyLike()
      this.verifyDislike();
    })
  }

  verifyLike(){
    var userSession: any = sessionStorage.getItem("jwt-session")
    if(userSession != null){
      var decodedSession: any = jwtDecode(userSession)
      var userId = decodedSession.id
      
      var numberFThreadId = +this.fthreadId 
      this.service.acharReaction(numberFThreadId, userId).subscribe((postReaction) => {
        if(postReaction != null){
          if(postReaction.reaction == true){
            this.classLikes = "likes-selected"
          } 
        }
      })

    }
  }

  verifyDislike(){
    var userSession: any = sessionStorage.getItem("jwt-session")
    if(userSession != null){
      var decodedSession: any = jwtDecode(userSession)
      var userId = decodedSession.id
      
      var numberFThreadId = +this.fthreadId 
      this.service.acharReaction(numberFThreadId, userId).subscribe((postReaction) => {
        if(postReaction != null){
          if(postReaction.reaction == false){
            this.classDislikes = "dislikes-selected"
          } 
        }
      })

    }

  }
}
