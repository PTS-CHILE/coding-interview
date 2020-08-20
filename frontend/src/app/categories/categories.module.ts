import { Routes, RouterModule } from '@angular/router';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoriesDetailComponent } from './categories-detail/categories-detail.component';
import { CategoriesService } from './categories.service';

const routes: Routes = [
	{ path: '', component: CategoriesListComponent },
	{ path: 'detail/:id', component: CategoriesDetailComponent }
];

@NgModule({
	declarations: [
		CategoriesListComponent,
		CategoriesDetailComponent
	],
	imports: [
		SharedModule,
		RouterModule.forChild(routes)
	],
	exports: [
		RouterModule
	],
	providers: [CategoriesService],
	schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CategoriesModule { }
