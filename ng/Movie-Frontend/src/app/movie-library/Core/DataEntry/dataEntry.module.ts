import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextEntry } from './TextEntry/textEntry.component';



@NgModule({
  declarations: [
      TextEntry
    ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
      TextEntry
  ]
})
export class DataEntryModule { }
