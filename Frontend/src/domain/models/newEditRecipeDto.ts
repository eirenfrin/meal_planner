import type { NewEditRecipeIngredientDto } from "./newEditRecipeIngredientDto";
import type { NewEditUnitsRecipeDto } from "./newEditUnitsRecipeDto";

export interface NewEditRecipeDto {
  title: string;
  recipeIngredients: Array<NewEditRecipeIngredientDto>;
  unitsRecipe: Array<NewEditUnitsRecipeDto>;
}
