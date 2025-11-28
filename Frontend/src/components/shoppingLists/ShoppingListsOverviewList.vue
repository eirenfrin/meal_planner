<template>
  <OverviewList
    :editing-mode="editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="My shopping lists"
    @change-edit-mode="editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li
          class="list-entry"
          v-for="shoppingList in shoppingLists"
          :key="shoppingList.id"
          @click.prevent="openPreview"
        >
          <ShoppingListOverviewListEntry
            :editing-mode="editingMode"
            :shoppingList="shoppingList"
            @toggle-entry="toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { ref } from "vue";
import useAppStore from "../../stores/applicationStore";
import OverviewList from "../generic/OverviewList.vue";
import ShoppingListOverviewListEntry from "./ShoppingListOverviewListEntry.vue";
import type { ShoppingListDto } from "../../domain/models/testModels/ShoppingListDto";

const appStore = useAppStore();
let editingMode = ref(false);
let listOfIdsToDelete = ref<Array<string>>([]);

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
  appStore.toggleChooseAddEditShoppingListModal();
}

function openPreview() {
  appStore.toggleChooseShoppingListPreviewModal();
}
</script>

<style scoped>
.list-entry {
  margin: 20px 0px;
  text-align: center;
}

.list-entry:hover {
  cursor: pointer;
}

.list {
  width: 100%;
  padding: 0px;
}
</style>
