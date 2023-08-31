import { Injectable, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root',
})
export class BusyService implements OnInit {
  busyServiceCount = 0;

  constructor(private spinner: NgxSpinnerService) {}
  ngOnInit() {}

  busy() {
    this.busyServiceCount++;
    this.spinner.show();
  }

  idle() {
    this.busyServiceCount--;
    if (this.busyServiceCount <= 0) {
      this.busyServiceCount = 0;
      this.spinner.hide();
    }
  }
}
