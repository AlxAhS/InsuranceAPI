import { Component, OnInit } from '@angular/core';
import { InsuranceDetailService } from 'src/app/shared/insurance-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { InsuranceDetail } from 'src/app/shared/insurance-detail.model';


@Component({
  selector: 'app-insurance-detail-form',
  templateUrl: './insurance-detail-form.component.html',
  styles: [
  ]
})
export class InsuranceDetailFormComponent implements OnInit {

  constructor(public service:InsuranceDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if (this.service.formData.userId==0)  this.insertRecord(form);
    else
    this.updateRecord(form);
  }
  
  insertRecord(form:NgForm){
    this.service.postInsuranceDetail().subscribe(
      res => {
        this.resetForm(form)
        this.service.refreshList();
        this.toastr.success('Submitted successfully', 'Insurance Detail Register')
      },
      err => {console.log(err);}
    );
  }

  updateRecord(form:NgForm){
    this.service.putInsuranceDetail().subscribe(
      res => {
        this.resetForm(form)
        this.service.refreshList();
        this.toastr.info('Update successfully', 'Insurance Detail Register')
      },
      err => {console.log(err);}
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new InsuranceDetail ();
  }

}
