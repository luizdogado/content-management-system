import { Component, OnInit } from '@angular/core';
import { HtmlContentService } from '../services/html-content.service';
import { FormGroup } from '@angular/forms';
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
  pageSize = 10;
  skip = 0;
  contentForm: FormGroup;
  
  constructor(public readonly list: ListService, 
    private service: HtmlContentService,
    private router: Router) {}

  ngOnInit(): void {
    this.loadData();
  }
  
  onSubmit(): void {
  }

  navigateToContentView(id: number): void {
    this.router.navigate(['/content', id]);
  }

  navigateToContentCreate(id: number | null): void {
    this.router.navigate(['/content', { id: id }]);
  }

  loadData(): void {
    this.service.getAllContent(this.skip, this.pageSize)
      .subscribe(response => {
        this.myEntities = response;
      });
  }

  onPage(event) {
    let offset = event.pageSize * event.offset;
    this.service.getAllContent(offset, this.pageSize)
      .subscribe(response => {
        this.myEntities = response;
    });
  }
}
