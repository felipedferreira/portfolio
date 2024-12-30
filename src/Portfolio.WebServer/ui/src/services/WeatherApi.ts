import { useBaseUrl } from './ApiUtils';

interface IWeatherForecast {
    date: string
    summary: string
    temperatureC: number
    temperatureF: number
}

export class WeatherApi
{
    /**
     * Loads data asynchronously from the server.
     * @returns A Promise that resolves to the fetched data.
     * @throws An error if the data fetching fails.
     */
    public async getWeatherforecastAsync(): Promise<Array<IWeatherForecast>> {
        const baseUrl = useBaseUrl();
        return fetch(baseUrl + "/api/weatherforecast")
        .then(response => {
            if (response.ok) {
                return response.json() as Promise<Array<IWeatherForecast>>;
            } else {
                throw new Error("Failed to fetch data");
            }
        })
        .catch(error => {
            console.log(error);
            throw error;
        });
    }
}