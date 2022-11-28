import { Pipe, PipeTransform } from '@angular/core';
import { LoadingStatus } from 'src/app/core/models';

@Pipe({
  name: 'statusLoading',
})
export class StatusLoadingPipe implements PipeTransform {
  transform(value: LoadingStatus | null): boolean {
    return value !== null && value === LoadingStatus.Loading;
  }
}
