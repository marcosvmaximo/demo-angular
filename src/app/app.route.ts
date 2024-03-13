import {Routes} from "@angular/router";
import {HomeComponent} from "./pages/home/home.component";
import {PetComponent} from "./pages/pet/pet.component";
import {PetCadastroComponent} from "./pages/pet-cadastro/pet-cadastro.component";

export const rootRouterConfig: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: '#', redirectTo: 'home', pathMatch: 'full'},
  { path: 'home', component: HomeComponent},
  { path: 'pet', component: PetComponent},
  { path: 'pet-cadastro', component: PetCadastroComponent},
]
