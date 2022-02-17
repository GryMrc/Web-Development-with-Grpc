import { Component, forwardRef, Optional, Self } from "@angular/core";
import { ControlValueAccessor, NgControl, NG_VALUE_ACCESSOR  } from "@angular/forms";
import { CommonProp } from "../../CommonProperties/commonProp";

export const NOOP_VALUE_ACCESSOR: ControlValueAccessor = 
{
    writeValue(): void {},
    registerOnChange(): void {},
    registerOnTouched(): void {}
};
@Component({
    selector:'text-entry',
    templateUrl:'./textEntry.component.html',
    styleUrls:[]
})
export class TextEntry extends CommonProp{
    /**
     *
     */
    
    constructor(@Self() @Optional() public ngControl: NgControl) {
        super();
        if (this.ngControl)
        {
           this.ngControl.valueAccessor = NOOP_VALUE_ACCESSOR;
        }
    }
    getClasses(type:string) {
        const classes: any = {};
        switch(type){
            case 'Editor':
                classes['col-sm-' + this.editorWidth] = true;
                break;
            case 'Caption':
                classes['col-sm-' + this.captionWidth] = true;
                break;
            default:
                break;
        }
        return classes;
    }
}