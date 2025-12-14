<template>
  <div class="modal-overlay">
    <form class="modal modal-big">
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
    <ul v-show="recipeAmount.length != 0" class="units-amount-list">
        <li
          v-for="amount in recipeAmount"
          :key="amount.unitRecipeTitle"
          class="units-amount-item"
        >
          {{ amount.recipeAmount + " " + amount.unitRecipeTitle }}
          <span class="material-symbols-outlined unit-amount-delete-btn">cancel</span>
        </li>
    </ul>
    <div class="list-of-choices scroll-list-container">
      <h2 class="list-title">Choose an ingredient</h2>
      <ul class="scroll-list">
        <li
          v-for="ingredient in availableIngredients"
          :key="ingredient.id"
          class="list-item-title-two-buttons"
          :class="{
            selected: currentlyProcessedIngredient?.id == ingredient.id,
            added: addedIngredients?.find(i => i.id == ingredient.id)
          }"
          @click="selectIngredient(ingredient)"
        >
          <div class="title">{{ ingredient.title }}</div>
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
            <button class="btn-2" v-show="!addedIngredients?.find(i => i.id == ingredient.id)" @click.prevent="addIngredient(ingredient)">Add without amount</button>
            <button class="btn-2" v-show="addedIngredients?.find(i => i.id == ingredient.id)" @click.prevent="removeIngredient(ingredient)">Remove ingredient</button>
          </div>
          <div class="info" v-show="addedIngredients?.find(i => i.id == ingredient.id)">{{ '1 pack' }}</div>
        </li>
      </ul>
    </div>
  </form>
  <teleport to="#modal-container">
    <ChooseUnitAmountModal
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
import { computed, provide, reactive, ref } from "vue";
import type { GetIngredientDto } from "../domain/models/getIngredientDto";
import ChooseUnitAmountModal from "./ChooseUnitAmountModal.vue";
import useAppStore from "../stores/applicationStore";
import type { GetUnitsRecipeDto } from "../domain/models/getUnitsRecipeDto";
import type { GetUnitDto } from "../domain/models/getUnitDto";
import type { UnitAmount } from "../domain/models/unitAmount";

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
  {
    id: "12",
    title: "Cukor",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "13",
    title: "Por",
    soldPackageSize: 1,
    unitId: "ks",
    creatorId: "1111",
  },
  {
    id: "14",
    title: "Muka",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "19",
    title: "Caj",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
  {
    id: "18",
    title: "kava",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
];


provide('addUnitAmount', addUnitAmount);

const addedIngredients = ref<GetIngredientDto[]>([]);

const appStore = useAppStore();
const currentlyProcessedIngredient = ref<GetIngredientDto>();
let recipeAmount = ref<Array<GetUnitsRecipeDto>>([]);

const modalUnitAmountOpen = ref<boolean>(false);
const modalTitle = ref<string>();

const availableIngredients = computed<GetIngredientDto[]>(
  () =>
    // ingredients.filter(ingredient => !selectedIngredients.value.includes(ingredient))
    ingredients
);

function addUnitAmount(unitAmount: UnitAmount) {
  console.log('called addUnitAmount from addeditrecipeModal');
  console.log(recipeAmount.value);
  recipeAmount.value = recipeAmount.value.filter(ra => ra.unitRecipeTitle != unitAmount.unit.title);
  const newUnitRecipe: GetUnitsRecipeDto = {
    unitRecipeTitle: unitAmount.unit.title,
    recipeAmount: unitAmount.amount,
  }
  recipeAmount.value.push(newUnitRecipe);
}

function selectIngredient(ingredient: GetIngredientDto) {
  if(currentlyProcessedIngredient.value?.id == ingredient.id) {
    currentlyProcessedIngredient.value = undefined;
  } else {
    currentlyProcessedIngredient.value = ingredient;
  }
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

function removeIngredient(ingredient: GetIngredientDto) {
  console.log(addedIngredients.value);
  addedIngredients.value = addedIngredients.value.filter(i => i.id != ingredient.id);
}

function addIngredient(ingredient: GetIngredientDto) {
  console.log(addedIngredients.value);
  addedIngredients.value?.push(ingredient);
}
</script>

<style scoped>

.modal {
  width: 80%;
}

.input {
  font-size: large;
}

.star-icon {
  margin-right: 5px;
}

.three-button-group .btn-icon {
  border: 5px solid white;
}

.three-button-group .btn-1, .three-button-group .btn-2 {
  border-color: white;
}

</style>
