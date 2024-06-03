import { FlightOption } from '@models/flight-option.model';

export interface FlightSearchResponse {
  DepartureFlights: FlightOption[];
  ReturnFlights: FlightOption[];
}
