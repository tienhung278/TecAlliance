import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {InternalServerComponent} from "./components/internal-server/internal-server.component";
import {NotFoundComponent} from "./components/not-found/not-found.component";
import {HomeComponent} from "./components/home/home.component";

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "employee", loadChildren: () => import('./modules/employee/employee.module').then(m => m.EmployeeModule) },
  { path: "404", component: NotFoundComponent },
  { path: "500", component: InternalServerComponent },
  { path: "", redirectTo: "/home", pathMatch: "full"},
  { path: "**", redirectTo: "/404", pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
