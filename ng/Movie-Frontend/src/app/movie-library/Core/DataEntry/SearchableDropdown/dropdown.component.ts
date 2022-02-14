import { Component, Input } from "@angular/core";

@Component({
    'selector':'mov-dropdown',
    'templateUrl':'./dropdown.component.html',
    'styles':[]
})

export class DropDownComponent{
 
 @Input() items: any;

 filterItem(input:any){
  if(typeof(input.data) == 'string')
  console.log(input.data);
  }
}