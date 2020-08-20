import { RouterModule, Routes } from '@angular/router';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';

const routes: Routes = [
	{ path: 'home', component: HomeComponent },
	{ path: 'products', component: ProductsComponent },
	{
		path: 'customers',
		loadChildren: () => import('./customers/customers.module').then(mod => mod.CustomersModule)
	},
	{
		path: 'categories',
		loadChildren: () => import('./categories/categories.module').then(mod => mod.CategoriesModule)
	},
	{
		path: '**', // Page Not Found
		redirectTo: 'home'
	}
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes)
	],
	exports: [
		RouterModule
	],
	schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppRoutingModule { }
