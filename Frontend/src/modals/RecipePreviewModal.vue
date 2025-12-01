<template>
  <div class="modal-overlay">
    <div class="modal modal-big">
      <header>
        <h1>{{ recipe.title }}</h1>
        <button @click.prevent="close">Close preview</button>
      </header>
      <ul v-if="recipe.recipeAmount.length != 0" class="units-amount-list">
        <li
          v-for="amount in recipe.recipeAmount"
          :key="amount.unitRecipeTitle"
          class="units-amount-item"
        >
          {{ amount.recipeAmount + " " + amount.unitRecipeTitle }}
        </li>
      </ul>
      <ul class="scroll-list preview-list">
        <li
          v-for="ingredient in recipe.ingredients"
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
import type { GetRecipeAllInfoDto } from "../domain/models/getRecipeAllInfoDto";
import type { GetRecipeIngredientDto } from "../domain/models/getRecipeIngredientDto";
import type { GetUnitsRecipeDto } from "../domain/models/getUnitsRecipeDto";
import useAppStore from "../stores/applicationStore";

const appStore = useAppStore();

let ingredients: Array<GetRecipeIngredientDto> = [
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

let unitsRecipe: Array<GetUnitsRecipeDto> = [
  {
    unitRecipeTitle: "medium size pot",
    recipeAmount: 1,
  },
  {
    unitRecipeTitle: "liter",
    recipeAmount: 1.8,
  },
];

let recipe: GetRecipeAllInfoDto = {
  id: "11",
  title: "Rybacia polievka",
  lastCooked: new Date(),
  ingredients: ingredients,
  recipeAmount: unitsRecipe,
};

function close(): void {
  appStore.toggleChooseRecipePreviewModal();
}
</script>

<style scoped></style>
