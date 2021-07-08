import {Component} from '@angular/core';
import {ProductService} from 'src/app/services/product.service';
import {CategoryService} from "../../services/categoria.service";
import {Produto} from '../../models/produto';
import {Categoria} from "../../models/categoria";

@Component({
    selector: 'produto',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})
export class ProductComponent {
    title = 'Lista de produtos';
    produtos: Produto[] = [];
    categorias: Categoria[] = [];
    // 0 - List
    // 1 - Edit
    // 2 - Cad
    pageStep: number = 0;
    produto: Produto = {} as Produto;
    messages: string[] = [];
    categoriaSelected: any = "-1";

    constructor(
        private produtoService: ProductService,
        private categoryService: CategoryService) {
    }

    ngOnInit() {
        this.getCategorias();
        this.getProdutos();
    }

    getProdutos() {
        this.produtos = {} as Produto[];
        this.produtoService.getAll().subscribe((prods: Produto[]) => {
            this.produtos = prods;
        });
    }

    getCategorias() {
        this.categoryService.getAll().subscribe((cats: Categoria[]) => {
            this.categorias = cats;
        });
    }

    createProduto() {
        this.pageStep = 2;
        this.messages = [];
        this.localizaTitulo();
    }

    editProduto(prod: Produto) {
        this.pageStep = 1;
        this.produto = prod;
        this.messages = [];
        this.localizaTitulo();
    }

    async deleteProduto(id: number) {
        var prod:Produto = {} as Produto;
        prod.id = id;
        let result = await this.produtoService.deleteProduct(prod);
        this.getProdutos();
    }

    async storeProduto() {
        this.messages = [];
        this.produto.categoriaId = parseInt(this.categoriaSelected);
        let validateForm = this.consisteDados();
        if (validateForm == null || validateForm.length > 0) {
            if (validateForm == null)
                this.messages.push("Falha ao validar dados");
            else
                this.messages = validateForm;
            return;
        }
        if (this.pageStep == 1) {
            let result = await this.produtoService.updateProduct(this.produto);
            if (result) {
                this.produto = {} as Produto;
                this.messages.push("Produto editado com sucesso.");
                this.pageStep = 0;
                this.getProdutos();

            } else
                this.messages.push("Falha ao atualizar produto");
        } else {
            let result = await this.produtoService.insertProduct(this.produto);
            if (result) {
                this.produto = {} as Produto;
                this.messages.push("Produto criado com sucesso.");
                this.pageStep = 0;
                this.getProdutos();
            } else
                this.messages.push("Falha ao criar produto");
        }
        this.localizaTitulo();
    }

    consisteDados() {
        var errors: string[] = [];
        try {
            if (this.produto.name.length < 3)
                errors.push("O nome do produto deve ter mais que três caracteres.");
            if (this.produto.price < 0)
                errors.push("O produto deve custar ao menos 1 centavo.");
            if (this.produto.categoriaId == -1)
                errors.push("Você deve selecionar uma categoria");
            return errors;
        } catch (e) {
            console.log(e);
            return null;
        }
    }

    localizaTitulo() {
        switch (this.pageStep) {
            case 0:
                this.title = "Lista de Produtos";
                break;
            case 1:
                this.title = "Editar produto";
                break;
            case 2:
                this.title = "Criar Produto";
                break;
        }
    }
}
