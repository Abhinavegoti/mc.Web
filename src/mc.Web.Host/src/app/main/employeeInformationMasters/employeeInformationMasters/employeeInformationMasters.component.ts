import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  EmployeeInformationMastersServiceProxy,
  EmployeeInformationMasterDto,
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditEmployeeInformationMasterModalComponent } from './create-or-edit-employeeInformationMaster-modal.component';

import { ViewEmployeeInformationMasterModalComponent } from './view-employeeInformationMaster-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
  templateUrl: './employeeInformationMasters.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})
export class EmployeeInformationMastersComponent extends AppComponentBase {
  @ViewChild('createOrEditEmployeeInformationMasterModal', { static: true })
  createOrEditEmployeeInformationMasterModal: CreateOrEditEmployeeInformationMasterModalComponent;
  @ViewChild('viewEmployeeInformationMasterModalComponent', { static: true })
  viewEmployeeInformationMasterModal: ViewEmployeeInformationMasterModalComponent;

  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;

  advancedFiltersAreShown = false;
  filterText = '';
  empIdFilter = '';
  maxBioIdFilter: number;
  maxBioIdFilterEmpty: number;
  minBioIdFilter: number;
  minBioIdFilterEmpty: number;
  internalIdFilter = '';
  maxDocFilter: DateTime;
  minDocFilter: DateTime;
  nameFilter = '';
  forHFilter = '';
  maxDobFilter: DateTime;
  minDobFilter: DateTime;
  presentAddressFilter = '';
  permanentAddressFilter = '';
  genderFilter = '';
  contactNoFilter = '';
  altContactNoFilter = '';
  maritalStatusFilter = '';
  maxNoOfDependentsFilter: number;
  maxNoOfDependentsFilterEmpty: number;
  minNoOfDependentsFilter: number;
  minNoOfDependentsFilterEmpty: number;
  maxConfirmationDateFilter: DateTime;
  minConfirmationDateFilter: DateTime;
  maxDOJFilter: DateTime;
  minDOJFilter: DateTime;
  ihExpFilter = '';
  maxTotalExpFilter: number;
  maxTotalExpFilterEmpty: number;
  minTotalExpFilter: number;
  minTotalExpFilterEmpty: number;
  pfNoFilter = '';
  esiNoFilter = '';
  acNoFilter = '';
  ppNoFilter = '';
  panFilter = '';
  bgFilter = '';
  maxCLFilter: number;
  maxCLFilterEmpty: number;
  minCLFilter: number;
  minCLFilterEmpty: number;
  maxELFilter: number;
  maxELFilterEmpty: number;
  minELFilter: number;
  minELFilterEmpty: number;
  maxSLFilter: number;
  maxSLFilterEmpty: number;
  minSLFilter: number;
  minSLFilterEmpty: number;
  maxBasicSalaryFilter: number;
  maxBasicSalaryFilterEmpty: number;
  minBasicSalaryFilter: number;
  minBasicSalaryFilterEmpty: number;
  maxDAFilter: number;
  maxDAFilterEmpty: number;
  minDAFilter: number;
  minDAFilterEmpty: number;
  maxHRAFilter: number;
  maxHRAFilterEmpty: number;
  minHRAFilter: number;
  minHRAFilterEmpty: number;
  maxConveyanceFilter: number;
  maxConveyanceFilterEmpty: number;
  minConveyanceFilter: number;
  minConveyanceFilterEmpty: number;
  maxIncentiveFilter: number;
  maxIncentiveFilterEmpty: number;
  minIncentiveFilter: number;
  minIncentiveFilterEmpty: number;
  maxMedicalAllowanceFilter: number;
  maxMedicalAllowanceFilterEmpty: number;
  minMedicalAllowanceFilter: number;
  minMedicalAllowanceFilterEmpty: number;
  maxOtherAllowancesFilter: number;
  maxOtherAllowancesFilterEmpty: number;
  minOtherAllowancesFilter: number;
  minOtherAllowancesFilterEmpty: number;
  maxTotalSalaryFilter: number;
  maxTotalSalaryFilterEmpty: number;
  minTotalSalaryFilter: number;
  minTotalSalaryFilterEmpty: number;
  photoFilter = '';
  maxUanNoFilter: number;
  maxUanNoFilterEmpty: number;
  minUanNoFilter: number;
  minUanNoFilterEmpty: number;
  isActiveFilter = -1;
  employeementUnderFilter = '';
  divisionFilter = '';
  maxContractorIdFilter: number;
  maxContractorIdFilterEmpty: number;
  minContractorIdFilter: number;
  minContractorIdFilterEmpty: number;
  messBillFilter = -1;
  onrollFilter = -1;
  nameInTeluguFilter = '';
  maxRjDateFilter: DateTime;
  minRjDateFilter: DateTime;
  documentFilter = '';
  extensionFilter = '';

