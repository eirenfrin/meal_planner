<template>
  <nav>
    <ul>
      <li
        v-for="entry in pageValues"
        :key="entry"
        :class="{ active: entry == currentPage }"
      >
        {{ entry }}
      </li>
    </ul>
  </nav>
</template>

<script setup lang="ts">
import { pageValues, type CurrentPage } from "../../domain/enums/currentPage";

const props = defineProps<{
  currentPage: CurrentPage;
}>();
</script>

<style scoped>
nav {
  width: 100%;
  background-color: #fdf6e3;
  position: fixed;
  bottom: 0;
  padding: 20px;
}
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
.active {
  font-weight: 900;
  font-size: xx-large;
}
</style>
