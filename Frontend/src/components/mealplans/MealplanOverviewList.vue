<template>
  <OverviewList
    :editing-mode="listFunctions.editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="My mealplans"
    @change-edit-mode="listFunctions.editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li
          class="list-entry"
          v-for="mealplan in mealplans"
          :key="mealplan.id"
          @click="
            !listFunctions.editingMode &&
              appStore.toggleChooseShoppingListPreviewModal()
          "
        >
          <MealplanOverviewListEntry
            :editing-mode="listFunctions.editingMode"
            :mealplan="mealplan"
            @toggle-entry="listFunctions.toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { reactive } from "vue";
import useAppStore from "../../stores/applicationStore";
import OverviewList from "../generic/OverviewList.vue";
import MealplanOverviewListEntry from "./MealplanOverviewListEntry.vue";
import type { MealplanDto } from "../../domain/models/testModels/MealplanDto";
import { useListFunctionalities } from "../../domain/composables/listFunctionalities";

const appStore = useAppStore();
let listFunctions = reactive(useListFunctionalities());

let mealplans: Array<MealplanDto> = [
  {
    id: "123456",
    title: "Sobota varenie",
    plannedStartDate: new Date(),
  },
  {
    id: "123455",
    title: "Navsteva cez tyzden",
    plannedStartDate: new Date(),
  },
  {
    id: "123454",
    title: "Vikendove varenie",
    plannedStartDate: new Date(new Date().setDate(1)),
  },
];

async function deleteCallback(): Promise<void> {
  console.log("delete");
}

async function addCallback(): Promise<void> {
  appStore.toggleChooseAddEditShoppingListModal();
}
</script>

<style scoped></style>
