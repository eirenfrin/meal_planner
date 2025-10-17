<template>
  <OverviewList
    :editing-mode="editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="My cookbook"
    @change-edit-mode="editModeCallback"
  >
    <template #content>
      <ul class="list-recipes">
        <li
          class="list-recipes-entry"
          v-for="recipe in recipes"
          :key="recipe.id"
        >
          <RecipeOverviewListEntry
            :editing-mode="editingMode"
            :recipe="recipe"
            @toggle-recipe="toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { ref } from "vue";
import type { GetRecipeBasicInfoDto } from "../../domain/models/getRecipeBasicInfoDto";
import RecipeOverviewListEntry from "./RecipeOverviewListEntry.vue";
import OverviewList from "../generic/OverviewList.vue";

let editingMode = ref(false);
let listOfIdsToDelete = ref<Array<string>>([]);
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

async function deleteCallback(): Promise<void> {
  console.log("delete");
}

async function addCallback(): Promise<void> {
  console.log("add");
}
</script>

<style scoped>
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
