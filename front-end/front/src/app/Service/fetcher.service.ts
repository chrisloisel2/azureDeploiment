import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Message } from '../Model/Message';

@Injectable({
  providedIn: 'root',
})
export class FetcherService {
  url = 'http://frontcorrection1.azurewebsites.net';

  Messages: Message[] = [];

  constructor(private http: HttpClient) {}

  public get(url: string) {
    return this.http.get<Message[]>(url).subscribe((data) => {
      this.Messages = data;
    });
  }

  public post(url: string, body: Message) {
    return this.http.post(url, body);
  }

  public put(url: string, body: Message) {
    return this.http.put(url, body);
  }

  public delete(url: string) {
    return this.http.delete(url);
  }
}
