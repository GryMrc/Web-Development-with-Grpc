import { Component, Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MovieEditComponent } from '../../movie-edit/movie-edit/movie-edit.component';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css'],
  
})

@Injectable()
export class MovieListComponent {
  dataList = [];
  bsModalRef: BsModalRef | undefined;
  constructor(private modalService: BsModalService){}

  openModal(editType:string,model?:any) {
    this.bsModalRef = this.modalService.show(MovieEditComponent);

    let data = {
      Title: editType + ' Movie ',
      Model: model ? model : null,
      prop3: 'This Can be anything'
    }
  }
}
