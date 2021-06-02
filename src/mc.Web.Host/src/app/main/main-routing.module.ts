import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SubDepartmentsComponent } from './subDepartments/subDepartments/subDepartments.component';
import { DepartmentsComponent } from './departments/departments/departments.component';
import { EmployeeInformationMastersComponent } from './employeeInformationMasters/employeeInformationMasters/employeeInformationMasters.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'subDepartments/subDepartments', component: SubDepartmentsComponent, data: { permission: 'Pages.SubDepartments' }  },
                    { path: 'departments/departments', component: DepartmentsComponent, data: { permission: 'Pages.Departments' }  },
                    { path: 'employeeInformationMasters/employeeInformationMasters', component: EmployeeInformationMastersComponent, data: { permission: 'Pages.EmployeeInformationMasters' }  },
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Tenant.Dashboard' } },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
