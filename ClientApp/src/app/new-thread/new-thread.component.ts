import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FThread } from '../components/fthread/fthread';
import { FThreadService } from '../components/fthread/fthread.service';

@Component({
  selector: 'app-new-thread',
  templateUrl: './new-thread.component.html',
  styleUrls: ['./new-thread.component.css']
})
export class NewThreadComponent {

  constructor(private service: FThreadService, 
              private route: ActivatedRoute,
              private router: Router){}

  public newThreadForm = new FormGroup({
    title: new FormControl(),
    text: new FormControl(),
  });

  onSubmit(){
    var forumId = this.route.snapshot.queryParamMap.get('forumId')
    if(forumId != null){
      var numberForumId: number = +forumId
      var fthread: FThread ={
        forumID: numberForumId,
        name: this.newThreadForm.controls.title.value,
        text: this.newThreadForm.controls.text.value,
        startedByUserId: "94c5d3db-e8e5-4381-be59-c491fef4fe1e"
      }

      this.service.criar(fthread).subscribe(() => {
        this.router.navigate(['forum-page'], { queryParams: {forumId: forumId}})
      })
    }
    
    
    

  }
}
