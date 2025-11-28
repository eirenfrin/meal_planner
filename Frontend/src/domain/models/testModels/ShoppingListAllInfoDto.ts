import type { ShoppingListIngredientDto } from "./ShoppingListIngredientDto";

export interface ShoppingListAllInfoDto {
  id: string;
  title: string;
  plannedStartDate: string;
  isDefault: boolean;
  ingredients: ShoppingListIngredientDto[];
}
