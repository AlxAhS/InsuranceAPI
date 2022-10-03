import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { InsuranceDetail } from '../shared/insurance-detail.model';
import { InsuranceDetailService } from '../shared/insurance-detail.service';

@Component({
  selector: 'app-insurance-details',
  templateUrl: './insurance-details.component.html',
  styles: [
  ]
})
export class InsuranceDetailsComponent implements OnInit {

  constructor(public service: InsuranceDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:InsuranceDetail){
    this.service.formData = Object.assign({},selectedRecord) ;
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteInsuranceDetail(id).subscribe(
        res=>{
          this.service.refreshList();
          this.toastr.error("Deleted successfully", 'Insurance Detail Register')
        },
        err=>{console.log(err)}
      )
    }
  }
}
