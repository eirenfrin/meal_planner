<template>
  <h1>{{ msg }}</h1>

  <div class="card">
    <button type="button" @click="appStore.increment()">
      Message: {{ appStore.getFormattedCount }}
    </button>
    <button type="button" @click="register">register</button>
    <button type="button" @click="login">login</button>
    <p v-if="width > 1000">
      Edit
      <code>components/HelloWorld.vue</code> to test HMR
    </p>
    <p>width: {{ width }}, height: {{ height }}</p>
    <p>
      Battery: {{ level * 100 }}%, charging: {{ charging ? "true" : "false" }}
    </p>
    <p>Mouse x: {{ mouseEvents.x }}, mouse y: {{ mouseEvents.y }}</p>

    <p>Mouse source type: {{ mouseEvents.sourceType }}</p>
  </div>

  <p>
    Check out
    <a href="https://vuejs.org/guide/quick-start.html#local" target="_blank"
      >create-vue</a
    >, the official Vue + Vite starter
  </p>
  <p>
    Learn more about IDE Support for Vue in the
    <a
      href="https://vuejs.org/guide/scaling-up/tooling.html#ide-support"
      target="_blank"
      >Vue Docs Scaling up Guide</a
    >.
  </p>
  <p class="read-the-docs">Click on the Vite and Vue logos to learn more</p>
</template>

<script setup lang="ts">
import api from "../api/axios";
import userService from "../api/services/userService";
import type { AuthRequest } from "../domain/models/authRequest";
import useAppStore from "../stores/applicationStore";
import { useWindowSize, useBattery, useMouse } from "@vueuse/core";

defineProps<{ msg: string }>();

const appStore = useAppStore();
let { width, height } = useWindowSize();
let { charging, level } = useBattery();
let mouseEvents = useMouse();

let auth: AuthRequest = {
  username: "Name",
  password: "password123",
};

async function register() {
  await userService.registerUser(auth);
}

async function login() {
  let response = await api.post<{ accessToken: string }>(
    "api/user/auth/login",
    auth
  );

  console.log(JSON.stringify(response.data));
}
</script>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
