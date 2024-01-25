import { Component, Input, OnInit } from '@angular/core';
import { FThread } from './fthread';
import { FThreadService } from './fthread.service';

@Component({
  selector: 'app-fthread',
  templateUrl: './fthread.component.html',
  styleUrls: ['./fthread.component.css']
})
export class FthreadComponent implements OnInit{
  
  constructor(private service : FThreadService){}

  @Input() id : number = 0
  fthread : FThread = {
    "id": 0,
    "forumID": 6,
    "name": "TesteFThread",
    "text": "TesteText",
    "sticky": false,
    "active": true,
    "dateCreated": new Date("2024-01-17T11:56:22.365236"),
    "startedByUserId": 0,
    "locked": false,
    "posts": []
  }

  ngOnInit(): void {
    this.service.buscarPorId(this.id).subscribe((fthread) =>{
      this.fthread = fthread;
    });
  }

}
