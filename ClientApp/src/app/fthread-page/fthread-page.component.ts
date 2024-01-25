import { PostService } from './../components/post/post.service';
import { Component, OnInit } from '@angular/core';
import { FThread } from '../components/fthread/fthread';
import { Post } from '../components/post/post';
import { FThreadService } from '../components/fthread/fthread.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-fthread-page',
  templateUrl: './fthread-page.component.html',
  styleUrls: ['./fthread-page.component.css']
})
export class FthreadPageComponent implements OnInit{

  listaPosts : Post[] = [];
  fthread!: FThread;

  constructor(private postService: PostService, private fthreadService: FThreadService, private route: ActivatedRoute){}

  ngOnInit(): void {
    var fthreadId = this.route.snapshot.queryParamMap.get('fthreadId');
    if(fthreadId){
      var numberFThreadId : number = +fthreadId
      this.postService.listarPorFThread(numberFThreadId).subscribe((listaPosts) => {
        this.listaPosts = listaPosts
      })
      this.fthreadService.buscarPorId(numberFThreadId).subscribe((fthread) => {
        this.fthread = fthread
      })
    }
  }
}
