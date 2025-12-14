import type { CurrentPage } from "../enums/currentPage";
import type { CurrentSubPage } from "../enums/currentSubPage";

export interface AppStoreState {
  currentPage: CurrentPage;
  currentSubpage?: CurrentSubPage;
  chooseAddUnitModalVisibility: boolean;
  chooseEditUnitModalVisibility: boolean;
  chooseAddIngredientModalVisibility: boolean;
  chooseEditIngredientModalVisibility: boolean;

  chooseAddEditRecipeModalVisibility: boolean;
  chooseRecipePreviewModalVisibility: boolean;
  chooseShoppingListPreviewModalVisibility: boolean;
  chooseAddEditShoppingListModalVisibility: boolean;
  chooseDateModalVisibility: boolean;
}
