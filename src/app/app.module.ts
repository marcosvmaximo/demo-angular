import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavBarComponent } from './pages/components/nav-bar/nav-bar.component';
import { FooterComponent } from './pages/components/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import {RouterModule, RouterOutlet} from "@angular/router";
import {rootRouterConfig} from "./app.route";
import { PetComponent } from './pages/pet/pet.component';
import { PetCadastroComponent } from './pages/pet-cadastro/pet-cadastro.component';
import {APP_BASE_HREF} from "@angular/common";
import {ReactiveFormsModule} from "@angular/forms";
import {AnimalService} from "./services/animal.service";
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    FooterComponent,
    HomeComponent,
    PetComponent,
    PetCadastroComponent
  ],
  imports: [
    BrowserModule,
    RouterOutlet,
    RouterModule.forRoot(rootRouterConfig, {useHash: false}),
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue: '/' },
    AnimalService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
