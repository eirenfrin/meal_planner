import type { EditAction } from "../enums/editAction";

export interface NewEditUnitsRecipeDto {
  recipeAmount: number;
  unitId: string;
  editAction: EditAction | null;
}
