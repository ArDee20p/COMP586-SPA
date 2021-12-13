import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-add',
  templateUrl: './vehicle-add.component.html'
})

export class VehicleAddComponent {

  owner: number;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => this.owner = params['elementId']);
  }

  vehicleAdd(form: NgForm) {
    let newVehicle: VehicleInfo = {
      VIN: (<HTMLTextAreaElement>document.getElementById('vin')).value,
      modelYear: Number((<HTMLTextAreaElement>document.getElementById('modelYear')).value),
      make: (<HTMLTextAreaElement>document.getElementById('make')).value,
      model: (<HTMLTextAreaElement>document.getElementById('model')).value,
      color: (<HTMLTextAreaElement>document.getElementById('color')).value,
      mileage: Number((<HTMLTextAreaElement>document.getElementById('mileage')).value),
      ownerID: this.owner,
    };
    console.log(newVehicle);
    
    this.http.post(this.baseUrl + 'VehicleInfo/addVehicle', newVehicle, {}).subscribe(result => {
    }, error => console.error(error));

    this.router.navigate(['/fetch-data']);
  }
}

interface VehicleInfo {
  VIN: string;
  modelYear: number;
  make: string;
  model: string;
  color: string;
  mileage: number;
  ownerID: number;
}
