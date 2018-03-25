import { Component, Input } from '@angular/core';
import { ApiInfnetService } from '../../domain/services/apiinfnet.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Usuario } from '../../domain/entities/usuario';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  public usuario: Usuario = new Usuario();

  constructor(public apiinfnet: ApiInfnetService, private router: Router) { 
    this.usuario = JSON.parse(localStorage.getItem('usuario')) as Usuario;
  }

  private Deslogar() {
    localStorage.removeItem('token');
    localStorage.removeItem('usuario');
    this.router.navigate(['/login']);
  }
  
}
