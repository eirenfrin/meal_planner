import type { MealplanRecipeDto } from "./MealplanRecipeDto";

export interface MealplanAllInfoDto {
  id: string;
  title: string;
  plannedStartDate: Date;
  plannedRecipes: Array<MealplanRecipeDto>;
}
