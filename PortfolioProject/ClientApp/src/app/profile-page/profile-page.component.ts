import { Component, Inject, NgModule } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../shared/models/user';
import { UserContact } from '../shared/models/usercontact';
import { Observable } from 'rxjs';
import { FormControl, Validators, FormGroup } from '@angular/forms';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent {

  //Base URL
  _baseUrl: any;
  //user infos variables
  userinfos: any;
  isNew: boolean = false;
  usercontact: any;

  //constructor with get method
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //get user infos by base url
    http.get<User[]>(baseUrl + 'api/linkedin').subscribe(result => {
      this.userinfos = result;
    }, error => console.error(error));

    this._baseUrl = baseUrl;
  }


}




