import { Component, OnInit } from '@angular/core';
import { Forum } from '../components/forum/forum';
import { ForumService } from '../components/forum/forum.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  
  listaForums : Forum[] = [];
  constructor(private service: ForumService){}

  ngOnInit(): void {
    this.service.listar().subscribe((listaForums) => {
      this.listaForums = listaForums
    })
  }
}
