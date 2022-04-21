import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {

  
  //user infos variables
  userinfos: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    //get user infos by base url
    http.get<User[]>(baseUrl + 'api/linkedin').subscribe(result => {
      this.userinfos = result;
    }, error => console.error(error));
  }

}
