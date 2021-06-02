import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
  EmployeeInformationMastersServiceProxy,
  CreateOrEditEmployeeInformationMasterDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
  selector: 'createOrEditEmployeeInformationMasterModal',
  templateUrl: './create-or-edit-employeeInformationMaster-modal.component.html',
})
export class CreateOrEditEmployeeInformationMasterModalComponent extends AppComponentBase implements OnInit {
  @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active = false;
  saving = false;

  employeeInformationMaster: CreateOrEditEmployeeInformationMasterDto = new CreateOrEditEmployeeInformationMasterDto();

  constructor(
    injector: Injector,
    private _employeeInformationMastersServiceProxy: EmployeeInformationMastersServiceProxy,
    private _dateTimeService: DateTimeService
  ) {
    super(injector);
  }

  show(employeeInformationMasterId?: number): void {
    if (!employeeInformationMasterId) {
      this.employeeInformationMaster = new CreateOrEditEmployeeInformationMasterDto();
      this.employeeInformationMaster.id = employeeInformationMasterId;
      this.employeeInformationMaster.doc = this._dateTimeService.getStartOfDay();
      this.employeeInformationMaster.dob = this._dateTimeService.getStartOfDay();
      this.employeeInformationMaster.confirmationDate = this._dateTimeService.getStartOfDay();
      this.employeeInformationMaster.doj = this._dateTimeService.getStartOfDay();
      this.employeeInformationMaster.rjDate = this._dateTimeService.getStartOfDay();

      this.active = true;
      this.modal.show();
    } else {
      this._employeeInformationMastersServiceProxy
        .getEmployeeInformationMasterForEdit(employeeInformationMasterId)
        .subscribe((result) => {
          this.employeeInformationMaster = result.employeeInformationMaster;

          this.active = true;
          this.modal.show();
        });
    }
  }

  save(): void {
    this.saving = true;

    this._employeeInformationMastersServiceProxy
      .createOrEdit(this.employeeInformationMaster)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(null);
      });
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

  ngOnInit(): void {}
}
