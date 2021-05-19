import { Observable, merge, fromEvent } from 'rxjs';
import { ValidationMessages, Genericvalidator, DisplayMessage } from '../../utils/generic-form-validation';
import { Client } from 'src/app/models/Client';
import { Router, ActivatedRoute } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { FormBuilder, FormGroup, Validators, FormControlName } from '@angular/forms';
import { Component, OnInit, AfterViewInit, ElementRef, ViewChildren } from '@angular/core';
import { utilsBr } from 'js-brasil';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['../../../css/styles.css']
})
export class EditClientComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];


  errors: any[] = [];
  clientForm: FormGroup;
  client: Client;

  validationMessages: ValidationMessages;
  genericValidator: Genericvalidator;
  displayMessage: DisplayMessage = {};

  MASK = utilsBr.MASKS;

  constructor(
    private fb: FormBuilder,
    private clientService: ClientService,
    private router: Router,
    private route: ActivatedRoute) {
    this.validationMessages = {
      name: {
        required: 'Informe o nome',
        name: 'Nome inválido'
      },
      email: {
        required: 'Informe o email',
        email: 'Email inválido'
      },
      phone: {
        required: 'Informe o telefone',
        phone: 'Telefone inválido'
      },
      birthDate: {
        required: 'Informe a data de nascimento',
        birthDate: 'Data inválida'
      }
    }

    this.genericValidator = new Genericvalidator(this.validationMessages);

    this.client = this.route.snapshot.data['client'];
  }


  ngOnInit(): void {
    this.clientForm = this.fb.group(
      {
        name: ['', Validators.compose([
          Validators.minLength(1),
          Validators.maxLength(100),
          Validators.required,
        ])],
        phone: ['', Validators.compose([
          Validators.minLength(8),
          Validators.maxLength(10),
          Validators.required,
        ])],
        email: ['', Validators.compose([
          Validators.email,
          Validators.required,
        ])],
        birthDate: [new Date().toJSON().substring(0, 10), Validators.required]
      });

    this.fillForm();
  }

  fillForm() {
    this.clientForm.patchValue({
      id: this.client.id,
      name: this.client.name,
      phone: this.client.phone,
      email: this.client.email,
      birthDate: this.client.birthDate.toString()
    });
  }


  ngAfterViewInit(): void {

    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(() => {
      this.displayMessage = this.genericValidator.loadMessage(this.clientForm);
    });
  }

  submit() {
    console.log(this.client);
    if (this.clientForm.dirty && !this.clientForm.valid) {
      this.client = Object.assign({}, this.client, this.clientForm.value);

      this.clientService.updateClient(this.clientForm.value).subscribe(res => {
        this.router.navigateByUrl("/");
      });
    }
  }

}