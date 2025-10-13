import type { EditAction } from "../enums/editAction";

export interface NewEditRecipeIngredientDto {
  ingredientId: string;
  ingredientAmount: number | null;
  unitId: string | null;
  editAction: EditAction | null;
}
