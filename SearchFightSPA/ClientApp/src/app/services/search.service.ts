import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ApiResponse } from '../home/interfaces/apiResponse';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  public baseUrl = "/";

  constructor(public http: HttpClient) {}

  getWinners(searchTerms: string[]) {
    let params = this.buildHttpParameters(searchTerms);
    return this.http.get<ApiResponse>(this.baseUrl + 'api/SearchFightApi/GetWinners', { params })
  }

  getAllResults(searchTerms: string[]) {
    let params = this.buildHttpParameters(searchTerms);
    return this.http.get<ApiResponse>(this.baseUrl + 'api/SearchFightApi/GetAllResults', { params })
  }

  buildHttpParameters(searchTerms: string[]) {
    let params = new HttpParams();

    searchTerms.forEach((searchTerm: string) => {
      params = params.append(`searchTerms`, searchTerm);
    });

    return params;
  }
}
