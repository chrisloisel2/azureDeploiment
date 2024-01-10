import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FetcherService {
  constructor(private http: HttpClient) {}

  fetch() {
    return this.http.get(
      'https://backendmessagecorrection.azurewebsites.net/api/messages'
    );
  }
}
