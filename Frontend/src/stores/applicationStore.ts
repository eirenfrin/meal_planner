import { defineStore } from "pinia";
import { computed, reactive } from "vue";
import type { AppStoreState } from "../domain/store-states/appStoreState";
import { CurrentPage } from "../domain/enums/currentPage";
import { CurrentSubPage } from "../domain/enums/currentSubPage";

const useAppStore = defineStore("applicationStore", () => {
  const state: AppStoreState = reactive({
    currentPage: CurrentPage.BASICS,
    currentSubpage: CurrentSubPage.RECIPES,
    chooseAddUnitModalVisibility: false,
    chooseEditUnitModalVisibility: false,
    chooseAddEditIngredientModalVisibility: false,
    chooseAddEditRecipeModalVisibility: false,
    chooseRecipePreviewModalVisibility: false,
    chooseShoppingListPreviewModalVisibility: false,
    chooseAddEditShoppingListModalVisibility: false,
    chooseDateModalVisibility: false,
  });

  const chooseAddUnitModal = computed(() => state.chooseAddUnitModalVisibility);

  const chooseEditUnitModal = computed(
    () => state.chooseEditUnitModalVisibility
  );

  const chooseAddEditIngredientModal = computed(
    () => state.chooseAddEditIngredientModalVisibility
  );

  const chooseAddEditRecipeModal = computed(
    () => state.chooseAddEditRecipeModalVisibility
  );

  const chooseRecipePreviewModal = computed(
    () => state.chooseRecipePreviewModalVisibility
  );

  const chooseShoppingListPreviewModal = computed(
    () => state.chooseShoppingListPreviewModalVisibility
  );

  const chooseAddEditShoppingListModalModal = computed(
    () => state.chooseAddEditShoppingListModalVisibility
  );

  const chooseDateModal = computed(() => state.chooseDateModalVisibility);

  function changePages(page: CurrentPage, subpage?: CurrentSubPage): void {
    state.currentPage = page;
    state.currentSubpage = subpage;
  }

  function toggleChooseAddUnitModal(): void {
    state.chooseAddUnitModalVisibility = !state.chooseAddUnitModalVisibility;
  }

  function toggleChooseEditUnitModal(): void {
    state.chooseEditUnitModalVisibility = !state.chooseEditUnitModalVisibility;
  }

  function toggleChooseAddEditIngredientModal(): void {
    state.chooseAddEditIngredientModalVisibility =
      !state.chooseAddEditIngredientModalVisibility;
  }

  function toggleChooseAddEditRecipeModal(): void {
    state.chooseAddEditRecipeModalVisibility =
      !state.chooseAddEditRecipeModalVisibility;
  }

  function toggleChooseRecipePreviewModal(): void {
    state.chooseRecipePreviewModalVisibility =
      !state.chooseRecipePreviewModalVisibility;
  }

  function toggleChooseShoppingListPreviewModal(): void {
    state.chooseShoppingListPreviewModalVisibility =
      !state.chooseShoppingListPreviewModalVisibility;
  }

  function toggleChooseAddEditShoppingListModal(): void {
    state.chooseAddEditShoppingListModalVisibility =
      !state.chooseAddEditShoppingListModalVisibility;
  }

  function toggleChooseDateModal(): void {
    state.chooseDateModalVisibility = !state.chooseDateModalVisibility;
  }
  return {
    state,
    chooseAddUnitModal,
    chooseEditUnitModal,
    chooseAddEditIngredientModal,
    chooseAddEditRecipeModal,
    chooseRecipePreviewModal,
    chooseShoppingListPreviewModal,
    chooseAddEditShoppingListModalModal,
    chooseDateModal,
    changePages,
    toggleChooseAddUnitModal,
    toggleChooseEditUnitModal,
    toggleChooseAddEditIngredientModal,
    toggleChooseAddEditRecipeModal,
    toggleChooseRecipePreviewModal,
    toggleChooseShoppingListPreviewModal,
    toggleChooseAddEditShoppingListModal,
    toggleChooseDateModal,
  };
});

export default useAppStore;
