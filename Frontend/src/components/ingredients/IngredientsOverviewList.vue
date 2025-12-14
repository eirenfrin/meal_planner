<template>
  <OverviewList
    :editing-mode="editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="All Ingredients"
    @change-edit-mode="editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li
          class="list-entry"
          v-for="ingredient in ingredientStore.allIngredients"
          :key="ingredient.id"
        >
          <IngredientOverviewListEntry
            :editing-mode="editingMode"
            :ingredient="ingredient"
            @toggle-unit="toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { ref } from "vue";
import type { GetIngredientDto } from "../../domain/models/getIngredientDto";
import IngredientOverviewListEntry from "./IngredientOverviewListEntry.vue";
import OverviewList from "../generic/OverviewList.vue";
import useAppStore from "../../stores/applicationStore";
import useIngredientStore from "../../stores/ingredientStore";

const appStore = useAppStore();
const ingredientStore = useIngredientStore();

let editingMode = ref(false);
let listOfIdsToDelete = ref<Array<string>>([]);

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
  appStore.toggleChooseAddIngredientModal();
}
</script>

<style scoped></style>
