import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public vehicles: VehicleInfo[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<VehicleInfo[]>(baseUrl + 'vehicleinfo').subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }
}

interface VehicleInfo {
  VIN: string;
  modelYear: number;
  make: string;
  model: string;
  color: string;
  mileage: number;
}
