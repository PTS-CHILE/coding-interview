import { take } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CategoriesService } from '../categories.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoaderHelperService } from 'src/app/loader/loader-helper.service';

@Component({
	selector: 'app-categories-detail',
	templateUrl: './categories-detail.component.html',
	styleUrls: ['./categories-detail.component.scss']
})
export class CategoriesDetailComponent implements OnInit {
	paramId = 0;
	categoryForm: FormGroup;
	headerText = 'Nova Categoria';

	get _categoryName() { return this.categoryForm.get('name'); }

	constructor(
		private router: Router,
		private formBuilder: FormBuilder,
		private loader: LoaderHelperService,
		private activatedRoute: ActivatedRoute,
		private categoriesService: CategoriesService
	) { }

	ngOnInit(): void {
		this.categoryForm = this.formBuilder.group({
			id: [null],
			name: [null, [Validators.required, Validators.maxLength(50)]]
		});

		this.activatedRoute.params.subscribe((params: any) => {
			if (params.hasOwnProperty('id') && params.id && params.id > 0) {
				// Edit
				this.paramId = parseInt(params.id, 10);
				this.loader.toggle({ show: true });
				this.categoriesService.getCategoryById(this.paramId).pipe(take(1)).subscribe(
					success => {
						this.loader.toggle({ show: false });
						this.headerText = `Edita Categoria #${params.id}`;
						if (success) {
							this.categoryForm.patchValue(success);
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
		this.router.navigateByUrl('categories');
	}

	deleteCategory(): void {
		this.loader.toggle({ show: true, text: 'Deletando Categoria...' });
		this.categoriesService.deleteCategory(this.paramId).pipe(take(1)).subscribe(
			() => {
				this.loader.toggle({ show: false });
				toastr.success('Categoria deletada com sucesso!', 'Yeah!');
				this.cancel();
			}, error => {
				this.loader.toggle({ show: false });
				console.log(error);
				toastr.error('Ocorreu um erro ao deletar.', 'Ops!');
			}
		);
	}

	confirm(): void {
		for (const key in this.categoryForm.controls) {
			if (this.categoryForm.controls.hasOwnProperty(key)) {
				this.categoryForm.controls[key].markAsDirty();
				this.categoryForm.controls[key].updateValueAndValidity();
			}
		}

		if (this.categoryForm.valid) {
			if (this.paramId > 0) {
				// Update
				this.loader.toggle({ show: true, text: 'Atualizando Categoria...' });
				this.categoriesService.updateCategory(this.paramId, this.categoryForm.getRawValue()).pipe(take(1)).subscribe(
					() => {
						this.loader.toggle({ show: false });
						toastr.success('Categoria atualizada com sucesso!', 'Yeah!');
						this.cancel();
					}, error => {
						this.loader.toggle({ show: false });
						console.log(error);
						toastr.error('Ocorreu um erro ao atualizar.', 'Ops!');
					}
				);
			}	else {
				// Create
				this.loader.toggle({ show: true, text: 'Criando Categoria...' });
				this.categoriesService.createCategory(this.categoryForm.getRawValue()).pipe(take(1)).subscribe(
					() => {
						this.loader.toggle({ show: false });
						toastr.success('Categoria criada com sucesso!', 'Yeah!');
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
