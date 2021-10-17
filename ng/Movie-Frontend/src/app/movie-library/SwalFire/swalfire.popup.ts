import Swal from 'sweetalert2';

export class SwalFirePopUp{

  public static swalFireError(message:string){
        const Toast = Swal.mixin({
           position:'top',
           toast: true,
         })
         Toast.fire({
           icon:'error',
           title: 'Error',
           text:message,
         })
       }
     
     public static swalFireSuccess(action:string){
         const Toast = Swal.mixin({
           toast: true,
           position: 'top-end',
           showConfirmButton: false,
           timer: 1500,
           padding:20    
         })
         
         Toast.fire({
           icon: 'success',
           title: action + " Success"
         })
       }
}