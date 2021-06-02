import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import {
  GetEmployeeInformationMasterForViewDto,
  EmployeeInformationMasterDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'viewEmployeeInformationMasterModal',
  templateUrl: './view-employeeInformationMaster-modal.component.html',
})
export class ViewEmployeeInformationMasterModalComponent extends AppComponentBase {
  @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active = false;
  saving = false;

  item: GetEmployeeInformationMasterForViewDto;

  constructor(injector: Injector) {
    super(injector);
    this.item = new GetEmployeeInformationMasterForViewDto();
    this.item.employeeInformationMaster = new EmployeeInformationMasterDto();
  }

  show(item: GetEmployeeInformationMasterForViewDto): void {
    this.item = item;
    this.active = true;
    this.modal.show();
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }
}
