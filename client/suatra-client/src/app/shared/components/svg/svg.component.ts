import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Sizes } from 'src/app/core/models';

@Component({
  selector: 'app-svg',
  templateUrl: './svg.component.html',
  styleUrls: ['./svg.component.scss'],
})
export class SvgComponent implements OnInit {
  link: string = '';
  @Input() name: string = '';
  @Input() size: Sizes = Sizes.Md;

  svgIcon: any;
  constructor(
    private httpClient: HttpClient,
    private sanitizer: DomSanitizer
  ) {}

  get svgClass(): string {
    return `svg-${Sizes[this.size].toLocaleLowerCase()}`;
  }

  ngOnInit(): void {
    this.link = `/assets/images/svgs/${this.name}.svg`;

    console.log(this.link);
    this.httpClient
      .get(this.link, { responseType: 'text' })
      .subscribe((value) => {
        this.svgIcon = this.sanitizer.bypassSecurityTrustHtml(value);
      });
  }
}
