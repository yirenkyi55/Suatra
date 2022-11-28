import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'objectAccessor',
})
export class ObjectAccessorPipe implements PipeTransform {
  transform(value: any, key: string): any {
    if (!key) return value;

    let headerKeys = key.split('.');

    for (var i = 0; i < headerKeys.length - 1; i++) {
      let headerKey = headerKeys[i];
      const retrievedValue = value[headerKey];
      if (retrievedValue) {
        value = retrievedValue;
      } else {
        break;
      }
    }
    return value[headerKeys[i]];
  }
}
