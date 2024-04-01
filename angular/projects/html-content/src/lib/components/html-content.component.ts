import { Component, OnInit } from '@angular/core';
import { HtmlContentService } from '../services/html-content.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ContentPageDto } from '../models/contentPages/contentPageDto';

@Component({
  selector: 'lib-html-content',
  templateUrl: './html-content.component.html',
  styleUrls: ['./html-content.component.css'],
  providers: [ListService],
})
export class HtmlContentComponent implements OnInit {
  content: any;
  myEntities = { items: [
  ], totalCount: 3 } as PagedResultDto<ContentPageDto>;

  contentForm: FormGroup;
  constructor(public readonly list: ListService, private service: HtmlContentService) {}

  ngOnInit(): void {
    this.getData();
  }
  
  onSubmit(): void {
  }


  getData(): void {
    this.service.getAllContent()
      .subscribe(response => {
        this.myEntities = response;
      });
  }
}
