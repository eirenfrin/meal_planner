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
          v-for="ingredient in ingredients"
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

const appStore = useAppStore();

let editingMode = ref(false);
let listOfIdsToDelete = ref<Array<string>>([]);
let ingredients: Array<GetIngredientDto> = [
  {
    id: "123456",
    title: "Vanilka",
    soldPackageSize: 3,
    unitId: "pack",
    creatorId: "null",
  },
  {
    id: "123455",
    title: "Bravcove pliecko",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "123457",
    title: "Por",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "123458",
    title: "Cibula cervena",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "123459",
    title: "Cibula biela",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "123460",
    title: "Cibula bezna",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "123461",
    title: "Jarna cibulka",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
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
  appStore.toggleChooseAddEditIngredientModal();
}
</script>

<style scoped></style>
