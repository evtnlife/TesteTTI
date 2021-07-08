import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from "@angular/forms";
import {AppRoutingModule} from './app-routing.module';
import {HttpClientModule} from '@angular/common/http';

import {AppComponent} from './components/template/app.component';
import {ProductComponent} from "./components/produtos/product.component";
import {PedidoComponent} from "./components/pedidos/pedido.component";

@NgModule({
    declarations: [
        AppComponent,
        ProductComponent,
        PedidoComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}
