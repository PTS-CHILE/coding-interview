import { forkJoin } from 'rxjs';
import { take } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { CustomersService } from '../customers.service';
import { LoaderHelperService } from 'src/app/loader/loader-helper.service';

@Component({
	selector: 'app-customers-detail',
	templateUrl: './customers-detail.component.html',
	styleUrls: ['./customers-detail.component.scss']
})
export class CustomersDetailComponent implements OnInit {
	paramId = 0;
	categories: any[] = [];
	customerForm: FormGroup;
	headerText = 'Novo Cliente';

	get _customerName() { return this.customerForm.get('name'); }
	get _customerStatus() { return this.customerForm.get('status'); }
	get _customerCategoryId() { return this.customerForm.get('categoryId'); }
	get _customerDocumentNumber() { return this.customerForm.get('documentNumber'); }

	constructor(
		private router: Router,
		private formBuilder: FormBuilder,
		private loader: LoaderHelperService,
		private activatedRoute: ActivatedRoute,
		private customersService: CustomersService
	) { }

	ngOnInit(): void {
		this.customerForm = this.formBuilder.group({
			id: [null],
			documentNumber: [null, [Validators.required, Validators.maxLength(15)]],
			name: [null, [Validators.required, Validators.maxLength(50)]],
			categoryId: [null, [Validators.required]]
		});

		this.activatedRoute.params.subscribe((params: any) => {
			const requests = [
				// this.customersService.getCategories()
			];

			if (params.hasOwnProperty('id') && params.id && params.id > 0) {
				// Edit
				this.headerText = `Editar Cliente #${params.id}`;
				this.paramId = parseInt(params.id, 10);
				requests.push(this.customersService.getCustomerById(this.paramId));
			} else {
				// New
			}

			if (requests.length > 0) {
				this.loader.toggle({ show: true });
				forkJoin(requests).pipe(take(1)).subscribe(
					results => {
						this.loader.toggle({ show: false });
						if (results) {
							// this.categories = results[0] || [];

							if (results[0]) {
								this.customerForm.patchValue(results[0]);
							}
						}
					}, error => {
						this.loader.toggle({ show: false });
						console.log(error);
						toastr.error('Algumas informações não puderam ser carregadas.', 'Ops!');
					}
				);
			}
		});
	}

	cancel(): void {
		this.router.navigateByUrl('customers');
	}

	deleteCustomer(): void {
		this.loader.toggle({ show: true, text: 'Deletando Cliente...' });
		this.customersService.deleteCustomer(this.paramId).pipe(take(1)).subscribe(
			() => {
				this.loader.toggle({ show: false });
				toastr.success('Cliente deletado com sucesso!', 'Yeah!');
				this.cancel();
			}, error => {
				this.loader.toggle({ show: false });
				console.log(error);
				toastr.error('Ocorreu um erro ao deletar.', 'Ops!');
			}
		);
	}

	confirm(): void {
		for (const key in this.customerForm.controls) {
			if (this.customerForm.controls.hasOwnProperty(key)) {
				this.customerForm.controls[key].markAsDirty();
				this.customerForm.controls[key].updateValueAndValidity();
			}
		}

		if (this.customerForm.valid) {
			const formValues = this.customerForm.getRawValue();
			formValues.categoryId = parseInt(formValues.categoryId, 10);

			if (this.paramId > 0) {
				// Update
				this.loader.toggle({ show: true, text: 'Atualizando Cliente...' });
				this.customersService.updateCustomer(this.paramId, formValues).pipe(take(1)).subscribe(
					() => {
						this.loader.toggle({ show: false });
						toastr.success('Cliente atualizado com sucesso!', 'Yeah!');
						this.cancel();
					}, error => {
						this.loader.toggle({ show: false });
						console.log(error);
						toastr.error('Ocorreu um erro ao atualizar.', 'Ops!');
					}
				);
			}	else {
				// Create
				this.loader.toggle({ show: true, text: 'Criando Cliente...' });
				this.customersService.createCustomer(formValues).pipe(take(1)).subscribe(
					() => {
						this.loader.toggle({ show: false });
						toastr.success('Cliente criado com sucesso!', 'Yeah!');
						this.cancel();
					}, error => {
						this.loader.toggle({ show: false });
						console.log(error);
						toastr.error('Ocorreu um erro ao criar.', 'Ops!');
					}
				);
			}
		} else {
			toastr.error('Há um ou mais erros no formulário.', 'Ops!');
		}
	}

}
