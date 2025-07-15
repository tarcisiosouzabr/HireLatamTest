import { Component, OnInit, TemplateRef } from '@angular/core';
import { ProductResponse, ProductService } from './services/product.service';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  imports: [AsyncPipe, CommonModule, FormsModule, NgbModalModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private modal: NgbModal
  ) {}

  products$!: Observable<ProductResponse[]>;
  formModel: ProductResponse = { id: 0, name: '', price: 0 };
  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.products$ = this.productService.getProduct();
  }

  deleteProduct(id: number) {
    this.productService.deleteProduct(id).subscribe({
      next: () => this.loadProducts(),
      error: (err) => console.error(err),
    });
  }

  openModal(content: TemplateRef<any>) {
    this.formModel = { id: 0, name: '', price: 0 };
    this.modal.open(content);
  }

  submit(modal: any) {
    this.productService
      .postProduct(this.formModel.name, this.formModel.price)
      .subscribe(() => {
        this.loadProducts();
        modal.close();
      });
  }
}
