<template>
  <OverviewList
    :editing-mode="listFunctions.editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="My shopping lists"
    @change-edit-mode="listFunctions.editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li
          class="list-entry"
          v-for="shoppingList in shoppingLists"
          :key="shoppingList.id"
          @click="
            !listFunctions.editingMode &&
              appStore.toggleChooseShoppingListPreviewModal()
          "
        >
          <ShoppingListOverviewListEntry
            :editing-mode="listFunctions.editingMode"
            :shoppingList="shoppingList"
            @toggle-entry="listFunctions.toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import useAppStore from "../../stores/applicationStore";
import OverviewList from "../generic/OverviewList.vue";
import ShoppingListOverviewListEntry from "./ShoppingListOverviewListEntry.vue";
import type { ShoppingListDto } from "../../domain/models/testModels/ShoppingListDto";
import { useListFunctionalities } from "../../domain/composables/listFunctionalities";
import { reactive } from "vue";

const appStore = useAppStore();
let listFunctions = reactive(useListFunctionalities());

let shoppingLists: Array<ShoppingListDto> = [
  {
    id: "123456",
    title: "Billa zaklad",
    plannedStartDate: new Date(),
    isDefault: true,
  },
  {
    id: "123455",
    title: "Lidl zaklad",
    plannedStartDate: new Date(),
    isDefault: true,
  },
  {
    id: "123454",
    title: "Lidl tento tyzden",
    plannedStartDate: new Date(),
    isDefault: false,
  },
  {
    id: "123454",
    title: "dm",
    plannedStartDate: new Date(),
    isDefault: false,
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
