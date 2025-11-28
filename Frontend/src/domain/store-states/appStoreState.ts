import type { CurrentPage } from "../enums/currentPage";
import type { CurrentSubPage } from "../enums/currentSubPage";

export interface AppStoreState {
  currentPage: CurrentPage;
  currentSubpage?: CurrentSubPage;
  chooseAddEditUnitModalVisibility: boolean;
  chooseAddEditIngredientModalVisibility: boolean;
  chooseAddEditRecipeModalVisibility: boolean;
  chooseRecipePreviewModalVisibility: boolean;
  chooseShoppingListPreviewModalVisibility: boolean;
  chooseAddEditShoppingListModalVisibility: boolean;
}
