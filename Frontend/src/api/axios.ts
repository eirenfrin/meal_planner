import axios, {
  AxiosError,
  type AxiosInstance,
  type AxiosResponse,
  type InternalAxiosRequestConfig,
} from "axios";
import useAuthStore from "../stores/authenticationStore";
import userService from "./services/userService";

const api: AxiosInstance = axios.create({
  baseURL: "https://localhost:7191",
  timeout: 10000,
  withCredentials: true,
});

// Interceptor to always attach the access token to outgoing requests
api.interceptors.request.use((config) => {
  const authStore = useAuthStore();

  if (authStore.state.accessToken) {
    config.headers.Authorization = `Bearer ${authStore.state.accessToken}`;
  }
  return config;
});

// Interceptor to handle access token refresh
api.interceptors.response.use(
  (response: AxiosResponse) => response,
  async (error: AxiosError) => {
    const authStore = useAuthStore();
    const originalRequest = error.config as InternalAxiosRequestConfig & {
      _retry?: boolean;
    };

    if (
      originalRequest &&
      error.response?.status === 401 &&
      !originalRequest._retry &&
      !originalRequest.url?.includes("/auth/")
    ) {
      originalRequest._retry = true;

      try {
        const accessToken = await userService.refreshTokens();

        authStore.state.accessToken = accessToken.token;

        originalRequest.headers.Authorization = `Bearer ${authStore.state.accessToken}`;
        return await api(originalRequest);
      } catch (e: any) {
        await authStore.logout();
        return Promise.reject(e as AxiosError);
      }
    }
    return Promise.reject(error);
  }
);

export default api;
