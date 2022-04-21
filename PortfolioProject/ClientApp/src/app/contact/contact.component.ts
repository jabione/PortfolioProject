import { Component, EventEmitter, OnInit, Output, Inject } from '@angular/core';
import { NgForm } from '@angular/forms'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserContact } from '../shared/models/usercontact';
import { AlertService } from '../_alert/alert.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})

export class ContactComponent implements OnInit {
  //NG form
  NgForm = NgForm;
  //Base url 
  _baseUrl: any;
  //Contact object
  contact: any;
  //Post Result
  _resultpost: boolean = false;

  //Constructor
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, public alertService: AlertService) {
    this._baseUrl = baseUrl;
    this.contact = new UserContact();
  }

  ngOnInit(): void {
    this.contact.firstName = "";
    this.contact.lastName = "";
    this.contact.email = "";
    this.contact.message = "";
  }

  //Submit the contact form
  onSubmit() {

    debugger;
    // append to formData
    var formData: any = new FormData();
    formData.append('firstName', this.contact.firstName);
    formData.append('lastName', this.contact.lastName);
    formData.append('email', this.contact.email);
    formData.append('message', this.contact.message);

    // Post Contact
    this.http.post<boolean>(this._baseUrl + 'api/linkedin', formData).subscribe(response => {
      console.log(response);
      this._resultpost = response;
      if (this._resultpost) {
        //alert("Thank you for your Message !");
        this.alertService.success("Thank you for your Message !");
        //Refresh
        this.ngOnInit();
        //myModal.hide();
      } else {
        this.alertService.error("Error while sending message !");
        //alert("Error while sending message !");

      }
    }, error => console.error(error));
  }
}
