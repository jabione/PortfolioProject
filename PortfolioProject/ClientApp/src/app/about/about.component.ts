import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {
  //about user infos variable
  userinfos: any;
  aboutinfos: any;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //get user infos by base url
    http.get<User[]>(baseUrl + 'api/linkedin').subscribe(result => {
      this.userinfos = result;

    }, error => console.error(error));


    //get about infos by base url
    http.get<User[]>(baseUrl + 'api/linkedin/GetAbout').subscribe(result => {
      this.aboutinfos = result;
    }, error => console.error(error));
  }

}
