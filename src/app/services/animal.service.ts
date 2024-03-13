import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {apiUrl} from "../enviroment/apiUrl";
import {IAnimal} from "../interfaces/animal";

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  constructor(private http: HttpClient) { }

  getAnimals(): Observable<any> {
    return this.http.get<any>(`${apiUrl}`);
  }

  insertAnimal(animal: IAnimal): Observable<any> {
    return this.http.post(`${apiUrl}`, animal);
  }
}
