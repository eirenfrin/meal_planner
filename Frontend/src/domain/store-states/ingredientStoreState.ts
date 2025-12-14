import type { GetIngredientDto } from "../models/getIngredientDto";

export interface IngredientStoreState {
  ingredients: Array<GetIngredientDto>;
  editIngredientInfo: GetIngredientDto | null;
}
