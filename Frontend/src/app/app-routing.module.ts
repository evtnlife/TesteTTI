import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './components/template/app.component';
import { ProductComponent } from './components/produtos/product.component';
import {PedidoComponent} from "./components/pedidos/pedido.component";

const routes: Routes = [
  { path: 'product', component: ProductComponent },
  { path: 'pedidos', component: PedidoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
