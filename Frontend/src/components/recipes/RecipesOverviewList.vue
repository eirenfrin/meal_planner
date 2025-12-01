<template>
  <OverviewList
    :editing-mode="listFunctions.editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="My cookbook"
    @change-edit-mode="listFunctions.editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li
          class="list-entry"
          v-for="recipe in recipes"
          :key="recipe.id"
          @click.prevent="
            !listFunctions.editingMode &&
              appStore.toggleChooseRecipePreviewModal()
          "
        >
          <RecipeOverviewListEntry
            :editing-mode="listFunctions.editingMode"
            :recipe="recipe"
            @toggle-recipe="listFunctions.toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { reactive } from "vue";
import type { GetRecipeBasicInfoDto } from "../../domain/models/getRecipeBasicInfoDto";
import RecipeOverviewListEntry from "./RecipeOverviewListEntry.vue";
import OverviewList from "../generic/OverviewList.vue";
import useAppStore from "../../stores/applicationStore";
import { useListFunctionalities } from "../../domain/composables/listFunctionalities";

const appStore = useAppStore();

let listFunctions = reactive(useListFunctionalities());

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

async function deleteCallback(): Promise<void> {
  console.log("delete");
}

async function addCallback(): Promise<void> {
  appStore.toggleChooseAddEditRecipeModal();
}
</script>

<style scoped></style>
