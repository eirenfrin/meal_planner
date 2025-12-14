import { defineStore } from "pinia";
import type { IngredientStoreState } from "../domain/store-states/ingredientStoreState";
import type { GetIngredientDto } from "../domain/models/getIngredientDto";
import { computed, reactive } from "vue";
import ingredientService from "../api/services/ingredientService";
import type { NewEditIngredientDto } from "../domain/models/newEditIngredientDto";
import type { UnitAmount } from "../domain/models/unitAmount";

const useIngredientStore = defineStore("ingredientStore", () => {
  const state: IngredientStoreState = reactive({
    ingredients: [],
    editIngredientInfo: null as GetIngredientDto | null,
  });

  const allIngredients = computed(() => state.ingredients);

  const editIngredientInfo = computed(() => state.editIngredientInfo);

  async function getAllIngredients(): Promise<void> {
    try {
      let ingredients = await ingredientService.getAllIngredients();

      state.ingredients = ingredients;
    } catch (e) {}
  }

  async function addIngredient(
    title: string,
    unitAmount: UnitAmount
  ): Promise<void> {
    try {
      let newIngredient: NewEditIngredientDto = {
        title: title,
        unitId: unitAmount.unit.id,
        soldPackageSize: unitAmount.amount,
      };

      let ingredient = await ingredientService.addNewIngredient(newIngredient);

      state.ingredients.push(ingredient);
    } catch (e: any) {}
  }

  return {
    allIngredients,
    editIngredientInfo,
    getAllIngredients,
    addIngredient,
  };
});

export default useIngredientStore;
