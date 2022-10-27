import { NgModule } from '@angular/core';

import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzProgressModule } from 'ng-zorro-antd/progress';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzEmptyModule } from 'ng-zorro-antd/empty';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzStepsModule } from 'ng-zorro-antd/steps';
import { NzNotificationModule } from 'ng-zorro-antd/notification';

const modules = [
  NzInputModule,
  NzDropDownModule,
  NzCheckboxModule,
  NzInputNumberModule,
  NzUploadModule,
  NzToolTipModule,
  NzModalModule,
  NzProgressModule,
  NzPopconfirmModule,
  NzIconModule,
  NzPaginationModule,
  NzRadioModule,
  NzEmptyModule,
  NzMessageModule,
  NzDatePickerModule,
  NzSelectModule,
  NzTagModule,
  NzFormModule,
  NzLayoutModule,
  NzAvatarModule,
  NzPopoverModule,
  NzTableModule,
  NzListModule,
  NzBadgeModule,
  NzSpinModule,
  NzNotificationModule,
  NzStepsModule,
];

@NgModule({
  declarations: [],
  imports: modules,
  exports: modules,
})
export class AntModule {}
