import { Directive, Input } from "@angular/core";
import { FormControlName } from "@angular/forms";

@Directive()
export class CommonProp{
    @Input() caption: string = '';
    @Input() captionWidth: number = 3;
    @Input() editorWidth: number = 9;
    @Input() formControlName!: FormControlName;
}