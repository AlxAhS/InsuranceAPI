import { Injectable } from '@angular/core';
import { InsuranceDetail } from './insurance-detail.model';
import {HttpClient} from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class InsuranceDetailService {

  constructor(private http:HttpClient) { }
  
  readonly baseURL = 'https://localhost:7223/api/InsuranceDetail'
  formData:InsuranceDetail = new InsuranceDetail();
  list:InsuranceDetail[];

  postInsuranceDetail(){
    return this.http.post(this.baseURL, this.formData);
  }

  putInsuranceDetail(){
    return this.http.put(`${this.baseURL}/${this.formData.userId}`, this.formData);
  }

  deleteInsuranceDetail(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as InsuranceDetail[])
  }





}
