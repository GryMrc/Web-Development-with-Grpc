export class ServiceVoidResponse{
    
    Success:boolean = false;
    Message:string ='';
}

export class ServiceDataResponse extends ServiceVoidResponse{
    Data:any;
    Total:number = 0;
}