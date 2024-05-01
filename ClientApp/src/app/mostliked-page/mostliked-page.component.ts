import { Component, Input, OnInit } from '@angular/core';
import { FThread } from '../components/fthread/fthread';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-mostliked-page',
  templateUrl: './mostliked-page.component.html',
  styleUrls: ['./mostliked-page.component.css']
})
export class MostlikedPageComponent implements OnInit{
  listaFThreads : FThread[] = [];

  period: number = 1

  constructor(private route: ActivatedRoute){}

  ngOnInit(){
    var period = this.route.snapshot.queryParamMap.get("period")
    if(period != null){
      this.period = +period
    }
    
    
  }
}
