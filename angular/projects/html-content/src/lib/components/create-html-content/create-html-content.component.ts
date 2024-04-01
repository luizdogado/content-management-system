import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HtmlContentService } from '../../services/html-content.service';

@Component({
  selector: 'app-create-html-content',
  templateUrl: './create-html-content.component.html',
  styleUrls: ['./create-html-content.component.css']
})
export class CreateHtmlContentComponent implements OnInit {
  contentForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private htmlContentService: HtmlContentService) { }

  ngOnInit(): void {
    this.contentForm = this.formBuilder.group({
      title: [''],
      body: ['']
    });
  }

  onSubmit(): void {
    this.htmlContentService.createOrUpdateContent(this.contentForm.value).subscribe(() => {
      console.log('Novo conteúdo HTML criado com sucesso!');
      // Lógica adicional após a criação do conteúdo
    });
  }
}