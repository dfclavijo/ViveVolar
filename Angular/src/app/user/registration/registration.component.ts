import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../shared/user.service';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {

  constructor(public service:UserService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('Nuevo Usuario Creado!', 'Registro Exitoso!.');
        } else {
          res.errors.forEach((element: any) => {
            switch (element.code) {
              case 'Usuario Duplicado':
                this.toastr.error('El Usuario ya Existe!','El Registro Falló.');
                break;

              default:
              this.toastr.error(element.description,'El Registro Falló.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
