import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormGroupDirective, FormControl } from '@angular/forms';
import { CategoryResponse } from 'src/app/core/models';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.scss'],
})
export class CategoryFormComponent implements OnInit {
  form: FormGroup;
  @Input() items: any[] = [];
  @Input() control: FormControl;
  @Input() itemLabel: string = 'name';
  @Input() itemValue: string = 'id';
  @Input() placeHolderText: string;
  @Input() label: string;

  constructor() {}

  ngOnInit(): void {}
}
