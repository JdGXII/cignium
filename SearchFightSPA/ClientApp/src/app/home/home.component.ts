import { Component } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { QueryResult } from './interfaces/queryResult';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public queryResults: QueryResult[];
  public winners: QueryResult[];
  public searchTerms: string;
  public searching: boolean;
  public error: string;

  constructor(public searchService: SearchService) {}

  performSearch() {
    this.queryResults = undefined;
    this.winners = undefined;
    this.error = undefined;
    

    if (this.searchTerms) {
      this.searching = true;
      this.getAllResults();
    }
    else {
      this.error = "Please input search terms";
      this.searching = false;
    }

  }

  getAllResults() {
    this.searchService.getAllResults(this.processTerms()).subscribe(response => {
      if (response.results && response.winners) {
        this.queryResults = response.results;
        this.winners = response.winners;
      }
      else {
        this.error = response.message;
      }
      this.searching = false;
    },
      (error => {
        this.error = "You've sent too many requests to the servers. Wait a while and try again";
        this.searching = false;
      }));
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