  constructor(
    injector: Injector,
    private _employeeInformationMastersServiceProxy: EmployeeInformationMastersServiceProxy,
    private _notifyService: NotifyService,
    private _tokenAuth: TokenAuthServiceProxy,
    private _activatedRoute: ActivatedRoute,
    private _fileDownloadService: FileDownloadService,
    private _dateTimeService: DateTimeService
  ) {
    super(injector);
  }

  getEmployeeInformationMasters(event?: LazyLoadEvent) {
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this._employeeInformationMastersServiceProxy
      .getAll(
        this.filterText,
        this.empIdFilter,
        this.maxBioIdFilter == null ? this.maxBioIdFilterEmpty : this.maxBioIdFilter,
        this.minBioIdFilter == null ? this.minBioIdFilterEmpty : this.minBioIdFilter,
        this.internalIdFilter,
        this.maxDocFilter === undefined
          ? this.maxDocFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxDocFilter),
        this.minDocFilter === undefined
          ? this.minDocFilter
          : this._dateTimeService.getStartOfDayForDate(this.minDocFilter),
        this.nameFilter,
        this.forHFilter,
        this.maxDobFilter === undefined
          ? this.maxDobFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxDobFilter),
        this.minDobFilter === undefined
          ? this.minDobFilter
          : this._dateTimeService.getStartOfDayForDate(this.minDobFilter),
        this.presentAddressFilter,
        this.permanentAddressFilter,
        this.genderFilter,
        this.contactNoFilter,
        this.altContactNoFilter,
        this.maritalStatusFilter,
        this.maxNoOfDependentsFilter == null ? this.maxNoOfDependentsFilterEmpty : this.maxNoOfDependentsFilter,
        this.minNoOfDependentsFilter == null ? this.minNoOfDependentsFilterEmpty : this.minNoOfDependentsFilter,
        this.maxConfirmationDateFilter === undefined
          ? this.maxConfirmationDateFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxConfirmationDateFilter),
        this.minConfirmationDateFilter === undefined
          ? this.minConfirmationDateFilter
          : this._dateTimeService.getStartOfDayForDate(this.minConfirmationDateFilter),
        this.maxDOJFilter === undefined
          ? this.maxDOJFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxDOJFilter),
        this.minDOJFilter === undefined
          ? this.minDOJFilter
          : this._dateTimeService.getStartOfDayForDate(this.minDOJFilter),
        this.ihExpFilter,
        this.maxTotalExpFilter == null ? this.maxTotalExpFilterEmpty : this.maxTotalExpFilter,
        this.minTotalExpFilter == null ? this.minTotalExpFilterEmpty : this.minTotalExpFilter,
        this.pfNoFilter,
        this.esiNoFilter,
        this.acNoFilter,
        this.ppNoFilter,
        this.panFilter,
        this.bgFilter,
        this.maxCLFilter == null ? this.maxCLFilterEmpty : this.maxCLFilter,
        this.minCLFilter == null ? this.minCLFilterEmpty : this.minCLFilter,
        this.maxELFilter == null ? this.maxELFilterEmpty : this.maxELFilter,
        this.minELFilter == null ? this.minELFilterEmpty : this.minELFilter,
        this.maxSLFilter == null ? this.maxSLFilterEmpty : this.maxSLFilter,
        this.minSLFilter == null ? this.minSLFilterEmpty : this.minSLFilter,
        this.maxBasicSalaryFilter == null ? this.maxBasicSalaryFilterEmpty : this.maxBasicSalaryFilter,
        this.minBasicSalaryFilter == null ? this.minBasicSalaryFilterEmpty : this.minBasicSalaryFilter,
        this.maxDAFilter == null ? this.maxDAFilterEmpty : this.maxDAFilter,
        this.minDAFilter == null ? this.minDAFilterEmpty : this.minDAFilter,
        this.maxHRAFilter == null ? this.maxHRAFilterEmpty : this.maxHRAFilter,
        this.minHRAFilter == null ? this.minHRAFilterEmpty : this.minHRAFilter,
        this.maxConveyanceFilter == null ? this.maxConveyanceFilterEmpty : this.maxConveyanceFilter,
        this.minConveyanceFilter == null ? this.minConveyanceFilterEmpty : this.minConveyanceFilter,
        this.maxIncentiveFilter == null ? this.maxIncentiveFilterEmpty : this.maxIncentiveFilter,
        this.minIncentiveFilter == null ? this.minIncentiveFilterEmpty : this.minIncentiveFilter,
        this.maxMedicalAllowanceFilter == null ? this.maxMedicalAllowanceFilterEmpty : this.maxMedicalAllowanceFilter,
        this.minMedicalAllowanceFilter == null ? this.minMedicalAllowanceFilterEmpty : this.minMedicalAllowanceFilter,
        this.maxOtherAllowancesFilter == null ? this.maxOtherAllowancesFilterEmpty : this.maxOtherAllowancesFilter,
        this.minOtherAllowancesFilter == null ? this.minOtherAllowancesFilterEmpty : this.minOtherAllowancesFilter,
        this.maxTotalSalaryFilter == null ? this.maxTotalSalaryFilterEmpty : this.maxTotalSalaryFilter,
        this.minTotalSalaryFilter == null ? this.minTotalSalaryFilterEmpty : this.minTotalSalaryFilter,
        this.photoFilter,
        this.maxUanNoFilter == null ? this.maxUanNoFilterEmpty : this.maxUanNoFilter,
        this.minUanNoFilter == null ? this.minUanNoFilterEmpty : this.minUanNoFilter,
        this.isActiveFilter,
        this.employeementUnderFilter,
        this.divisionFilter,
        this.maxContractorIdFilter == null ? this.maxContractorIdFilterEmpty : this.maxContractorIdFilter,
        this.minContractorIdFilter == null ? this.minContractorIdFilterEmpty : this.minContractorIdFilter,
        this.messBillFilter,
        this.onrollFilter,
        this.nameInTeluguFilter,
        this.maxRjDateFilter === undefined
          ? this.maxRjDateFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxRjDateFilter),
        this.minRjDateFilter === undefined
          ? this.minRjDateFilter
          : this._dateTimeService.getStartOfDayForDate(this.minRjDateFilter),
        this.documentFilter,
        this.extensionFilter,
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getSkipCount(this.paginator, event),
        this.primengTableHelper.getMaxResultCount(this.paginator, event)
      )
      .subscribe((result) => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
      });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  createEmployeeInformationMaster(): void {
    this.createOrEditEmployeeInformationMasterModal.show();
  }

  deleteEmployeeInformationMaster(employeeInformationMaster: EmployeeInformationMasterDto): void {
    this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
      if (isConfirmed) {
        this._employeeInformationMastersServiceProxy.delete(employeeInformationMaster.id).subscribe(() => {
          this.reloadPage();
          this.notify.success(this.l('SuccessfullyDeleted'));
        });
      }
    });
  }

  exportToExcel(): void {
    this._employeeInformationMastersServiceProxy
      .getEmployeeInformationMastersToExcel(
        this.filterText,
        this.empIdFilter,
        this.maxBioIdFilter == null ? this.maxBioIdFilterEmpty : this.maxBioIdFilter,
        this.minBioIdFilter == null ? this.minBioIdFilterEmpty : this.minBioIdFilter,
        this.internalIdFilter,
        this.maxDocFilter === undefined
          ? this.maxDocFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxDocFilter),
        this.minDocFilter === undefined
          ? this.minDocFilter
          : this._dateTimeService.getStartOfDayForDate(this.minDocFilter),
        this.nameFilter,
        this.forHFilter,
        this.maxDobFilter === undefined
          ? this.maxDobFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxDobFilter),
        this.minDobFilter === undefined
          ? this.minDobFilter
          : this._dateTimeService.getStartOfDayForDate(this.minDobFilter),
        this.presentAddressFilter,
        this.permanentAddressFilter,
        this.genderFilter,
        this.contactNoFilter,
        this.altContactNoFilter,
        this.maritalStatusFilter,
        this.maxNoOfDependentsFilter == null ? this.maxNoOfDependentsFilterEmpty : this.maxNoOfDependentsFilter,
        this.minNoOfDependentsFilter == null ? this.minNoOfDependentsFilterEmpty : this.minNoOfDependentsFilter,
        this.maxConfirmationDateFilter === undefined
          ? this.maxConfirmationDateFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxConfirmationDateFilter),
        this.minConfirmationDateFilter === undefined
          ? this.minConfirmationDateFilter
          : this._dateTimeService.getStartOfDayForDate(this.minConfirmationDateFilter),
        this.maxDOJFilter === undefined
          ? this.maxDOJFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxDOJFilter),
        this.minDOJFilter === undefined
          ? this.minDOJFilter
          : this._dateTimeService.getStartOfDayForDate(this.minDOJFilter),
        this.ihExpFilter,
        this.maxTotalExpFilter == null ? this.maxTotalExpFilterEmpty : this.maxTotalExpFilter,
        this.minTotalExpFilter == null ? this.minTotalExpFilterEmpty : this.minTotalExpFilter,
        this.pfNoFilter,
        this.esiNoFilter,
        this.acNoFilter,
        this.ppNoFilter,
        this.panFilter,
        this.bgFilter,
        this.maxCLFilter == null ? this.maxCLFilterEmpty : this.maxCLFilter,
        this.minCLFilter == null ? this.minCLFilterEmpty : this.minCLFilter,
        this.maxELFilter == null ? this.maxELFilterEmpty : this.maxELFilter,
        this.minELFilter == null ? this.minELFilterEmpty : this.minELFilter,
        this.maxSLFilter == null ? this.maxSLFilterEmpty : this.maxSLFilter,
        this.minSLFilter == null ? this.minSLFilterEmpty : this.minSLFilter,
        this.maxBasicSalaryFilter == null ? this.maxBasicSalaryFilterEmpty : this.maxBasicSalaryFilter,
        this.minBasicSalaryFilter == null ? this.minBasicSalaryFilterEmpty : this.minBasicSalaryFilter,
        this.maxDAFilter == null ? this.maxDAFilterEmpty : this.maxDAFilter,
        this.minDAFilter == null ? this.minDAFilterEmpty : this.minDAFilter,
        this.maxHRAFilter == null ? this.maxHRAFilterEmpty : this.maxHRAFilter,
        this.minHRAFilter == null ? this.minHRAFilterEmpty : this.minHRAFilter,
        this.maxConveyanceFilter == null ? this.maxConveyanceFilterEmpty : this.maxConveyanceFilter,
        this.minConveyanceFilter == null ? this.minConveyanceFilterEmpty : this.minConveyanceFilter,
        this.maxIncentiveFilter == null ? this.maxIncentiveFilterEmpty : this.maxIncentiveFilter,
        this.minIncentiveFilter == null ? this.minIncentiveFilterEmpty : this.minIncentiveFilter,
        this.maxMedicalAllowanceFilter == null ? this.maxMedicalAllowanceFilterEmpty : this.maxMedicalAllowanceFilter,
        this.minMedicalAllowanceFilter == null ? this.minMedicalAllowanceFilterEmpty : this.minMedicalAllowanceFilter,
        this.maxOtherAllowancesFilter == null ? this.maxOtherAllowancesFilterEmpty : this.maxOtherAllowancesFilter,
        this.minOtherAllowancesFilter == null ? this.minOtherAllowancesFilterEmpty : this.minOtherAllowancesFilter,
        this.maxTotalSalaryFilter == null ? this.maxTotalSalaryFilterEmpty : this.maxTotalSalaryFilter,
        this.minTotalSalaryFilter == null ? this.minTotalSalaryFilterEmpty : this.minTotalSalaryFilter,
        this.photoFilter,
        this.maxUanNoFilter == null ? this.maxUanNoFilterEmpty : this.maxUanNoFilter,
        this.minUanNoFilter == null ? this.minUanNoFilterEmpty : this.minUanNoFilter,
        this.isActiveFilter,
        this.employeementUnderFilter,
        this.divisionFilter,
        this.maxContractorIdFilter == null ? this.maxContractorIdFilterEmpty : this.maxContractorIdFilter,
        this.minContractorIdFilter == null ? this.minContractorIdFilterEmpty : this.minContractorIdFilter,
        this.messBillFilter,
        this.onrollFilter,
        this.nameInTeluguFilter,
        this.maxRjDateFilter === undefined
          ? this.maxRjDateFilter
          : this._dateTimeService.getEndOfDayForDate(this.maxRjDateFilter),
        this.minRjDateFilter === undefined
          ? this.minRjDateFilter
          : this._dateTimeService.getStartOfDayForDate(this.minRjDateFilter),
        this.documentFilter,
        this.extensionFilter
      )
      .subscribe((result) => {
        this._fileDownloadService.downloadTempFile(result);
      });
  }
}
