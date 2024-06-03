import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightSearchComponent } from './flight-search/flight-search.component';

export const routes: Routes = [
  { path: '', redirectTo: '/flight-search', pathMatch: 'full' },
  { path: 'flight-search', component: FlightSearchComponent },
  { path: '**', component: FlightSearchComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

