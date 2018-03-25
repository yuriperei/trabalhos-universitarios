import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiInfnetService } from '../../../domain/services/apiinfnet.service';
import { Usuario } from '../../../domain/entities/usuario';
import { Materia } from '../../../domain/entities/materia';

@Component({
  selector: 'app-usuarioperfil',
  templateUrl: './usuarioperfil.component.html',
  styleUrls: ['./usuarioperfil.component.css'],

})
export class UsuarioperfilComponent {

  public materias: Materia[];
  public institucionais: Materia[];

  constructor(public apiinfnet: ApiInfnetService, private router: Router) {
    this.ValidateToken();
  }

  private ValidateToken() {
    if (!localStorage.getItem('token')) {
      this.router.navigate(['/login']);
    }else{
      var usuario = JSON.parse(localStorage.getItem('usuario')) as Usuario;
      this.GetMaterias(usuario.id);
    }
  }

  private GetMaterias(userId: number) {
    if(localStorage.getItem('token')){
      this.apiinfnet.GetMaterias(localStorage.getItem('token'), userId).subscribe(retorno => {
        this.institucionais = retorno.filter(p => p.category == 16 || p.category == 55 || p.category == 56);
        this.materias = retorno.filter(p => p.category != 16 && p.category != 55 && p.category != 56);
      });
    }
  }

}
