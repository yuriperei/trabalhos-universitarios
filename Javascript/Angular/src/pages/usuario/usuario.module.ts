import { ApiInfnetService } from './../../domain/services/apiinfnet.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioperfilComponent } from './perfil/usuarioperfil.component';
import { UsuariologinComponent } from './login/usuariologin.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

@NgModule({
  imports: [
    CommonModule,
    FormsModule, ReactiveFormsModule,
    HttpModule
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
