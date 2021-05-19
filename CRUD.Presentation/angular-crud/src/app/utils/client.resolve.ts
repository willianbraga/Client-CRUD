import { Client } from 'src/app/models/Client';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ClientService } from '../services/client.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ClientResolve implements Resolve<Client>{
    constructor(private clientService: ClientService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.clientService.getById(route.params['id']);
    }
}