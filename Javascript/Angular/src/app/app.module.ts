import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UsuarioModule } from './../pages/usuario/usuario.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routes';

import 'rxjs/add/operator/map';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    NgbModule.forRoot(),
    FormsModule,
    AppRoutingModule,
    BrowserModule,
	  UsuarioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
