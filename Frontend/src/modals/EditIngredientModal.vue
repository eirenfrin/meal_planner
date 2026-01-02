<template>
    <div class="modal-overlay">
    <form class="modal modal-small">
      <header>
        <div class="modal-info">
          <h1>Edit ingredient</h1>
        </div>
        <div class="two-button-group">
          <button class="btn-1" @click.prevent="editIngredient">Save</button>
          <button class="btn-2" @click.prevent="close">Cancel</button>
        </div>
      </header>
      <div class="input-button-group">
        <input class="input" 
        type="text"
        id="ingredient-title"
        v-model="editedTitle">
        </input>
        <button
          class="btn"
          @click.prevent="openUnitAmountModal('Ingredient package size')"
        >
          Add package size
        </button>
    </div>
    <ul v-show="unitsAmountSold.length != 0" class="units-amount-list">
        <li
          v-for="amount in unitsAmountSold"
          :key="amount.unitId"
          class="units-amount-item"
        >
          {{ amount.amount + ' ' + amount.unitTitle }}
          <span class="material-symbols-outlined unit-amount-delete-btn" @click="deleteUnitAmount">cancel</span>
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
import { ref, watch } from 'vue';
import useAppStore from '../stores/applicationStore';
import ChooseUnitAmountModal from "./ChooseUnitAmountModal.vue";
import useIngredientStore from '../stores/ingredientStore';
import type { UnitAmount } from '../domain/models/unitAmount';


const appStore = useAppStore();
const ingredientStore = useIngredientStore();

const editedTitle = ref<string>(ingredientStore.editIngredientInfo!.title);

const modalUnitAmountOpen = ref<boolean>(false);
const modalTitle = ref<string>();
const unitsAmountSold = ref<Array<UnitAmount>>([])

watch(() => appStore.chooseEditIngredientModal, (isOpened: boolean) => {
  if (
    isOpened 
    && ingredientStore.editIngredientInfo!.unitId != null 
    && ingredientStore.editIngredientInfo!.unitTitle != null
    && ingredientStore.editIngredientInfo!.soldPackageSize != null
  ) {
    var unitAmount: UnitAmount = {
      unitId: ingredientStore.editIngredientInfo!.unitId,
      unitTitle: ingredientStore.editIngredientInfo!.unitTitle,
      amount: ingredientStore.editIngredientInfo!.soldPackageSize,
    }
    unitsAmountSold.value.push(unitAmount);
  }
},
{ immediate: true }
)

function addUnitAmount(unitAmount : UnitAmount) {
  unitsAmountSold.value.pop();
  unitsAmountSold.value.push(unitAmount)
}

function deleteUnitAmount() {
  unitsAmountSold.value.pop();
}

function close(): void {
    appStore.toggleChooseEditIngredientModal();
}

function openUnitAmountModal(title: string) {
  modalTitle.value = title;
  modalUnitAmountOpen.value = true;
}

function closeUnitAmountModal() {
  modalUnitAmountOpen.value = false;
}

async function editIngredient(): Promise<void> {
  await ingredientStore.editIngredient(editedTitle.value, unitsAmountSold.value[0]?.unitId, unitsAmountSold.value[0]?.amount);
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