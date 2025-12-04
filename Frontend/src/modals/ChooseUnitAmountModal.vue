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
                v-for="unit in unitStore.allUnits"
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
import useUnitStore from "../stores/unitStore";

const emits = defineEmits(["close"]);

const appStore = useAppStore();
const unitStore = useUnitStore();

function close() {
    emits("close");
}

const currentlyProcessedUnit = ref<GetUnitDto>();

function selectUnit(unit: GetUnitDto) {
  currentlyProcessedUnit.value = unit;
}

function openUnitModal() {
    appStore.toggleChooseAddUnitModal();
}
</script>

<style scoped>
.btn-1, .btn-2 {
    border-color: white;
}
</style>
