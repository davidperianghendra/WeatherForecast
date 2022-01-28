export interface WeatherLocationResponse {
    Latitude: number;
    Longitude: number;
}

export interface WeatherResultWind {
    Speed: number;
    Deg: number;
}

export interface WeatherResultWeather {
    Id: number;
    Main: string;
    Description: string;
    Icon: string;
}

export interface WeatherForecast {
    Location: WeatherLocationResponse;
    Time: string;
    Wind: WeatherResultWind;
    Visibility: number;
    Sky: WeatherResultWeather[];
    TemperatureC: number;
    TemperatureF: number;
    DewPoint: string;
    Humidity: number;
    Pressure: number;
}
