<template>
  <section class="overview-list-container">
    <RecipesOverviewHeader
      :editing-mode="editingMode"
      @change-edit-mode="editModeCallback"
    />
    <ul class="list-recipes">
      <li class="list-recipes-entry" v-for="recipe in recipes" :key="recipe.id">
        <RecipeOverviewListEntry
          :editing-mode="editingMode"
          :recipe="recipe"
          @toggle-recipe="toggleCallback"
        />
      </li>
    </ul>
  </section>
</template>

<script setup lang="ts">
import { ref } from "vue";
import type { GetRecipeBasicInfoDto } from "../../domain/models/getRecipeBasicInfoDto";
import RecipeOverviewListEntry from "./RecipeOverviewListEntry.vue";
import RecipesOverviewHeader from "./RecipesOverviewHeader.vue";

let editingMode = ref(false);
let listOfIdsToDelete = ref([] as Array<string>);
let recipes: Array<GetRecipeBasicInfoDto> = [
  {
    id: "123456",
    title: "Cokinkovy kolacik",
    lastCooked: new Date(),
  },
  {
    id: "123455",
    title: "Rybacia polievocka",
    lastCooked: new Date(),
  },
  {
    id: "123454",
    title: "Buterbrodik",
    lastCooked: new Date(),
  },
];

function toggleCallback(id: string): void {
  if (listOfIdsToDelete.value.includes(id)) {
    listOfIdsToDelete.value.splice(listOfIdsToDelete.value.indexOf(id), 1);
  } else {
    listOfIdsToDelete.value.push(id);
  }

  console.log(JSON.stringify(listOfIdsToDelete.value));
}

function editModeCallback(mode: boolean): void {
  editingMode.value = mode;
}
</script>

<style scoped>
.overview-list-container {
  width: 80%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.list-recipes-entry {
  list-style: none;
  margin: 20px 0px;
  text-align: center;
}

.list-recipes {
  width: 100%;
  padding: 0px;
}
</style>
