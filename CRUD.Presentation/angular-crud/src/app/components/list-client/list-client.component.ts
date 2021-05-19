import { Router } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from 'src/app/models/Client';

@Component({
  selector: 'app-list-client',
  templateUrl: './list-client.component.html',
  styleUrls: ['../../../css/styles.css']
})
export class ListClientComponent implements OnInit {
  public clients: Client[] = [];

  constructor(private clientService: ClientService, private router: Router) { }


  ngOnInit(): void {
    this.loadClients();
  }

  deleteClient(id: string) {
    if (!window.confirm('Deseja continuar com a exclusão do registro?'))
      return;
    this.clientService.deleteClient(id).subscribe(res => {
      this.loadClients();
    });
  }
  loadClients() {
    this.clientService.getAllClient()
      .subscribe(
        clients => {
          this.clients = clients;
          console.log(clients);
        },
        error => console.log(error)
      );
  }
}
