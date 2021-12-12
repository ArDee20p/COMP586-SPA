import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-vehicle-add',
  templateUrl: './vehicle-add.component.html'
})
export class VehicleAddComponent {
  AddVehicle(form: NgForm) {
    var VIN = (<HTMLTextAreaElement>document.getElementById('vin')).value;
    var modelYear = (<HTMLTextAreaElement>document.getElementById('modelYear')).value;
    var make = (<HTMLTextAreaElement>document.getElementById('make')).value;
    var model = (<HTMLTextAreaElement>document.getElementById('model')).value;
    var color = (<HTMLTextAreaElement>document.getElementById('color')).value;
    var mileage = (<HTMLTextAreaElement>document.getElementById('mileage')).value;
    var owner = (<HTMLTextAreaElement>document.getElementById('ownerName')).value;


  }
}
