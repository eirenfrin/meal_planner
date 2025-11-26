<template>
    <div class="modal-overlay">
    <form class="modal">
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
        placeholder="Enter ingredient title">
        </input>
        <button
          class="btn"
          @click.prevent="openUnitAmountModal('Ingredient package size')"
        >
          Add package size
        </button>
    </div>
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
import { ref } from 'vue';
import useAppStore from '../stores/applicationStore';
import ChooseUnitAmountModal from "./ChooseUnitAmountModal.vue";

const appStore = useAppStore();

const modalUnitAmountOpen = ref<boolean>(false);
const modalTitle = ref<string>();

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
header {
  display: flex;
  flex-direction: row;
  align-items: flex-start;
  justify-content: space-between;
}

.btn-1, .btn-2 {
  border-color: white;
}

h1 {
  margin-bottom: 1rem;
}
</style>