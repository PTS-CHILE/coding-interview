import { take } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { CategoriesService } from '../categories.service';
import { LoaderHelperService } from 'src/app/loader/loader-helper.service';

@Component({
	selector: 'app-categories-list',
	templateUrl: './categories-list.component.html',
	styleUrls: ['./categories-list.component.scss']
})
export class CategoriesListComponent implements OnInit {
	categories: any[];

	constructor(
		private router: Router,
		private loader: LoaderHelperService,
		private categoriesService: CategoriesService
	) { }

	ngOnInit(): void {
		this.loader.toggle({ show: true, text: 'Carregando Categorias...' });
		this.categoriesService.getCategories().pipe(take(1)).subscribe(
			success => {
				this.loader.toggle({ show: false });
				if (success && Array.isArray(success) && success.length > 0) {
					this.categories = success;
				}
			}, error => {
				this.loader.toggle({ show: false });
				toastr.error('Algumas informações não puderam ser carregadas.', 'Ops!');
				console.log('Categories Error: ', error);
			}
		);
	}

	goToDetail(id: number): void {
		this.router.navigateByUrl(`categories/detail/${id}`);
	}

	create(): void {
		this.router.navigateByUrl(`categories/detail/0`);
	}

}
