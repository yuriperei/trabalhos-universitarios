import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../../domain/entities/usuario';
import { ApiInfnetService } from '../../../domain/services/apiinfnet.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AlertMessage } from '../../../domain/utilities/alertmessage';

@Component({
  selector: 'app-usuariologin',
  templateUrl: './usuariologin.component.html',
  styleUrls: ['./usuariologin.component.css']
})
export class UsuariologinComponent {

  public usuario : Usuario;
  public alert : AlertMessage;
  public meuForm: FormGroup;

  constructor(public apiinfnet: ApiInfnetService, private router: Router, fb: FormBuilder) { 
    this.validateToken();

    this.usuario = new Usuario();
    this.usuario.username = 'yuri.souza@al.infnet.edu.br';
    this.usuario.password = 'Yur!.963901';

    this.meuForm = fb.group({
      username: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
      password: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
  });
  }

  private validateToken() {
    if(localStorage.getItem('token')){
      this.router.navigate(['/perfil']);
    }
  }

  efetuarLogin(event){
    event.preventDefault();

    this.alert = new AlertMessage("Efetuando login, aguarde.", "alert-dark");
    this.apiinfnet.GetToken(this.usuario).subscribe(retorno => {
      let token = retorno['token'];
      if(token){
        localStorage.setItem('token', token);
        this.router.navigate(['/perfil']);
      }else{
        this.alert = new AlertMessage("Usuário/senha inválido.", "alert-danger");
      }
    });
  }
}
