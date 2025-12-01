<template>
<div class="modal-overlay">
    <div class="modal modal-big">
        <header>
            <div class="modal-info">
                <h2>Choose a unit and amount for:</h2>
                <slot name="text-amount-for"></slot>
            </div>
            <div class="two-button-group">
                <button class="btn-1" @click="openUnitModal">New unit</button>
                <button class="btn-2" @click="close">Cancel</button>
            </div>
        </header>
        <div class="list-of-choices scroll-list-container">
            <ul class="scroll-list">
                <li
                v-for="unit in units"
                :key="unit.id"
                class="list-item-input-button"
                :class="{ selected: currentlyProcessedUnit?.id == unit.id }"
                @click="selectUnit(unit)"
                >
                {{ unit.title }}
                    <div
                        v-if="currentlyProcessedUnit?.id == unit.id"
                        class="input-button-group"
                    >
                        <input type="number" class="input" placeholder="Enter amount"></input>
                        <button class="btn">Add amount</button>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import type { GetUnitDto } from "../domain/models/getUnitDto";
import useAppStore from "../stores/applicationStore";

const emits = defineEmits(["close"]);

const appStore = useAppStore();

function close() {
    emits("close");
}

let units: Array<GetUnitDto> = [
  {
    id: "44",
    title: "kg",
    creatorId: "11",
  },
  {
    id: "45",
    title: "glass",
    creatorId: "11",
  },
  {
    id: "47",
    title: "bowl",
    creatorId: "11",
  },
  {
    id: "48",
    title: "tea spoon",
    creatorId: "11",
  },
  {
    id: "49",
    title: "table spoon",
    creatorId: "11",
  },
  {
    id: "50",
    title: "pinch",
    creatorId: "11",
  },
  {
    id: "51",
    title: "tray",
    creatorId: "11",
  },
  {
    id: "52",
    title: "gram",
    creatorId: "11",
  },
];

const currentlyProcessedUnit = ref<GetUnitDto>();

function selectUnit(unit: GetUnitDto) {
  currentlyProcessedUnit.value = unit;
}

function openUnitModal() {
    appStore.toggleChooseAddEditUnitModal();
}
</script>

<style scoped>
.btn-1, .btn-2 {
    border-color: white;
}
</style>
