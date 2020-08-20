import { RouterModule, Routes } from '@angular/router';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { CustomersListComponent } from './customers-list/customers-list.component';
import { CustomersDetailComponent } from './customers-detail/customers-detail.component';
import { CustomersService } from './customers.service';

const routes: Routes = [
	{ path: '', component: CustomersListComponent },
	{ path: 'detail/:id', component: CustomersDetailComponent }
];

@NgModule({
	declarations: [
		CustomersListComponent,
		CustomersDetailComponent
	],
	imports: [
		SharedModule,
		RouterModule.forChild(routes)
	],
	exports: [
		RouterModule
	],
	providers: [CustomersService],
	schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CustomersModule { }
