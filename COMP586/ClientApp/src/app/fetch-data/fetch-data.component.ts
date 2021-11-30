import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public vehicles: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    let customHeaders = new HttpHeaders({ Authorization: "Bearer " + localStorage.getItem("token") });
    const requestOptions = { headers: customHeaders };

    http.get<string>(baseUrl + 'VehicleInfo', requestOptions).subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }
}

/*interface VehicleInfo {
  vehicleID: number;
  VIN: string;
  modelYear: number;
  make: string;
  model: string;
  color: string;
  mileage: number;
  ownerID: number;
}
*/
