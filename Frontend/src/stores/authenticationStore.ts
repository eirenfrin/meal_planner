import { defineStore } from "pinia";
import { reactive } from "vue";

const useAuthStore = defineStore("authenticationStore", () => {
  const authState = reactive({
    accessToken: null as string | null,
  });

  function setAccessToken(token: string): void {
    authState.accessToken = token;
  }

  function logout(): void {}

  return { authState, setAccessToken, logout };
});

export default useAuthStore;
