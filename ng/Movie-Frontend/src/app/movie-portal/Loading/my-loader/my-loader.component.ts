// my-loader.component.ts
import { Component, OnInit } from '@angular/core';
import { LoadingService } from '../../../movie-library/Loading/loading.service';

@Component({
  selector: 'app-my-loader',
  templateUrl: './my-loader.component.html',
  styleUrls: ['./my-loader.component.css']
})
export class MyLoaderComponent implements OnInit {

  loading: boolean | undefined;

  constructor(private loaderService: LoadingService) {

    this.loaderService.isLoading.subscribe((v) => {
      console.log(v);
      this.loading = v;
    });

  }
  ngOnInit() {
  }

}
