<template>
  <ul>
    <li
      v-for="subpage in subPageValues"
      :key="subpage.label"
      :class="{
        active: subpage.label == appStore.state.currentSubpage?.label,
        inactive: subpage.label != appStore.state.currentSubpage?.label,
      }"
    >
      <RouterLink class="nav-link" :to="`${subpage.path}`">
        {{ subpage.label }}
      </RouterLink>
    </li>
  </ul>
</template>

<script setup lang="ts">
import { subPageValues } from "../../domain/enums/currentSubPage";
import useAppStore from "../../stores/applicationStore";

const appStore = useAppStore();
</script>

<style scoped></style>
