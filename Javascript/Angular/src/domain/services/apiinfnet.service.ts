import { Materia } from './../entities/materia';
import { SERVER_BASE_URL } from './../utilities/constants';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Usuario } from '../entities/usuario';

@Injectable()
export class ApiInfnetService {

    http: Http;
    headers: Headers;

    constructor(http: Http) {
        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
    }

    GetToken(usuario : Usuario) : Observable<string> {
        var formData = new FormData();
        formData.append("username", usuario.username);
        formData.append("password", usuario.password);
        formData.append("service", "moodle_mobile_app");

        return this.http.post(SERVER_BASE_URL.base + "login/token.php", formData).map(p => p.json());
    }

    GetDataMoodle(token: string) : Observable<string>{
        return this.http.get(SERVER_BASE_URL.base + "webservice/rest/server.php?wstoken=" + token + "&moodlewsrestformat=json&wsfunction=core_webservice_get_site_info").map(p => p.json());
    }

    GetMaterias(token: string, usuario : Usuario) : Observable<Materia[]>{
        console.log(usuario.id);
        console.log(SERVER_BASE_URL.base + "webservice/rest/server.php?wstoken=" + token + "&moodlewsrestformat=json&wsfunction=core_enrol_get_users_courses&userid=" + usuario.id);
        return this.http.get(SERVER_BASE_URL.base + "webservice/rest/server.php?wstoken=" + token + "&moodlewsrestformat=json&wsfunction=core_enrol_get_users_courses&userid=" + usuario.id).map(p => p.json() as Materia[]);
    }

    GetMateriasDetalhe(token: string, usuario : Usuario) : Observable<string>{
        return this.http.get(SERVER_BASE_URL.base + "webservice/rest/server.php?wstoken=" + token + "&moodlewsrestformat=json&wsfunction=core_enrol_get_users_courses&userid=" + usuario.id).map(p => p.json());
    }
}