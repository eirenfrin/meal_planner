import { defineStore } from "pinia";
import type { IngredientStoreState } from "../domain/store-states/ingredientStoreState";
import type { GetIngredientDto } from "../domain/models/getIngredientDto";
import { computed, reactive } from "vue";

const useIngredientStore = defineStore("ingredientStore", () => {
  const state: IngredientStoreState = reactive({
    ingredients: [],
    editIngredientInfo: null as GetIngredientDto | null,
  });

  const allIngredients = computed(() => state.ingredients);

  const editIngredientInfo = computed(() => state.editIngredientInfo);

  return {
    allIngredients,
    editIngredientInfo,
  };
});
