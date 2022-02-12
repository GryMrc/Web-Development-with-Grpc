import { Directive } from "@angular/core";
import { CRUDService } from "../../CRUDService/CRUDService";

@Directive()
export abstract class EditScreenBase<T> {
    constructor(public dataService: CRUDService<T>) {

    }
    onCreate(Item: T) {
        return this.dataService.create(Item, 'Create')
    }

    onUpdate(Item: T) {
        return this.dataService.update(Item, 'Update')
    }

    onDelete(Id: number) {
        return this.dataService.delete(Id.toString(), 'Delete');
    }

    listAll(){
        this.dataService.listAll();
    }
}