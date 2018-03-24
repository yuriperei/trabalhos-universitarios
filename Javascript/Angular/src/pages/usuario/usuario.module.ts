import { ApiInfnetService } from './../../domain/services/apiinfnet.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioperfilComponent } from './perfil/usuarioperfil.component';
import { UsuariologinComponent } from './login/usuariologin.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    UsuariologinComponent,
    UsuarioperfilComponent
  ],
  exports:[
    UsuariologinComponent,
    UsuarioperfilComponent
  ],
  providers: [ApiInfnetService]
})
export class UsuarioModule { }
