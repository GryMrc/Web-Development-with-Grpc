import { Directive} from "@angular/core";
import { ListParams } from "../../ListParams/ListParams";

@Directive()
export abstract class ListScreenBase<T> {
title = '';
listParams: ListParams;
abstract refreshList():void;
abstract createEmptyModel():T;

constructor(title: string) {
    this.listParams = new ListParams();
    this.title = title;
}

initiate(){
    this.refreshList();
}

showEditScreen(editScreen: any, action:string, model?:any) {
    editScreen.container.Item = model ? model : this.createEmptyModel();
    editScreen.container.action = action;
    editScreen.container.title = action + ' ' + this.title; // nameof kullanimini dene
    editScreen.container.formGroup = editScreen.formGroup;
    editScreen.container.parent = editScreen;
    editScreen.container.show();
}
pageStateChanged(listParams:ListParams){
  this.listParams.page = listParams.page;
  this.listParams.pageSize = listParams.pageSize;
  this.refreshList();
}

}