import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Sizes } from 'src/app/core/models';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-svg',
  templateUrl: './svg.component.html',
  styleUrls: ['./svg.component.scss'],
})
export class SvgComponent implements OnInit, OnDestroy {
  link: string = '';
  @Input() name: string = '';
  @Input() size: Sizes = Sizes.Md;
  subs = new SubSink();

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
    this.subs.sink = this.httpClient
      .get(this.link, { responseType: 'text' })
      .subscribe((value) => {
        this.svgIcon = this.sanitizer.bypassSecurityTrustHtml(value);
      });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
