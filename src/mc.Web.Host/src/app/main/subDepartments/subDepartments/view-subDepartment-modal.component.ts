import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetSubDepartmentForViewDto, SubDepartmentDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'viewSubDepartmentModal',
  templateUrl: './view-subDepartment-modal.component.html',
})
export class ViewSubDepartmentModalComponent extends AppComponentBase {
  @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active = false;
  saving = false;

  item: GetSubDepartmentForViewDto;

  constructor(injector: Injector) {
    super(injector);
    this.item = new GetSubDepartmentForViewDto();
    this.item.subDepartment = new SubDepartmentDto();
  }

  show(item: GetSubDepartmentForViewDto): void {
    this.item = item;
    this.active = true;
    this.modal.show();
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }
}
