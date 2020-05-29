import { QueryResult } from "./queryResult";

export interface ApiResponse {
  message: string;
  results: QueryResult[];
}
