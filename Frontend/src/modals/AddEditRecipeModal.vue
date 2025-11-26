<template>
  <div class="modal-overlay">
    <form class="modal">
    <header>
      <h1>New recipe</h1>
      <div class="three-button-group">
        <button class="btn-icon" @click.prevent="openPreview">
          <span class="star-icon material-symbols-outlined">star</span>Preview
          recipe
        </button>
        <div class="two-button-group">
          <button class="btn-1">Save</button>
          <button class="btn-2" @click.prevent="close">Cancel</button>
        </div>
      </div>
    </header>
    <div class="input-button-group">
        <input class="input" 
        type="text"
        id="username"
        placeholder="Enter Recipe Title">
        </input>
        <button
          class="btn"
          @click.prevent="openUnitAmountModal('Recipe yield')"
        >
          Add yield
        </button>
    </div>
    <div class="all-ingredients-list">
      <h2>Choose an ingredient</h2>
      <ul>
        <li
          v-for="ingredient in availableIngredients"
          :key="ingredient.id"
          class="item"
          :class="{
            selected: currentlyProcessedIngredient?.id == ingredient.id,
          }"
          @click="selectIngredient(ingredient)"
        >
          {{ ingredient.title }}
          <div
            v-if="currentlyProcessedIngredient?.id == ingredient.id"
            class="two-button-group"
          >
            <button
              class="btn-1"
              @click.prevent="openUnitAmountModal(ingredient.title)"
            >
              Choose a unit
            </button>
            <button class="btn-2">Add without amount</button>
          </div>
        </li>
      </ul>
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
import { computed, ref } from "vue";
import type { GetIngredientDto } from "../domain/models/getIngredientDto";
import ChooseUnitAmountModal from "./ChooseUnitAmountModal.vue";
import useAppStore from "../stores/applicationStore";

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
];

const appStore = useAppStore();
const currentlyProcessedIngredient = ref<GetIngredientDto>();

const modalUnitAmountOpen = ref<boolean>(false);
const modalTitle = ref<string>();

const availableIngredients = computed<GetIngredientDto[]>(
  () =>
    // ingredients.filter(ingredient => !selectedIngredients.value.includes(ingredient))
    ingredients
);

function selectIngredient(ingredient: GetIngredientDto) {
  currentlyProcessedIngredient.value = ingredient;
}

function openUnitAmountModal(title: string) {
  setModalTitle(title);
  modalUnitAmountOpen.value = true;
}

function setModalTitle(title: string) {
  modalTitle.value = title;
}

function closeUnitAmountModal() {
  modalUnitAmountOpen.value = false;
}

function close() {
  appStore.toggleChooseAddEditRecipeModal();
}

function openPreview() {
  appStore.toggleChooseRecipePreviewModal();
}
</script>

<style scoped>
ul {
  list-style: none;
  padding: 0;
  margin: 0;
}
li {
  padding: 0.2rem;
}
form {
  width: 80%;
  background-color: white;
  padding: 2rem 5rem;
  box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.1), 0 6px 20px 0 rgba(0, 0, 0, 0.1);
}
header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: flex-start;
  margin-bottom: 1rem;
}

.input {
  font-size: x-large;
}

.star-icon {
  margin-right: 5px;
}

.three-button-group {
  display: flex;
  flex-direction: row;
  align-items: stretch;
  gap: 5px;
}

.three-button-group .btn-icon {
  border: 5px solid white;
}

.three-button-group .btn-1, .three-button-group .btn-2 {
  border-color: white;
}

.all-ingredients-list {
  display: flex;
  flex-direction: column;
  width: 100%;
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
.radio-restyle input[type="radio"] {
  display: none;
}
.selected {
  background-color: blanchedalmond;
}
.selected:hover {
  background-color: blanchedalmond;
}
</style>
