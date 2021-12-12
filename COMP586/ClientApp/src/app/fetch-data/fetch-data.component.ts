import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
//TODO: REMINDER - the url for the GET was wrong the whole time! pay attention to URLs in Swagger.
export class FetchDataComponent {
  public vehicles: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    let customHeaders = new HttpHeaders({ Authorization: "Bearer " + localStorage.getItem("token") });
    const requestOptions = { headers: customHeaders };
    http.get<string>(baseUrl + 'VehicleInfo?owner=0', requestOptions).subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }
  onChange($event, elementId, @Inject('BASE_URL') baseUrl: string) {
    var http: HttpClient;
    let customHeaders = new HttpHeaders({ Authorization: "Bearer " + localStorage.getItem("token") });
    const requestOptions = { headers: customHeaders };
    http.get<string>(baseUrl + 'VehicleInfo?owner=' + elementId, requestOptions).subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }
}
