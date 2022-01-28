import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { WeatherService } from './weather.service';
import { WeatherForecast } from './weather-forecast';
import { Country } from './country';
import { City } from './city';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html'
})
export class WeatherComponent implements OnInit {
    public forecasts: WeatherForecast[];

    countries: Country[];
    cities: City[];
    forecast: WeatherForecast;

    selectedCountryCode: string;
    selectedCityName: string;
    loading: boolean = false;
    selectedCountry: Country;
    selectedCity: City;

    weatherForm: FormGroup ;

    constructor(
        private weatherService: WeatherService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.weatherForm = this.formBuilder.group({
            country: ['', Validators.required],
            city: ['', Validators.required]
        });
        
        this.loading = true;
        this.weatherService.getCountries().subscribe(data => {
            this.loading = false;
            this.countries = data;
        });
    }

    handleCountryChange(e: any): void {
        this.selectedCountry = this.countries.filter(x => x.alpha2Code == this.selectedCountryCode)[0];

        this.loading = true;
        this.weatherService.getCities(this.selectedCountryCode).subscribe(data => {
            this.loading = false;
            this.cities = data;
        });
    }

    handleCityChange(e: any): void {
        this.selectedCity = this.cities.filter(x => x.name == this.selectedCityName && x.country == this.selectedCountryCode)[0];
    }

    get f() {
        return this.weatherForm.controls;
    }

    handleGetWeather(): void {
        this.loading = true;
        this.weatherService.getWeather(this.selectedCountryCode, this.selectedCityName).subscribe(data => {
            this.loading = false;
            this.forecast = data;
        });
    }

    initialize(): void {
        this.loading = false;

        this.selectedCountryCode = null;
        this.selectedCityName = null;
        this.selectedCountry = null;
        this.selectedCity = null;
        this.forecast = null;
    }

    handleWeatherReset() {
        this.weatherForm.reset();
        this.initialize();
        
        this.f['country'].setErrors(null);
        this.f['city'].setErrors(null);
    }
}