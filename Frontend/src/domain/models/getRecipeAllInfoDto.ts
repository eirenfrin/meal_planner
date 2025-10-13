import type { GetRecipeIngredientDto } from "./getRecipeIngredientDto";
import type { GetUnitsRecipeDto } from "./getUnitsRecipeDto";

export interface GetRecipeAllInfoDto {
  id: string;
  title: string;
  lastCooked: Date;
  ingredients: Array<GetRecipeIngredientDto>;
  recipeAmount: Array<GetUnitsRecipeDto>;
}
