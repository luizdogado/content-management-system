import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HtmlContentService } from '../../services/html-content.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-create-html-content',
  templateUrl: 'content-create.component.html',
  styleUrls: ['content-create.component.css']
})
export class CreateHtmlContentComponent implements OnInit {
    contentForm: FormGroup;
    contentId: number;
constructor(private formBuilder: FormBuilder, private route: ActivatedRoute, private htmlContentService: HtmlContentService, private router: Router) { }

    ngOnInit(): void {
        this.contentForm = this.formBuilder.group({
            id: [this.route.snapshot.params['id']], // Set initial value for id
            name: [this.route.snapshot.paramMap.get('name'), Validators.required],
            content: [this.route.snapshot.paramMap.get('content'), Validators.required]
        });
    }

    loadContentData(id: number) {
        this.htmlContentService.getContentById(id)
            .subscribe(content => {
                this.contentForm.patchValue(content); // Patch existing data to form
        });
    }

    onSubmit(): void {
        this.htmlContentService.createOrUpdateContent(this.contentForm.value).subscribe({
            next: (data: any) => {
            },
            error: (error) => {
              console.error(error);
            }
          });
          this.router.navigate(['/html-content'])
    }
}