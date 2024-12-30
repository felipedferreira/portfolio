import { WeatherApi } from './services/WeatherApi';
// css imports
import './css/icon-font.css';
import './css/reset.css';
import './css/style.css';

const weatherApi = new WeatherApi();

export function loadAsync()
{
    weatherApi.getWeatherforecastAsync()
        .then(data => {
            if(Array.isArray(data))
            {
                console.table(data);
            }
        })
        .catch(error => console.error(error));
}

// core code
loadAsync();