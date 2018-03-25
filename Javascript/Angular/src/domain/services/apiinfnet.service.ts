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

    GetMaterias(token: string, usuarioId : number) : Observable<Materia[]>{
        return this.http.get(SERVER_BASE_URL.base + "webservice/rest/server.php?wstoken=" + token + "&moodlewsrestformat=json&wsfunction=core_enrol_get_users_courses&userid=" + usuarioId).map(p => p.json() as Materia[]);
    }

    GetCompotencias(token: string, materiaId: string){
        var formData = new FormData();
        formData.append("moodlewssettingfilter", "true");
        formData.append("moodlewssettingfileurl", "true");
        formData.append("wsfunction", "tool_lp_data_for_course_competencies_page");
        formData.append("wstoken", token);
        formData.append("courseid", materiaId);

        return this.http.post(SERVER_BASE_URL.base + "webservice/rest/server.php?moodlewsrestformat=json", formData).map(p => p.json()['competencies']);
    }

    GetNotaCompetencia(token, materiaId, competenciaId, userId){
        var formData = new FormData();
        formData.append("moodlewssettingfilter", "true");
        formData.append("moodlewssettingfileurl", "true");
        formData.append("wsfunction", "tool_lp_data_for_user_competency_summary_in_course");
        formData.append("wstoken", token);
        formData.append("courseid", materiaId);
        formData.append("competencyid", competenciaId);
        formData.append("userid", userId);

        return this.http.post(SERVER_BASE_URL.base + "webservice/rest/server.php?moodlewsrestformat=json", formData).map(p => p.json()['usercompetencysummary']['usercompetencycourse']['gradename']);
    }
}