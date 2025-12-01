<template>
  <AccountForm :actionCallback="loginCallback">
    <template #login-register-h1>
      <h1>Login into application</h1>
    </template>
    <template #redirect-login-register>
      <p>
        Dont't have an account? Create one
        <RouterLink :to="{ name: 'Registration' }">here</RouterLink>!
      </p>
    </template>
  </AccountForm>
</template>

<script setup lang="ts">
import AccountForm from "../components/generic/AccountForm.vue";
import type { AuthRequest } from "../domain/models/authRequest";
import useAuthStore from "../stores/authenticationStore";

const authStore = useAuthStore();

async function loginCallback(authRequest: AuthRequest): Promise<void> {
  await authStore.login(authRequest);
}
</script>
