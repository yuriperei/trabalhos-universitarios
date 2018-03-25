import { Competencia } from './../../../domain/entities/competencia';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ApiInfnetService } from '../../../domain/services/apiinfnet.service';
import { Usuario } from '../../../domain/entities/usuario';

@Component({
  selector: 'app-materia',
  templateUrl: './materia.component.html',
  styleUrls: ['./materia.component.css']
})
export class MateriaComponent {

  // public usuario: Usuario = new Usuario();
  public description : string;
  public competencias: Competencia[];

  constructor(public apiinfnet: ApiInfnetService, private route: ActivatedRoute, private router: Router) { 
    this.validateToken();
    var token = localStorage.getItem('token');
    var usuario = JSON.parse(localStorage.getItem('usuario')) as Usuario;

    this.route.params.subscribe(params => {
      let materiaId = params['id'];
      this.description = params['fullname'];
      if(materiaId && usuario.id){
        this.apiinfnet.GetCompotencias(token, materiaId).subscribe(retorno => {
          this.competencias = retorno.map(item => {

            var competencyId = item['coursecompetency']['competencyid'];
            var description = item['competency']['description'];
            var competencia = new Competencia(competencyId, description);

            this.apiinfnet.GetNotaCompetencia(token, materiaId, competencyId, usuario.id).subscribe(nota => {
              competencia.nota = nota;
            });
            
            return competencia;

          }) as Competencia[];
        });
      }
      else{
        this.router.navigate(['/perfil']);
      }
    });
    
  }

  private validateToken() {
    if (!localStorage.getItem('token')) {
      this.router.navigate(['/login']);
    }
  }

}
