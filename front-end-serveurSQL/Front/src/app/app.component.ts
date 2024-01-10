import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { FetcherService } from './Service/fetcher.service';
import { MessageComponent } from './Component/message/message.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, MessageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  messages: any[] = [];

  constructor(private fetcher: FetcherService) {
    this.fetcher.fetch().subscribe((data: any) => {
      this.messages = data;
    });
  }
}
