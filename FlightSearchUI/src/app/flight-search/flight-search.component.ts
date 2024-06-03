import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import flatpickr from 'flatpickr';
import { Turkish } from 'flatpickr/dist/l10n/tr.js';

import { ApiService } from '@services/api.service'
import { FlightSearchResponse } from '@models/flight-search-response.model';
import { FlightSearchRequest } from '@models/flight-search-request.model';
import { FlightOption } from '@models/flight-option.model';

// Verilen interface'in property'lerine göre FormControl'leri oluşturmak için:
export type IForm<T> = {
  [K in keyof T]?: FormControl<T[K]>;
}

// FlightSearchRequest interface'ine göre FormGroup oluşturmak için:
export type IFlightSearchForm = IForm<FlightSearchRequest>;

@Component({
  selector: 'app-flight-search',
  templateUrl: './flight-search.component.html',
  styleUrls: ['./flight-search.component.css']
})

export class FlightSearchComponent implements OnInit {
  searchForm = new FormGroup<IFlightSearchForm>({
    Origin: new FormControl('', [Validators.required, this.differentAirportsValidator.bind(this)]),
    Destinition: new FormControl('', [Validators.required]),
    DepartureDate: new FormControl(new Date().toISOString().split('T')[0], [Validators.required]),
    ReturnDate: new FormControl(new Date(new Date().setDate(new Date().getDate() + 1)).toISOString().split('T')[0], [this.returnDateValidator.bind(this)])
  });

  showReturnFlights: boolean = false;
  formSubmitted: boolean = false; // false iken validasyon hata mesajları gösterilmez.
  loading: boolean = false;
  searchError: boolean = false;
  flatpickrDisplayFormat: string = navigator.language == "tr" ? "d F Y" : "F d, Y";

  private airports: string[] = []; // Api'den çekilen, tüm havalimanlarının listesi.
  filteredAirports: string[] = []; // Havalimanları listesinin, kullanıcı yazdıkça filtrelenmiş hali. Havalimanı comboları bunu kullanır.

  // Arama sonuçları:
  departureFlights: FlightOption[] = []; // Gidiş uçuşları listesi
  selectedDepartureFlightIndex: number | null = null; // Gidiş uçuşları listesinde kullanıcının tıklayıp detayını görmekte olduğu satırın numarası.
  returnFlights: FlightOption[] = []; // Dönüş uçuşları listesi
  selectedReturnFlightIndex: number | null = null; // Dönüş uçuşları listesinde kullanıcının tıklayıp detayını görmekte olduğu satırın numarası.

  constructor(private apiService: ApiService) {
  }

  ngOnInit(): void {
    this.initFlatpickr();
    this.initAirportList();

    // Varış havalimanı değiştirildiğinde, kalkış havalimanı ile farklı olup olmadığını kontrol eden (kalkış havalimanındaki) validasyonun çalışması için:
    this.searchForm.get('Destinition')?.valueChanges.subscribe(() => {
      this.searchForm.get('Origin')?.updateValueAndValidity();
    });

    // Gidiş tarihi değiştirildiğinde, dönüş tarihinin küçük olup olmadığını kontrol eden (dönüş tarihindeki) validasyonun çalışması için:
    this.searchForm.get('DepartureDate')?.valueChanges.subscribe(() => {
      this.searchForm.get('ReturnDate')?.updateValueAndValidity();
    });
  }

  initFlatpickr(): void {
    flatpickr.defaultConfig.dateFormat = "Y-m-d";
    if (navigator.language == "tr") {
      flatpickr.localize(Turkish);
    }
  }

  initAirportList() {
    // Tüm havalimanlarının listesini Api'den çek:
    this.apiService.getAirports().subscribe({
      next: (response) => {
        if (response.status === 200) {
          this.airports = response.body ?? [];
        }
      },
      error: (error) => {
        this.airports = [];
      }
    });
  }

  // Validasyonların sonucunda hata mesajlarının gösterilip gösterilmeyeceği:
  isInvalid(controlName: string) {
    let control = this.searchForm.controls[controlName];
    let ret = control?.invalid && (control?.dirty || control.touched || this.formSubmitted);
    return ret;
  }

  // Kalkış ve varış havalimanları aynı olmamalıdır. Bunun validasyonu:
  differentAirportsValidator(control: AbstractControl): ValidationErrors | null {
    const origin = control.value;
    const destinition = this.searchForm?.get('Destinition')?.value;

    if (origin && destinition && origin === destinition) {
      return { sameAirport: true };
    }
    return null;
  }

  returnDateValidator(control: AbstractControl): ValidationErrors | null {
    const returnDate = control.value == "" ? null : new Date(control.value);
    const departureDateStr: any = this.searchForm?.get('DepartureDate')?.value;
    const departureDate = departureDateStr == "" ? null : new Date(departureDateStr);


    if (returnDate && departureDate && returnDate < departureDate) {
      return { returnDateInvalid: true };
    }
    return null;
  }

  searchFlights() {
    this.formSubmitted = true;
    if (!this.searchForm.valid) {
      return;
    }

    // Dönüş tarihi boşsa, api tarih tipinde değer beklediği için, onu boş string yerine null yapmak gerekiyor.
    if (this.searchForm.value.ReturnDate == "") {
      this.searchForm.value.ReturnDate = null;
    }
    this.showReturnFlights = this.searchForm.value.ReturnDate != null;

    this.loading = true;
    this.apiService.searchFlights(this.searchForm.value as FlightSearchRequest).subscribe({
      next: (response) => {
        this.loading = false;
        if (response.status === 200) {
          this.departureFlights = response.body?.DepartureFlights ?? [];
          this.returnFlights = response.body?.ReturnFlights ?? [];
          this.searchError = false;
        }
        else {
          this.searchError = true;
        }
      },
      error: (error) => {
        this.loading = false;
        this.departureFlights = [];
        this.returnFlights = [];
        this.searchError = true;
      }
    });
  }

  // Gidiş uçuşlarından birini seçili yapma veya seçimi kaldırma:
  toggleDepartureDetails(index: number) {
    if (this.selectedDepartureFlightIndex === index) {
      this.selectedDepartureFlightIndex = null;
    } else {
      this.selectedDepartureFlightIndex = index;
    }
  }

  // Dönüş uçuşlarından birini seçili yapma veya seçimi kaldırma:
  toggleReturnDetails(index: number) {
    if (this.selectedReturnFlightIndex === index) {
      this.selectedReturnFlightIndex = null;
    } else {
      this.selectedReturnFlightIndex = index;
    }
  }

  // Havalimanı seçiminde kullanıcı yazdıkça filtreleme:
  filterAirports(event) {
    this.filteredAirports = this.airports.filter(option =>
      option.toLocaleLowerCase().includes(event.target.value.toLocaleLowerCase())
    );
  }

  // Havalimanları listesini ilk haline döndürme:
  resetAirports() {
    this.filteredAirports = this.airports;
  }

  // Sonuç listelerinde tarih alanlarını browser'ın dil/format ayarlarına uygun olarak göstermek için:
  getFormattedDate(dateStr: string): string {
    return new Intl.DateTimeFormat(navigator.language).format(new Date(dateStr));
  }

  // Sonuç listelerinde saat alanlarını browser'ın dil/format ayarlarına uygun olarak göstermek için:
  getFormattedTime(dateStr: string): string {
    return new Intl.DateTimeFormat(navigator.language, { timeStyle: 'short' }).format(new Date(dateStr));
  }
}
