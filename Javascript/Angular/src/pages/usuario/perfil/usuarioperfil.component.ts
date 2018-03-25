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

  public usuario: Usuario = new Usuario();
  public materias: Materia[];

  constructor(public apiinfnet: ApiInfnetService, private router: Router) {
    this.validateToken();
    this.LoadProfile();
  }

  public Materias() {
    if (this.materias != undefined) {
      return this.materias.filter(p => p.category != 16);
    }

  }

  public CentralAluno() {
    if (this.materias != undefined) {
      return this.materias.filter(p => p.category == 16);
    }
  }

  private validateToken() {
    if (!localStorage.getItem('token')) {
      this.router.navigate(['/login']);
    }
  }

  private LoadProfile() {
    this.apiinfnet.GetDataMoodle(localStorage.getItem('token')).subscribe(retorno => {
      this.usuario.id = retorno['userid'];
      this.usuario.pictureUrl = retorno['userpictureurl'];
      this.usuario.fullname = retorno['fullname'];
      this.getMateria();
    });
  }

  private getMateria() {
    this.apiinfnet.GetMaterias(localStorage.getItem('token'), this.usuario).subscribe(retorno => this.materias = retorno);
  }

  deslogar() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

}
