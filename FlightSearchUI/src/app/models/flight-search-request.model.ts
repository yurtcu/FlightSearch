export interface FlightSearchRequest {
  Origin: string | null;
  Destinition: string | null;
  DepartureDate: any | null;
  ReturnDate: any | null;
}
// DepartureDate ve ReturnDate alanlarının tipi aslında Date olmalıydı. Ancak tarih seçme component'inin uyumsuzlukları yüzünden any yapmak zorunda kaldım.
