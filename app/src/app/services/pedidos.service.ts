import {Injectable} from '@angular/core';
import {retry, catchError} from 'rxjs/operators';
import {Observable, Subscription, throwError} from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Produto} from '../models/produto';
import {Pedido} from "../models/pedido";

@Injectable({
    providedIn: 'root'
})
export class PedidosService {
    endpoint = 'http://localhost:4200/api';

    constructor(private httpClient: HttpClient) {
    }

    httpHeader = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };

    getAll(): Observable<Pedido[]> {
        return this.httpClient.get<Pedido[]>(this.endpoint + '/pedidos')
            .pipe(
                retry(1),
                catchError(this.processError)
            )
    }

    async updateProduct(produto: Produto): Promise<Subscription> {
        return this.httpClient.post(this.endpoint + '/produtos/update', produto)
            .subscribe(
                (resultado) => {
                    return true;
                },
                async (erro: any) => {
                    return false;
                }
            );
    }
    async insertProduct(produto: Produto): Promise<Subscription> {
        return this.httpClient.post(this.endpoint + '/produtos/insert', produto)
            .subscribe(
                (resultado) => {
                    return true;
                },
                async (erro: any) => {
                    return false;
                }
            );
    }
    async deleteProduct(produto: Produto): Promise<Subscription> {
        return this.httpClient.post(this.endpoint + '/produtos/delete', produto)
            .subscribe(
                (resultado) => {
                    return true;
                },
                async (erro: any) => {
                    return false;
                }
            );
    }
    processError(err: any) {
        let message = '';
        if (err.error instanceof ErrorEvent) {
            message = err.error.message;
        } else {
            message = `Error Code: ${err.status}\nMessage: ${err.message}`;
        }
        console.log(message);
        return throwError(message);
    }
}
