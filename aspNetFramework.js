import http from "k6/http";

export const options = {
	vus: 5,
	duration: '20s',
};

function generateRandomIntegerInRange(min, max) {
	return Math.floor(Math.random() * (max - min + 1)) + min;
}

export default function () {
	const url = "http://localhost:5026"
	const params = {
		timeout: "3s",
	};
	http.get(url, params);
}
