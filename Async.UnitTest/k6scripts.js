import http from "k6/http";

export const options = {
    vus: 5,
    duration: '20s',
};

export default function () {
    const url = "http://localhost:5026"
    // const url = "https://localhost:20232/api/WeatherForecast/Get"
    const params = {
        timeout: "3s",
    };
    http.get(url, params);
}
