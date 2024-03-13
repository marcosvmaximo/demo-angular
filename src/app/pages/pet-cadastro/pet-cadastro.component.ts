import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AnimalService} from "../../services/animal.service";
import {IAnimal} from "../../interfaces/animal";

@Component({
  selector: 'app-pet-cadastro',
  templateUrl: './pet-cadastro.component.html'
})
export class PetCadastroComponent implements OnInit {
  formPet: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private service: AnimalService) {
    this.formPet = this.formBuilder.group({});
  }

  ngOnInit(): void {
    this.formPet = this.formBuilder.group({
      nome: ['', [Validators.required]],
      porte: ['', [Validators.required]],
      descricao: ['', [Validators.required]]
    });
  }

  adicionar() {
    const animal: IAnimal = this.formPet.getRawValue() as IAnimal;

    this.service.insertAnimal(animal).subscribe((response) => {
      console.log("resposta da API", response);
    });
  }
}
