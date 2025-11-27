<template>
  <OverviewList
    :editing-mode="editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="All Units"
    @change-edit-mode="editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li class="list-entry" v-for="unit in units" :key="unit.id">
          <UnitOverviewListEntry
            :editing-mode="editingMode"
            :unit="unit"
            @toggle-unit="toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { ref } from "vue";
import type { GetUnitDto } from "../../domain/models/getUnitDto";
import UnitOverviewListEntry from "./UnitOverviewListEntry.vue";
import OverviewList from "../generic/OverviewList.vue";
import useAppStore from "../../stores/applicationStore";

const appStore = useAppStore();

let editingMode = ref(false);
let listOfIdsToDelete = ref<Array<string>>([]);
let units: Array<GetUnitDto> = [
  {
    id: "123456",
    title: "Gram",
    creatorId: "null",
  },
  {
    id: "123455",
    title: "Polievkova lyzica",
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
  appStore.toggleChooseAddEditUnitModal();
}
</script>

<style scoped>
.list-entry {
  list-style: none;
  margin: 20px 0px;
  text-align: center;
}

.list {
  width: 100%;
  padding: 0px;
}
</style>
