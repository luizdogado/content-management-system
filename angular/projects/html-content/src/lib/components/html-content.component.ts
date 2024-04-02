import { Component, OnInit } from '@angular/core';
import { HtmlContentService } from '../services/html-content.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ContentPageDto } from '../models/contentPages/contentPageDto';
import { Router } from '@angular/router';

@Component({
  selector: 'lib-html-content',
  templateUrl: './html-content.component.html',
  styleUrls: ['./html-content.component.css'],
  providers: [ListService],
})
export class HtmlContentComponent implements OnInit {
  myEntities = { items: [
  ], totalCount: 3 } as PagedResultDto<ContentPageDto>;

  contentForm: FormGroup;
  constructor(public readonly list: ListService, private service: HtmlContentService, private router: Router) {}

  ngOnInit(): void {
    this.getData();
  }
  
  onSubmit(): void {
  }

  navigateToContentView(id: number): void {
    this.router.navigate(['/content', id]);
  }

  navigateToContentCreate(id: number | null, valor1: string, valor2: string): void {
    this.router.navigate(['/content', { id: id, name: valor1, content: valor2}]);
  }

  getData(): void {
    this.service.getAllContent()
      .subscribe(response => {
        this.myEntities = response;
      });
  }
  
}
