import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { QueryResult } from './interfaces/queryResult';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public queryResults: QueryResult[];
  public winners: QueryResult[];
  public searchTerms: string;
  public searching: boolean;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {

  }

  performSearch() {
    let params = this.buildHttpParameters();
    this.searching = true;
    this.http.get<QueryResult[]>(this.baseUrl + 'api/SampleData/GetWinners', { params }).subscribe(result => {
      this.winners = result;
      this.searching = false;
    }, error => console.error(error));

    this.http.get<QueryResult[]>(this.baseUrl + 'api/SampleData/GetAllResults', { params }).subscribe(result => {
      this.queryResults = result;
      this.searching = false;
    }, error => console.error(error));
  }

  buildHttpParameters() {
    let params = new HttpParams();
    this.processTerms().forEach((searchTerm: string) => {
      params = params.append(`searchTerms`, searchTerm);
    });

    return params;
  }

  processTerms() {
    return this.searchTerms.split(",");
  }

}


