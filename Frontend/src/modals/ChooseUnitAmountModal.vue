<template>
<div class="modal-overlay">
    <div class="modal">
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
        <div class="all-units-list">
            <ul>
                <li
                v-for="unit in units"
                :key="unit.id"
                class="item"
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
.modal {
    width: 60%;
    background-color: white;
    padding: 2rem;
}

.modal-overlay {
  position: fixed;
  z-index: 150;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba(0, 0, 0, 0.5);
}

header {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: flex-start;
}

h2 {
    margin: 0;
}

.all-units-list {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.item {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  padding: 0.5rem 2rem;
  font-size: large;
}

.item:hover {
  background-color: beige;
  cursor: pointer;
}

.selected {
  background-color: blanchedalmond;
}

.selected:hover {
  background-color: blanchedalmond;
}

.btn-1, .btn-2 {
    border-color: white;
}
</style>
