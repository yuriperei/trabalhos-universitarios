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

    token(usuario : Usuario) : Observable<string> {
        var formData = new FormData();
        formData.append("username", usuario.username);
        formData.append("password", usuario.password);
        formData.append("service", "moodle_mobile_app");

        // Object.keys(usuario).forEach(key => {
        //     formData.append(key, usuario[key]);
        // });

        return this.http.post(SERVER_BASE_URL.base + "login/token.php", formData).map(p => p.json());
    }
}