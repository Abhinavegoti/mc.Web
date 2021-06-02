import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
  SubDepartmentsServiceProxy,
  CreateOrEditSubDepartmentDto,
  SubDepartmentDepartmentLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
  selector: 'createOrEditSubDepartmentModal',
  templateUrl: './create-or-edit-subDepartment-modal.component.html',
})
export class CreateOrEditSubDepartmentModalComponent extends AppComponentBase implements OnInit {
  @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active = false;
  saving = false;

  subDepartment: CreateOrEditSubDepartmentDto = new CreateOrEditSubDepartmentDto();

  departmentName = '';

  allDepartments: SubDepartmentDepartmentLookupTableDto[];

  constructor(
    injector: Injector,
    private _subDepartmentsServiceProxy: SubDepartmentsServiceProxy,
    private _dateTimeService: DateTimeService
  ) {
    super(injector);
  }

  show(subDepartmentId?: number): void {
    if (!subDepartmentId) {
      this.subDepartment = new CreateOrEditSubDepartmentDto();
      this.subDepartment.id = subDepartmentId;
      this.departmentName = '';

      this.active = true;
      this.modal.show();
    } else {
      this._subDepartmentsServiceProxy.getSubDepartmentForEdit(subDepartmentId).subscribe((result) => {
        this.subDepartment = result.subDepartment;

        this.departmentName = result.departmentName;

        this.active = true;
        this.modal.show();
      });
    }
    this._subDepartmentsServiceProxy.getAllDepartmentForTableDropdown().subscribe((result) => {
      this.allDepartments = result;
    });
  }

  save(): void {
    this.saving = true;

    this._subDepartmentsServiceProxy
      .createOrEdit(this.subDepartment)
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
