<template>
  <!-- <div>
    <a href="https://vite.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
  </div> -->
  <RecipesOverviewList />
  <LowNavBar :current-page="currentPage" />
  <!-- <HelloWorld :msg="x">
    <template #aaaa>
      <div>This is slot content</div>
    </template>
  </HelloWorld> -->
</template>

<script setup lang="ts">
import { reactive, ref } from "vue";
import LowNavBar from "./components/generic/LowNavBar.vue";
import RecipesOverviewList from "./components/recipes/RecipesOverviewList.vue";
import { CurrentPage } from "./domain/enums/currentPage";
let currentPage = ref<CurrentPage>(CurrentPage.BASICS);
</script>
<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
