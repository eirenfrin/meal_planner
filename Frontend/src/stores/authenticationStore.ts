import { defineStore } from "pinia";
import { computed, reactive } from "vue";
import type { AuthStoreState } from "../domain/store-states/authStoreState";
import { AuthStatus } from "../domain/enums/authStatus";
import { decodeUserFromJWT, type User } from "../domain/models/user";
import type { AppError } from "../domain/models/appError";
import userService from "../api/services/userService";
import type { AuthRequest } from "../domain/models/authRequest";
import { useRouter } from "vue-router";
import useUnitStore from "./unitStore";
import useIngredientStore from "./ingredientStore";

const useAuthStore = defineStore("authenticationStore", () => {
  const state: AuthStoreState = reactive({
    currentUser: null,
    accessToken: null,
    status: AuthStatus.INIT,
    errors: [],
  });

  const router = useRouter();

  const unitStore = useUnitStore();
  const ingredientStore = useIngredientStore();

  const isAuthPending = computed(() => state.status == AuthStatus.PENDING);
  const isAuthSuccess = computed(
    () =>
      state.status == AuthStatus.SUCCESS &&
      state.currentUser != null &&
      state.accessToken != null
  );

  function authPending(): void {
    state.status = AuthStatus.PENDING;
    state.errors = [];
  }

  function authSuccess(accessToken: string, currentUser: User): void {
    state.status = AuthStatus.SUCCESS;
    state.errors = [];

    state.accessToken = accessToken;
    state.currentUser = currentUser;
  }

  function authInit(): void {
    state.status = AuthStatus.INIT;
    state.errors = [];

    state.accessToken = null;
    state.currentUser = null;
  }

  function authFailure(errors: AppError[]): void {
    state.status = AuthStatus.FAILURE;
    state.errors = errors;
  }

  async function register(authRequest: AuthRequest): Promise<void> {
    try {
      authPending();

      await userService.registerUser(authRequest);

      authInit();
      router.push({ name: "Login" });
    } catch (e: any) {
      authFailure(e as AppError[]);
    }
  }

  async function login(authRequest: AuthRequest): Promise<void> {
    try {
      authPending();

      let accessToken = await userService.loginUser(authRequest);
      let user = decodeUserFromJWT(accessToken);

      authSuccess(accessToken.token, user);

      await unitStore.getAllUnits();
      await ingredientStore.getAllIngredients();
      router.push({ name: "Recipes" });
    } catch (e: any) {
      authFailure(e as AppError[]);
    }
  }

  async function logout(): Promise<void> {
    try {
      authPending();

      await userService.logoutUser();

      authInit();
    } catch (e: any) {
      authFailure(e as AppError[]);
    }
  }

  return { state, isAuthPending, isAuthSuccess, register, login, logout };
});

export default useAuthStore;
