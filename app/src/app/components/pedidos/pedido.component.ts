import {Component} from '@angular/core';
import {ProductService} from 'src/app/services/product.service';
import {CategoryService} from "../../services/categoria.service";
import {Produto} from '../../models/produto';
import {Categoria} from "../../models/categoria";
import {Pedido} from "../../models/pedido";
import {PedidosService} from "../../services/pedidos.service";

@Component({
    selector: 'produto',
    templateUrl: './pedido.component.html',
    styleUrls: ['./pedido.component.css']
})
export class PedidoComponent {
    title = 'Lista de produtos';
    produtos: Produto[] = [];
    categorias: Categoria[] = [];
    pedidos:Pedido[] = [];
    // 0 - List
    // 1 - Edit
    // 2 - Cad
    pageStep: number = 0;
    pedido: Produto = {} as Produto;
    price: number = 0;
    error: string = '';

    constructor(
        private produtoService: ProductService,
        private categoryService: CategoryService,
        private pedidosService: PedidosService) {
    }

    ngOnInit() {
        this.getCategorias();
        this.getProdutos();
        this.getPedidos();
    }
    getPedidos(){
        this.pedidos= {} as Pedido[];
        this.pedidosService.getAll().subscribe((pedidos: Pedido[]) => {
            this.pedidos = pedidos;
        });
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

    createPedido() {
        this.pageStep = 2;
        this.localizaTitulo();
    }
    localizaTitulo() {
        switch (this.pageStep) {
            case 0:
                this.title = "Lista de pedidos";
                break;
            case 1:
                this.title = "Editar pedido";
                break;
            case 2:
                this.title = "Criar pedido";
                break;
        }
    }

    deletePedido(id: number) {

    }

    editPedido(pedido: Pedido) {

    }
}
