<template>
  <OverviewList
    :editing-mode="listFunctions.editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="All Ingredients"
    @change-edit-mode="listFunctions.editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li
          class="list-entry"
          v-for="ingredient in ingredientStore.allIngredients"
          :key="ingredient.id"
          @click="!listFunctions.editingMode && editCallback(ingredient)"
        >
          <IngredientOverviewListEntry
            :editing-mode="listFunctions.editingMode"
            :ingredient="ingredient"
            @toggle-ingredient="listFunctions.toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { compile, reactive } from "vue";
import IngredientOverviewListEntry from "./IngredientOverviewListEntry.vue";
import OverviewList from "../generic/OverviewList.vue";
import useAppStore from "../../stores/applicationStore";
import useIngredientStore from "../../stores/ingredientStore";
import { useListFunctionalities } from "../../domain/composables/listFunctionalities";
import type { GetIngredientDto } from "../../domain/models/getIngredientDto";

const appStore = useAppStore();
const ingredientStore = useIngredientStore();

let listFunctions = reactive(useListFunctionalities());

async function deleteCallback(): Promise<void> {
  let ids = listFunctions.takeIdsToDelete();
  console.log(ids);
  await ingredientStore.deleteIngredients(ids);
}

async function addCallback(): Promise<void> {
  appStore.toggleChooseAddIngredientModal();
}

async function editCallback(ingredient: GetIngredientDto): Promise<void> {
  ingredientStore.setEditIngredientInfo(ingredient);
  appStore.toggleChooseEditIngredientModal();
}
</script>

<style scoped></style>
