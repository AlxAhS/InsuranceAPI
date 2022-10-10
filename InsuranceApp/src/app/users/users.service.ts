import { Component, OnInit } from '@angular/core';
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: "root"
})
export class UsersService {
  constructor(private http: HttpClient) {}

}