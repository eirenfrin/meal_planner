import axios from "axios";

const api = axios.create({
  baseURL: "https://api.example.com",
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
});

// interceptors - will be used later

// api.interceptors.request.use(
//   (config) => {
//     const token = localStorage.getItem("token");
//     if (token) {
//       config.headers.Authorization = `Bearer ${token}`;
//     }
//     return config;
//   },
//   (error) => Promise.reject(error)
// );

// api.interceptors.response.use(
//   (response) => response,
//   (error) => {
//     if (error.response?.status === 401) {
//       // Example: redirect to login
//       console.warn("Unauthorized, redirecting...");
//     }
//     return Promise.reject(error);
//   }
// );

export default api;
