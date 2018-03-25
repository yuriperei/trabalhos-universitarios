import { UsuariologinComponent } from './../pages/usuario/login/usuariologin.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UsuarioperfilComponent } from '../pages/usuario/perfil/usuarioperfil.component';
import { MateriaComponent } from '../pages/usuario/materia/materia.component';

const appRoutes: Routes = [

    { path: '', redirectTo: 'login', pathMatch: 'full' },

    { path: 'login', component: UsuariologinComponent },
    { path: 'perfil', component: UsuarioperfilComponent },

    { path: 'materia/:id/:fullname', component: MateriaComponent },

    { path: '**', redirectTo: 'login' }

];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }