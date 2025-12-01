<template>
  <div class="modal-overlay">
    <form class="modal modal-big">
    <header>
      <h1>New shopping list</h1>
      <div class="three-button-group">
        <button class="btn-icon" @click.prevent="openPreview">
          <span class="star-icon material-symbols-outlined">star</span>Preview
          list
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
        placeholder="Enter List Title">
        </input>
        <button
          class="btn"
          @click.prevent="openDateModal()"
        >
          Choose shopping date
        </button>
    </div>
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
  </div>
</template>

<script setup lang="ts">
import { computed, ref } from "vue";
import type { GetIngredientDto } from "../domain/models/getIngredientDto";
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

const addedIngredients = ref<GetIngredientDto[]>([]);

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

function openDateModal() {
    appStore.toggleChooseDateModal();
}

function close() {
  appStore.toggleChooseAddEditShoppingListModal();
}

function openPreview() {
  appStore.toggleChooseShoppingListPreviewModal();
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

.input-button-group {
  margin-bottom: 2rem;
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
