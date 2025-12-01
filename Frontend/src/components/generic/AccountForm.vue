<template>
  <form>
    <slot name="login-register-h1"></slot>
    <label for="username">Username</label>
    <input
      type="text"
      id="username"
      placeholder="your account name"
      v-model="authRequest.username"
      required
    />
    <label for="password">Password</label>
    <input
      type="password"
      id="password"
      placeholder="your password"
      v-model="authRequest.password"
      required
    />
    <slot name="redirect-login-register"></slot>
    <button @click.prevent="handleAuth" :disabled="authStore.isAuthPending">
      Proceed
    </button>
  </form>
</template>

<script setup lang="ts">
import { onUnmounted, reactive } from "vue";
import type { AuthRequest } from "../../domain/models/authRequest";
import useAuthStore from "../../stores/authenticationStore";

const props = defineProps<{
  actionCallback: (authRequest: AuthRequest) => Promise<void>;
}>();

const authStore = useAuthStore();

let authRequest = reactive<AuthRequest>({
  username: "",
  password: "",
});

async function handleAuth(): Promise<void> {
  await props.actionCallback(authRequest);
  resetAuthRequest();
}

function resetAuthRequest(): void {
  authRequest.username = "";
  authRequest.password = "";
}

onUnmounted(() => resetAuthRequest());
</script>

<style scoped>
.form-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  background-color: beige;
  width: 50vw;
  padding: 5rem;
  box-shadow: 0 4px 12px 0 rgba(0, 0, 0, 0.1);
}

form {
  display: flex;
  flex-direction: column;
  justify-content: center;
  width: 40vw;
  padding: 3rem;
  background-color: beige;
  box-shadow: 0 4px 12px 0 rgba(0, 0, 0, 0.1);
}

label {
  padding: 1rem 0 0.5rem;
  font-size: large;
  font-weight: bold;
}
</style>
