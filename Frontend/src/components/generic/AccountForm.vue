<template>
  <section class="form-container">
    <slot name="login-register-h1"></slot>
    <form>
      <label for="username">Username</label>
      <input
        type="text"
        id="username"
        placeholder="your account name"
        v-model="authRequest.username"
        required
      />
      <label class="password-label" for="password">Password</label>
      <input
        type="password"
        id="password"
        placeholder="your password"
        v-model="authRequest.password"
        required
      />
    </form>
    <slot name="redirect-login-register"></slot>
    <button @click.prevent="handleAuth" :disabled="authStore.isAuthPending">
      Proceed
    </button>
  </section>
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
  background-color: #fdf6e3;
  padding: 1rem 5rem;
  box-shadow: 0 4px 12px 0 rgba(0, 0, 0, 0.1);
}

form {
  display: flex;
  flex-direction: column;
  justify-content: center;
  padding-top: 3rem;
}
label {
  padding-bottom: 0.5rem;
  font-size: large;
  font-weight: bold;
}
.password-label {
  padding-top: 1rem;
}
input {
  border: 2px solid blueviolet;
  height: 2rem;
  padding: 5px;
  font-size: large;
}
input:focus {
  border: 2px solid blueviolet;
  border-radius: 0%;
}
</style>
