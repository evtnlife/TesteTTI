import {Injectable} from '@angular/core';
import {retry, catchError} from 'rxjs/operators';
import {Observable, throwError} from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Categoria} from '../models/categoria';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {
    endpoint = 'http://localhost:4200/api';

    constructor(private httpClient: HttpClient) {
    }

    httpHeader = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };

    getAll(): Observable<Categoria[]> {
        return this.httpClient.get<Categoria[]>(this.endpoint + '/Categorias')
            .pipe(
                retry(1),
                catchError(this.processError)
            )
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
