import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { ModalComponent } from './components/modal/modal.component';
import { ButtonComponent } from './components/button/button.component';
import { InputComponent } from './components/input/input.component';
import { TableComponent } from './components/table/table.component';
import { EditModeComponent } from './components/edit-mode/edit-mode.component';
import { SearchBoxComponent } from './components/search-box/search-box.component';
import { PaginatorComponent } from './components/paginator/paginator.component';
import { ListComponent } from './components/list/list.component';
import { TextAreaComponent } from './components/text-area/text-area.component';
import { DropDownComponent } from './components/drop-down/drop-down.component';
import { UploadComponent } from './components/upload/upload.component';
import { ToggleDisplayPipe } from './pipes/toggle-display.pipe';

const modules = [
  CommonModule,
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
  FontAwesomeModule,
  FormsModule,
  ReactiveFormsModule,
  NzNotificationModule,
  NzStepsModule,
];

const declarations = [
  ModalComponent,
  ButtonComponent,
  InputComponent,
  TableComponent,
  EditModeComponent,
  SearchBoxComponent,
  PaginatorComponent,
  PaginatorComponent,
  ListComponent,
  TextAreaComponent,
  DropDownComponent,
  UploadComponent,
];

@NgModule({
  declarations: [...declarations, ToggleDisplayPipe],
  imports: [...modules],
  exports: [...modules, ...declarations, ToggleDisplayPipe],
})
export class SharedModule {}
