import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { HtmlContentService } from '../../services/html-content.service';

@Component({
  selector: 'app-content-view',
  templateUrl: 'content-view.component.html'
})
export class ContentViewComponent implements OnInit {
  contentHTML: string;

  constructor(private route: ActivatedRoute, private service: HtmlContentService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    
    this.service.getContentById(id).subscribe({
      next: (data: any) => {
        this.contentHTML = data.content;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}