import {Component, OnInit} from '@angular/core';
import {AnimalService} from "../../services/animal.service";
import {IAnimal} from "../../interfaces/animal";

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html'
})
export class PetComponent implements OnInit{
  public animals: IAnimal[] = [];
  constructor(private service: AnimalService) {
  }

  ngOnInit(): void {
    this.getAnimals();
  }

  getAnimals(){
    this.service.getAnimals().subscribe((response) => {
      this.animals = response;
    }, (error) => {
      console.error(error);
    })
  }
}
