import { Component, Inject, OnInit, OnChanges } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})

export class FetchDataComponent {
  public vehicles: string;
  public owners: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  ngOnInit() {
    this.http.get<string>(this.baseUrl + 'VehicleInfo?owner=0').subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));

    this.http.get<string>(this.baseUrl + 'Owner').subscribe(result => {
      this.owners = result;
    }, error => console.error(error));
  }

  onChange(elementId) {
    this.http.get<string>(this.baseUrl + 'VehicleInfo?owner=' + elementId).subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }

  addNew(elementId) {
    this.router.navigate(['/vehicle-add', elementId]);
  }
}
