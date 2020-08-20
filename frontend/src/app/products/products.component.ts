import { take } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';

import { ProductsService } from './products.service';
import { LoaderHelperService } from '../loader/loader-helper.service';

@Component({
	selector: 'app-products',
	templateUrl: './products.component.html',
	styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
	products: any[];

	constructor(
		private loader: LoaderHelperService,
		private productsService: ProductsService
	) { }

	ngOnInit(): void {
		this.getProducts();
	}

	getProducts(filters?: string): void {
		this.loader.toggle({ show: true, text: 'Carregando Produtos...' });
		this.productsService.getProducts(filters).pipe(take(1)).subscribe(
			success => {
				this.loader.toggle({ show: false });
				if (success && Array.isArray(success) && success.length > 0) {
					this.products = success;
				}
			}, error => {
				this.loader.toggle({ show: false });
				toastr.error('Algumas informações não puderam ser carregadas.', 'Ops!');
				console.log('Products Error: ', error);
			}
		);
	}

}
