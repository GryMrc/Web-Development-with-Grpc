// my-loader.component.ts
import { Component, OnInit } from '@angular/core';
import { LoadingService } from './loading.service';

@Component({
  selector: 'app-my-loader',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class MyLoaderComponent implements OnInit {

  loading: boolean | undefined;

  constructor(private loaderService: LoadingService) {

    this.loaderService.isLoading.subscribe((v) => {
      this.loading = v;
    });

  }
  ngOnInit() {
  }

}
