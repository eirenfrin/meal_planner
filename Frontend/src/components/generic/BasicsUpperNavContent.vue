<template>
  <ul>
    <li v-for="subpage in subPageValues" :key="subpage.label">
      <RouterLink
        class="nav-link"
        :to="`${subpage.path}`"
        :class="{
          active: subpage.label == appStore.state.currentSubpage?.label,
        }"
      >
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

<style scoped>
ul {
  width: 60%;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-around;
  margin: 0 auto;
  padding: 0;
}
li {
  list-style: none;
  text-align: center;
  font-size: large;
  transition: transform 0.2s ease;
  font-weight: 500;
  cursor: pointer;
}
li:hover {
  transform: scale(1.5);
}
.nav-link {
  color: black;
  text-decoration: none;
}
.nav-link:hover {
  color: black;
}
.active {
  font-weight: 900;
}
</style>
