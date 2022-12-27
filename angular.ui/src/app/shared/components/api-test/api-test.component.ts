import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import TestData from '../../models/test-data.model';

@Component({
  selector: 'app-api-test',
  templateUrl: './api-test.component.html',
  styleUrls: ['./api-test.component.scss'],
})
export class ApiTestComponent implements OnInit {
  public data?: number;

  constructor(private client: HttpClient) {}
  
  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    this.client.get<TestData>('api/test').subscribe((r) => {
      this.data = r.value;
    });
  }
}
