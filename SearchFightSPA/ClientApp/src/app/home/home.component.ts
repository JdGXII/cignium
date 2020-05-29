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
    this.queryResults = undefined;
    this.winners = undefined;

    let params = this.buildHttpParameters();
    this.searching = true;
    this.http.get<QueryResult[]>(this.baseUrl + 'api/SearchFightApi/GetWinners', { params }).subscribe(result => {
      this.winners = result;
      this.searching = false;
    }, error => alert("You've sent too many requests to the servers. Wait a while and try again"));

    this.http.get<QueryResult[]>(this.baseUrl + 'api/SearchFightApi/GetAllResults', { params }).subscribe(result => {
      this.queryResults = result;
      this.searching = false;
    }, error => alert("You've sent too many requests to the servers. Wait a while and try again"));
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


