import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import {AddUpdateComponent} from "./components/add-update/add-update.component";

const routes: Routes = [
  { path: "", component: EmployeeComponent },
  { path: "add", component: AddUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
