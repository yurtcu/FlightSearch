import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { FlatpickrModule } from 'angularx-flatpickr';
import { HttpClientModule } from '@angular/common/http';

import { RouterOutlet } from '@angular/router';

import { FlightSearchComponent } from './flight-search/flight-search.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightSearchComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterOutlet,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgSelectModule,
    CommonModule,
    FlatpickrModule.forRoot()
  ],
  exports: [RouterOutlet],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
