import { ApiInfnetService } from './../domain/services/apiinfnet.service';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';
import { UsuariologinComponent } from './../pages/usuario/login/usuariologin.component';
import { UsuarioperfilComponent } from './../pages/usuario/perfil/usuarioperfil.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routes';

import 'rxjs/add/operator/map';
import { HeaderComponent } from '../pages/header/header.component';
import { MateriaComponent } from '../pages/usuario/materia/materia.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    UsuariologinComponent,
    UsuarioperfilComponent,
    MateriaComponent
  ],
  imports: [
    NgbModule.forRoot(),
    FormsModule, ReactiveFormsModule,
    AppRoutingModule,
    BrowserModule,
    CommonModule,
    FormsModule,
    HttpModule,
    RouterModule
  ],
  providers: [ApiInfnetService],
  bootstrap: [AppComponent]
})
export class AppModule { }
