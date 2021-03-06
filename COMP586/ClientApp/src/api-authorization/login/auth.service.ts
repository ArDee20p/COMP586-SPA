import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,) { }

  login(credentials: string) {
    return this.http.post('https://localhost:44358/api/Auth/login', credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": 'https://comp586spajlord.azurewebsites.net',
      })
    });
  }

}
