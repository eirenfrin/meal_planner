<template>
  <OverviewList
    :editing-mode="listFunctions.editingMode"
    :add-callback="addCallback"
    :delete-callback="deleteCallback"
    header-title="All Units"
    @change-edit-mode="listFunctions.editModeCallback"
  >
    <template #content>
      <ul class="list scroll-list">
        <li
          class="list-entry"
          v-for="unit in unitStore.allUnits"
          :key="unit.id"
          @click="!listFunctions.editingMode && editCallback(unit)"
        >
          <UnitOverviewListEntry
            :editing-mode="listFunctions.editingMode"
            :unit="unit"
            @toggle-unit="listFunctions.toggleCallback"
          />
        </li>
      </ul>
    </template>
  </OverviewList>
</template>

<script setup lang="ts">
import { reactive } from "vue";
import UnitOverviewListEntry from "./UnitOverviewListEntry.vue";
import OverviewList from "../generic/OverviewList.vue";
import useAppStore from "../../stores/applicationStore";
import useUnitStore from "../../stores/unitStore";
import { useListFunctionalities } from "../../domain/composables/listFunctionalities";
import type { GetUnitDto } from "../../domain/models/getUnitDto";

const appStore = useAppStore();
const unitStore = useUnitStore();

let listFunctions = reactive(useListFunctionalities());

async function deleteCallback(): Promise<void> {
  let ids = listFunctions.takeIdsToDelete();
  await unitStore.deleteUnits(ids);
}

async function addCallback(): Promise<void> {
  appStore.toggleChooseAddUnitModal();
}

async function editCallback(unit: GetUnitDto): Promise<void> {
  unitStore.setEditUnitInfo(unit);
  appStore.toggleChooseEditUnitModal();
}
</script>

<style scoped></style>
