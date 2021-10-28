import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'toggleDisplay',
})
export class ToggleDisplayPipe implements PipeTransform {
  transform(value: any, exact: any): unknown {
    console.log('transform calling');
    return { display: value === exact ? 'block' : 'none' };
  }
}
