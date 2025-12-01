<template>
  <div class="modal-overlay">
    <div class="modal modal-big">
      <header>
        <h1>{{ shoppingList.title }}</h1>
        <button @click.prevent="close">Close preview</button>
      </header>
      <ul class="scroll-list preview-list">
        <li
          v-for="ingredient in shoppingList.ingredients"
          :key="ingredient.ingredientTitle"
          class="preview-list-item"
        >
          <h2>{{ ingredient.ingredientTitle }}</h2>
          <div>{{ ingredient.amount + " " + ingredient.unitTitle }}</div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { ShoppingListAllInfoDto } from "../domain/models/testModels/ShoppingListAllInfoDto";
import type { ShoppingListIngredientDto } from "../domain/models/testModels/ShoppingListIngredientDto";
import useAppStore from "../stores/applicationStore";

const appStore = useAppStore();

let ingredients: Array<ShoppingListIngredientDto> = [
  {
    ingredientTitle: "Vyvar",
    amount: 1,
    unitTitle: "liter",
  },
  {
    ingredientTitle: "Ryba",
    amount: 0.5,
    unitTitle: "kg",
  },
  {
    ingredientTitle: "Zemiaky",
    amount: 5,
    unitTitle: "kus",
  },
  {
    ingredientTitle: "Mrkva",
    amount: 1,
    unitTitle: "kus",
  },
  {
    ingredientTitle: "Kopor",
    amount: 1,
    unitTitle: "zvazok",
  },
  {
    ingredientTitle: "Sol",
    amount: 1,
    unitTitle: "zvazok",
  },
  {
    ingredientTitle: "Cierne korenie",
    amount: 1,
    unitTitle: "zvazok",
  },
];

let shoppingList: ShoppingListAllInfoDto = {
  id: "1222",
  title: "Lidl nakup piatok",
  plannedStartDate: "25.12.2025",
  isDefault: false,
  ingredients: ingredients,
};

function close(): void {
  appStore.toggleChooseShoppingListPreviewModal();
}
</script>

<style scoped>
.modal-overlay {
  z-index: 150;
}
</style>
