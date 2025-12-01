<template>
  <AccountForm :action-callback="registerCallback">
    <template #login-register-h1>
      <h1>Create an account</h1>
    </template>
    <template #redirect-login-register>
      <p>
        Already have an account? Log in
        <RouterLink :to="{ name: 'Login' }">here</RouterLink>!
      </p>
    </template>
  </AccountForm>
</template>

<script setup lang="ts">
import AccountForm from "../components/generic/AccountForm.vue";
import type { AuthRequest } from "../domain/models/authRequest";
import useAuthStore from "../stores/authenticationStore";

const authStore = useAuthStore();

async function registerCallback(authRequest: AuthRequest): Promise<void> {
  await authStore.register(authRequest);
}
</script>
