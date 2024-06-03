import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Router } from '@angular/router';

import { FlightSearchRequest } from '@models/flight-search-request.model';
import { FlightSearchResponse } from '@models/flight-search-response.model';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient, private router: Router) { }

  getAirports(): Observable<HttpResponse<string[]>> {
    return this.http.get<string[]>("/api/FlightSearch", { observe: 'response' });
  }

  searchFlights(formData: FlightSearchRequest): Observable<HttpResponse<FlightSearchResponse>> {
    return this.http.post<FlightSearchResponse>("/api/FlightSearch", formData, { observe: 'response' });
  }
}
