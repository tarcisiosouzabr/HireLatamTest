import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private httpClient: HttpClient) {}

  getProduct(): Observable<ProductResponse[]> {
    return this.httpClient.get<ProductResponse[]>(
      'https://localhost:7261/api/product'
    );
  }

  postProduct(name: string, price: number): Observable<ProductResponse> {
    return this.httpClient.post<ProductResponse>(
      'https://localhost:7261/api/product',
      { name, price }
    );
  }

  deleteProduct(id: number): Observable<void> {
    return this.httpClient.delete<void>(
      'https://localhost:7261/api/product/' + id
    );
  }
}

export interface ProductResponse {
  id: number;
  name: string;
  price: number;
}
