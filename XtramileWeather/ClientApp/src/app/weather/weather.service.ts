import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Country } from './country';
import { City } from './city';
import { WeatherForecast } from './weather-forecast';

@Injectable({
    providedIn: 'root'
})
export class WeatherService {
    private apiUrl: string = '';

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.apiUrl = baseUrl;
    }

    getCountries(): Observable<Country[]> {
        return this.http.get<Country[]>(`${this.apiUrl}country`);
    }

    getCities(country: string): Observable<City[]> {
        return this.http.get<City[]>(`${this.apiUrl}city?country=${country}`);
    }

    getWeather(country: string, city: string): Observable<WeatherForecast> {
        return this.http.get<WeatherForecast>(`${this.apiUrl}weatherforecast?country=${country}&city=${city}`);
    }
}
