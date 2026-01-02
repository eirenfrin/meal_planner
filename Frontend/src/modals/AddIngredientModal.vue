<template>
    <div class="modal-overlay">
    <form class="modal modal-small">
      <header>
        <div class="modal-info">
          <h1>Add ingredient</h1>
        </div>
        <div class="two-button-group">
          <button class="btn-1" @click.prevent="saveIngredient">Save</button>
          <button class="btn-2" @click.prevent="close">Cancel</button>
        </div>
      </header>
      <div class="input-button-group">
        <input class="input" 
        type="text"
        id="ingredient-title"
        placeholder="Enter ingredient title"
        v-model="ingredientTitleInput">
        </input>
        <button
          class="btn"
          @click.prevent="openUnitAmountModal('Ingredient package size')"
        >
          Add package size
        </button>
    </div>
    <ul v-show="unitsAmountSold" class="units-amount-list">
        <li
          v-for="amount in unitsAmountSold"
          :key="amount.unitId"
          class="units-amount-item"
        >
          {{`${amount.amount + ' ' + amount.unitTitle}` }}
          <span class="material-symbols-outlined unit-amount-delete-btn" @click.prevent="removeUnitsAmountSold">cancel</span>
        </li>
    </ul>
    </form>
    <teleport to="#modal-container">
    <ChooseUnitAmountModal
      :add-unit-amount="addUnitAmount"
      class="modal"
      v-show="modalUnitAmountOpen"
      @close="closeUnitAmountModal"
    >
      <template #text-amount-for>
        <h3 class="modal-title">{{ modalTitle }}</h3>
      </template>
    </ChooseUnitAmountModal>
  </teleport>
  </div>
</template>



<script setup lang="ts">
import { ref } from 'vue';
import useAppStore from '../stores/applicationStore';
import ChooseUnitAmountModal from "./ChooseUnitAmountModal.vue";
import type { UnitAmount } from '../domain/models/unitAmount';
import useIngredientStore from '../stores/ingredientStore';

const appStore = useAppStore();
const ingredientStore = useIngredientStore();

const modalUnitAmountOpen = ref<boolean>(false);
const modalTitle = ref<string>();
const ingredientTitleInput = ref<string>("");
let unitsAmountSold = ref<Array<UnitAmount>>([]);

function addUnitAmount(unitAmount : UnitAmount) {
  unitsAmountSold.value.pop();
  unitsAmountSold.value.push(unitAmount)
}

function close(): void {
    appStore.toggleChooseAddIngredientModal();
}

function openUnitAmountModal(title: string) {
  modalTitle.value = title;
  modalUnitAmountOpen.value = true;
}

function removeUnitsAmountSold() {
  unitsAmountSold.value.pop();
}

function closeUnitAmountModal() {
  modalUnitAmountOpen.value = false;
}

async function saveIngredient(): Promise<void> {
  await ingredientStore.addIngredient(ingredientTitleInput.value, unitsAmountSold.value);
  close();
}
</script>

<style scoped>

.btn-1, .btn-2 {
  border-color: white;
}

h1 {
  margin-bottom: 0;
}
</style>