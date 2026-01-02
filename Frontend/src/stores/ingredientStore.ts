import { defineStore } from "pinia";
import type { IngredientStoreState } from "../domain/store-states/ingredientStoreState";
import type { GetIngredientDto } from "../domain/models/getIngredientDto";
import { computed, reactive } from "vue";
import ingredientService from "../api/services/ingredientService";
import type { NewEditIngredientDto } from "../domain/models/newEditIngredientDto";
import type { UnitAmount } from "../domain/models/unitAmount";
import type { BatchDeleteDto } from "../domain/models/batchDeleteDto";

const useIngredientStore = defineStore("ingredientStore", () => {
  const state: IngredientStoreState = reactive({
    ingredients: [],
    editIngredientInfo: null as GetIngredientDto | null,
  });

  const allIngredients = computed(() => state.ingredients);

  const editIngredientInfo = computed(() => state.editIngredientInfo);

  function setEditIngredientInfo(ingredient: GetIngredientDto) {
    state.editIngredientInfo = ingredient;
  }

  async function getAllIngredients(): Promise<void> {
    try {
      let ingredients = await ingredientService.getAllIngredients();
      state.ingredients = ingredients;
    } catch (e) {}
  }

  async function addIngredient(
    title: string,
    unitAmount: Array<UnitAmount>
  ): Promise<void> {
    try {
      let newIngredient: NewEditIngredientDto = {
        title: title,
        unitId: unitAmount[0]?.unitId ?? null,
        soldPackageSize: unitAmount[0]?.amount ?? null,
      };

      let ingredient = await ingredientService.addNewIngredient(newIngredient);

      state.ingredients.push(ingredient);
    } catch (e: any) {}
  }

  async function deleteIngredients(
    ingredientIds: Array<string>
  ): Promise<void> {
    try {
      let idsDto: BatchDeleteDto = {
        ids: ingredientIds,
      };

      await ingredientService.deleteBatchIngredients(idsDto);

      state.ingredients = state.ingredients.filter(
        (ing) => !ingredientIds.includes(ing.id)
      );
    } catch (e: any) {}
  }

  async function editIngredient(
    ingredientTitle: string,
    unitId?: string,
    soldAmount?: number
  ): Promise<void> {
    try {
      let editedIngredient: NewEditIngredientDto = {
        title: ingredientTitle,
        unitId: unitId ?? null,
        soldPackageSize: soldAmount ?? null,
      };

      await ingredientService.editIngredient(
        state.editIngredientInfo!.id,
        editedIngredient
      );
    } catch (e: any) {}
  }

  return {
    allIngredients,
    editIngredientInfo,
    setEditIngredientInfo,
    getAllIngredients,
    addIngredient,
    deleteIngredients,
    editIngredient,
  };
});

export default useIngredientStore;
