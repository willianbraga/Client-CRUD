import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Client } from '../models/Client';
import { catchError, map } from 'rxjs/operators'
import { BaseService } from './base-service';

@Injectable()
export class ClientService extends BaseService {

    constructor(
        private http: HttpClient
    ) { super(); }
    public baseUrl = "http://localhost:5000/client/v1/";

    getAllClient(): Observable<Client[]> {
        return this.http
            .get<Client[]>(this.baseUrl)
    }

    getById(id: string): Observable<Client> {
        return this.http
            .get<Client>(this.baseUrl + id)
    }

    createClient(client: Client): Observable<Client> {
        let response = this.http
            .post(this.baseUrl, client)
            .pipe(
                map(this.extractData),
                catchError(this.serviceError)
            );
        return response;
    }

    updateClient(client: Client): Observable<Client> {
        let response = this.http
            .put(this.baseUrl, client)
            .pipe(
                map(this.extractData),
                catchError(this.serviceError)
            );
        return response;
    }

    deleteClient(id: string): Observable<Client> {
        let response = this.http
            .delete(this.baseUrl + id)
            .pipe(
                map(this.extractData),
                catchError(this.serviceError)
            );
        return response;
    }

}