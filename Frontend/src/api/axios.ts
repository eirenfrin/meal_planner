import axios, {
  AxiosError,
  type AxiosInstance,
  type AxiosResponse,
  type InternalAxiosRequestConfig,
} from "axios";
import useAuthStore from "../stores/authenticationStore";

const api: AxiosInstance = axios.create({
  baseURL: "http://localhost:5133",
  timeout: 10000,
  withCredentials: true,
});

// Interceptor to always attach the access token to outgoing requests
// api.interceptors.request.use((config) => {
//   const authStore = useAuthStore();

//   if (authStore.authState.accessToken) {
//     config.headers.Authorization = `Bearer ${authStore.authState.accessToken}`;
//   }
//   return config;
// });

// Interceptor to handle access token refresh
// api.interceptors.response.use(
//   (response: AxiosResponse) => response,
//   async (error: AxiosError) => {
//     const authStore = useAuthStore();
//     const originalRequest = error.config as InternalAxiosRequestConfig & {
//       _retry?: boolean;
//     };

//     if (
//       originalRequest &&
//       error.response?.status === 401 &&
//       !originalRequest._retry &&
//       !originalRequest.url?.includes("/auth/")
//     ) {
//       originalRequest._retry = true;

//       try {
//         const response = await api.post<{ accessToken: string }>(
//           "auth/refresh"
//         );

//         authStore.setAccessToken(response.data.accessToken);

//         originalRequest.headers.Authorization = `Bearer ${authStore.authState.accessToken}`;
//         return api(originalRequest);
//       } catch (e) {
//         authStore.logout();
//         return Promise.reject(e);
//       }
//     }
//     return Promise.reject(error);
//   }
// );

export default api;
