import { Component, Input, OnInit } from '@angular/core';
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
        this.initClientForm();
        this.contentId = parseInt(this.route.snapshot.paramMap.get('id')?.toString()) || 0;
        // if(this.contentId != 0){
        //     this.htmlContentService.getContentById(this.contentId).subscribe({
        //         next: (data: any) => {
        //             this.contentForm = this.formBuilder.group({
        //                 id: [data.contentId],
        //                 name: [data.name, Validators.required],
        //                 content: [data.content, Validators.required]
        //             });

        //         },
        //         error: (error) => {
        //             console.error(error);
        //         }
        //     });
        // } else {
        //     this.contentForm = this.formBuilder.group({
        //         id: [this.contentId],
        //         name: [this.route.snapshot.paramMap.get('name'), Validators.required],
        //         content: [this.route.snapshot.paramMap.get('content'), Validators.required]
        //     });
        // }
        if(this.contentId != 0)
            this.getContentData(this.contentId);
    }

    onSubmit(): void {
        console.log(this.contentForm.value)
        this.htmlContentService.createOrUpdateContent(this.contentForm.value).subscribe({
            next: (data: any) => {
            },
            error: (error) => {
                console.error(error);
            }
        });
        this.router.navigate(['/html-content']);
    }

    loadContentData(id: number) {
        this.htmlContentService.getContentById(id)
            .subscribe(content => {
                this.contentForm.patchValue(content);
        });
    }

    getContentData(id: number) {
        this.htmlContentService.getContentById(id)
            .subscribe(content => {
                this.contentForm.patchValue(content);
        });
    }

    initClientForm(): void {
        this.contentForm = this.formBuilder.group({
            id: [null],
            name: [null],
            content: [null],
        });
      }
}