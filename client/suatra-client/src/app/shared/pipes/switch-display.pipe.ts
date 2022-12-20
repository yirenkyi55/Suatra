import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'switchDisplay',
})
export class SwitchDisplayPipe implements PipeTransform {
  transform(value: any, arg: any) {
    return { display: value === arg ? 'block' : 'none' };
  }
}
