import { take } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { CustomersService } from '../customers.service';
import { LoaderHelperService } from 'src/app/loader/loader-helper.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EnumsService } from 'src/app/shared/api-services/enums.service';

@Component({
	selector: 'app-customers-list',
	templateUrl: './customers-list.component.html',
	styleUrls: ['./customers-list.component.scss']
})
export class CustomersListComponent implements OnInit {
	customers: any[];
	status: any[] = [];
	filterForm: FormGroup;

	constructor(
		private router: Router,
		private formBuilder: FormBuilder,
		private enumsService: EnumsService,
		private loader: LoaderHelperService,
		private customersService: CustomersService
	) { }

	ngOnInit(): void {
		this.filterForm = this.formBuilder.group({
			status: [null]
		});

		this.enumsService.getEnum('customerstatustypes').pipe(take(1)).subscribe(
			success => {
				if (success) {
					this.status = success;
				}
			}, error => console.log(error)
		);

		this.getCustomers();
	}

	getCustomers(filters?: string): void {
		this.loader.toggle({ show: true, text: 'Carregando Clientes...' });
		this.customersService.getCustomers(filters).pipe(take(1)).subscribe(
			success => {
				this.loader.toggle({ show: false });
				if (success && Array.isArray(success) && success.length > 0) {
					this.customers = success;
				}
			}, error => {
				this.loader.toggle({ show: false });
				toastr.error('Algumas informações não puderam ser carregadas.', 'Ops!');
				console.log('Customers Error: ', error);
			}
		);
	}

	search(): void {
		// Get filters
		const statusValue = this.filterForm.get('status')?.value ? parseInt(this.filterForm.get('status')?.value, 10) : null;
		const filters = `status=${statusValue}`;
		this.getCustomers(filters);
	}

	clearFilters(): void {
		this.filterForm.reset();
	}

	goToDetail(id: number): void {
		this.router.navigateByUrl(`customers/detail/${id}`);
	}

	create(): void {
		this.router.navigateByUrl(`customers/detail/0`);
	}

}
