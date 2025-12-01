<template>
  <nav>
    <ul>
      <li
        v-for="page in pageValues"
        :key="page.label"
        :class="{
          active: page.label == appStore.state.currentPage.label,
          inactive: page.label != appStore.state.currentPage.label,
        }"
      >
        <RouterLink class="nav-link" :to="`/app/${page.path}`">{{
          page.label
        }}</RouterLink>
      </li>
    </ul>
  </nav>
</template>

<script setup lang="ts">
import { pageValues } from "../../domain/enums/currentPage";
import useAppStore from "../../stores/applicationStore";

const appStore = useAppStore();
</script>

<style scoped>
nav {
  bottom: 0;
}

.active a {
  font-size: xx-large;
}
</style>
