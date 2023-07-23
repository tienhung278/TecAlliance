import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Employee} from "../../../../models/employee";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private baseUrl: string = "http://localhost:5141/api";

  constructor(private client: HttpClient) { }

  public getEmployees(): Observable<Employee[]> {
    return this.client.get<Employee[]>(this.baseUrl + "/employees");
  }

  public getEmployee(id: string): Observable<Employee> {
    return this.client.get<Employee>(this.baseUrl + "/employees/" + id);
  }

  public createEmployee(body: any): Observable<Employee> {
    return this.client.post<Employee>(this.baseUrl + "/employees", body, { headers: { "Content-Type": "application/json" }});
  }

  public updateEmployee(id: string, body: any): Observable<any> {
    return this.client.put<any>(this.baseUrl + "/employees/" + id, body, { headers: { "Content-Type": "application/json" }});
  }

  public deleteEmployee(id: string): Observable<any> {
    return this.client.delete(this.baseUrl + "/employees/" + id);
  }
}
