import { ClientResolve } from './utils/client.resolve';
import { NewClientComponent } from './components/new-client/new-client.component';
import { EditClientComponent } from './components/edit-client/edit-client.component';
import { HomeComponent } from './components/home/home.component';
import { Routes } from "@angular/router";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    {
        path: 'edit/:id', component: EditClientComponent,
        resolve: {
            client: ClientResolve
        }
    },
    { path: 'new', component: NewClientComponent }

]