<template>
    <div class="modal-overlay">
    <form class="modal modal-small">
      <header>
        <div class="modal-info">
          <h1>Add ingredient</h1>
        </div>
        <div class="two-button-group">
          <button class="btn-1" @click.prevent>Save</button>
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
          :key="amount"
          class="units-amount-item"
        >
          {{ amount }}
          <span class="material-symbols-outlined unit-amount-delete-btn">cancel</span>
        </li>
    </ul>
    </form>
    <teleport to="#modal-container">
    <ChooseUnitAmountModal
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
import { computed, inject, provide, reactive, ref } from 'vue';
import useAppStore from '../stores/applicationStore';
import ChooseUnitAmountModal from "./ChooseUnitAmountModal.vue";
import type { GetUnitDto } from '../domain/models/getUnitDto';
import type { UnitAmount } from '../domain/models/unitAmount';

const appStore = useAppStore();

// const context = reactive({
//   unit: null as GetUnitDto | null,
//   amount: null as number | null,
// });

const modalUnitAmountOpen = ref<boolean>(false);
const modalTitle = ref<string>();
const ingredientTitleInput = ref<string>("");
let unitsAmountSold = ref<Array<string>>([]);
// const unitsAmountSold = computed(() => {
//   if(context.unit && context.amount) {
//     return [`${context.amount?.toString() + ' ' + context.unit?.title}`];
//   }
// });
function addUnitAmount(unitAmount : UnitAmount) {
  console.log('called addunitamount from addingredientmodal');
  unitsAmountSold.value.pop();
  let newAmount: string = `${unitAmount.amount + ' ' + unitAmount.unit.title}`
  unitsAmountSold.value.push(newAmount)
}

provide('addUnitAmount', addUnitAmount);

function close(): void {
    appStore.toggleChooseAddEditIngredientModal();
}

function openUnitAmountModal(title: string) {
  modalTitle.value = title;
  modalUnitAmountOpen.value = true;
}

function closeUnitAmountModal() {
  modalUnitAmountOpen.value = false;
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