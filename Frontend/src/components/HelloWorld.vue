<template>
  <h1>{{ msg }}</h1>

  <div class="card">
    <button type="button" @click="appStore.increment()">
      Message: {{ appStore.getFormattedCount }}
    </button>
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
import useAppStore from "../stores/applicationStore";
import { useWindowSize, useBattery, useMouse } from "@vueuse/core";

defineProps<{ msg: string }>();

const appStore = useAppStore();
let { width, height } = useWindowSize();
let { charging, level } = useBattery();
let mouseEvents = useMouse();
</script>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
