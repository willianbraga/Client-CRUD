import { ClientResolve } from './utils/client.resolve';
import { ClientService } from './services/client.service';
import { rootRouterConfig } from './app.routes';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router'
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { EditClientComponent } from './components/edit-client/edit-client.component';
import { ListClientComponent } from './components/list-client/list-client.component';
import { NewClientComponent } from './components/new-client/new-client.component';

import { APP_BASE_HREF } from '@angular/common';
import { CustomFormsModule } from 'ngx-custom-validators';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    HomeComponent,
    SideMenuComponent,
    EditClientComponent,
    ListClientComponent,
    NewClientComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CustomFormsModule,
    ReactiveFormsModule,
    FormsModule,
    TextMaskModule,
    [RouterModule.forRoot(rootRouterConfig)]
  ],
  providers: [
    ClientService,
    ClientResolve,
    { provide: APP_BASE_HREF, useValue: '/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
