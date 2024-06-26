import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ForumComponent } from './components/forum/forum.component';
import { FthreadComponent } from './components/fthread/fthread.component';
import { PostComponent } from './components/post/post.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ForumPageComponent } from './forum-page/forum-page.component';
import { FthreadPageComponent } from './fthread-page/fthread-page.component';
import { UserComponent } from './components/user/user.component';
import { NewThreadComponent } from './new-thread/new-thread.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { PostReactionComponent } from './components/reaction/post-reaction/post-reaction.component';
import { FthreadReactionComponent } from './components/reaction/fthread-reaction/fthread-reaction.component';
import { LoginDialogComponent } from './components/login-dialog/login-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { SignupDialogComponent } from './components/signup-dialog/signup-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ForumComponent,
    FthreadComponent,
    PostComponent,
    HeaderComponent,
    FooterComponent,
    ForumPageComponent,
    FthreadPageComponent,
    UserComponent,
    NewThreadComponent,
    SidebarComponent,
    PostReactionComponent,
    FthreadReactionComponent,
    LoginDialogComponent,
    SignupDialogComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'forum-page', component: ForumPageComponent},
      { path: 'fthread-page', component: FthreadPageComponent},
      { path: 'newThread-page', component: NewThreadComponent}
    ], 
    {onSameUrlNavigation: 'reload'}),
    FontAwesomeModule,
    BrowserAnimationsModule,

    MatDividerModule,
    MatListModule,
    MatInputModule,
    MatFormFieldModule,
    MatSnackBarModule,
    MatButtonModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
