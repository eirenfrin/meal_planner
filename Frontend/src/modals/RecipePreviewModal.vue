<template>
  <div class="modal-overlay">
    <div class="modal">
      <article>
        <header>
          <h1>{{ recipe.title }}</h1>
          <button @click.prevent="close">Close preview</button>
        </header>
        <div>
          <ul v-if="recipe.recipeAmount.length != 0" class="units-recipe-list">
            <li v-for="amount in recipe.recipeAmount" class="units-recipe-item">
              {{ amount.recipeAmount + " " + amount.unitRecipeTitle }}
            </li>
          </ul>
        </div>
        <section>
          <ul class="ingredients-list">
            <li
              v-for="ingredient in recipe.ingredients"
              class="ingredient-item"
            >
              <h2>{{ ingredient.ingredientTitle }}</h2>
              <div>{{ ingredient.amount + " " + ingredient.unitTitle }}</div>
            </li>
          </ul>
        </section>
      </article>
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

<style scoped>
header {
  display: flex;
  flex-direction: row;
  align-items: flex-start;
  justify-content: space-between;
}
.ingredients-list {
  display: flex;
  flex-direction: column;
}
.ingredient-item {
  padding-left: 1rem;
  display: grid;
  grid-template-columns: 1fr 2fr;
  align-items: center;
}
.ingredient-item:hover {
  background-color: rgb(241, 241, 241);
}

.units-recipe-list {
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
}
</style>
