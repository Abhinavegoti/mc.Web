import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';

import { SubDepartmentsComponent } from './subDepartments/subDepartments/subDepartments.component';
import { ViewSubDepartmentModalComponent } from './subDepartments/subDepartments/view-subDepartment-modal.component';
import { CreateOrEditSubDepartmentModalComponent } from './subDepartments/subDepartments/create-or-edit-subDepartment-modal.component';

import { DepartmentsComponent } from './departments/departments/departments.component';
import { ViewDepartmentModalComponent } from './departments/departments/view-department-modal.component';
import { CreateOrEditDepartmentModalComponent } from './departments/departments/create-or-edit-department-modal.component';

import { EmployeeInformationMastersComponent } from './employeeInformationMasters/employeeInformationMasters/employeeInformationMasters.component';
import { ViewEmployeeInformationMasterModalComponent } from './employeeInformationMasters/employeeInformationMasters/view-employeeInformationMaster-modal.component';
import { CreateOrEditEmployeeInformationMasterModalComponent } from './employeeInformationMasters/employeeInformationMasters/create-or-edit-employeeInformationMaster-modal.component';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { PaginatorModule } from 'primeng/paginator';
import { EditorModule } from 'primeng/editor';
import { InputMaskModule } from 'primeng/inputmask';import { FileUploadModule } from 'primeng/fileupload';
import { TableModule } from 'primeng/table';

import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MainRoutingModule } from './main-routing.module';

import { BsDatepickerConfig, BsDaterangepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxBootstrapDatePickerConfigService } from 'assets/ngx-bootstrap/ngx-bootstrap-datepicker-config.service';

NgxBootstrapDatePickerConfigService.registerNgxBootstrapDatePickerLocales();

@NgModule({
    imports: [
		FileUploadModule,
		AutoCompleteModule,
		PaginatorModule,
		EditorModule,
		InputMaskModule,		TableModule,

        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        BsDatepickerModule.forRoot(),
        BsDropdownModule.forRoot(),
        PopoverModule.forRoot()
    ],
    declarations: [
		SubDepartmentsComponent,

		ViewSubDepartmentModalComponent,
		CreateOrEditSubDepartmentModalComponent,
		DepartmentsComponent,

		ViewDepartmentModalComponent,
		CreateOrEditDepartmentModalComponent,
		EmployeeInformationMastersComponent,

		ViewEmployeeInformationMasterModalComponent,
		CreateOrEditEmployeeInformationMasterModalComponent,
        DashboardComponent
    ],
    providers: [
        { provide: BsDatepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerConfig },
        { provide: BsDaterangepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDaterangepickerConfig },
        { provide: BsLocaleService, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerLocale }
    ]
})
export class MainModule { }
