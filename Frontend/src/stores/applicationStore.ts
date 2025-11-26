import { defineStore } from "pinia";
import { computed, reactive } from "vue";
import type { AppStoreState } from "../domain/store-states/appStoreState";
import { CurrentPage } from "../domain/enums/currentPage";
import { CurrentSubPage } from "../domain/enums/currentSubPage";

const useAppStore = defineStore("applicationStore", () => {
  const state: AppStoreState = reactive({
    currentPage: CurrentPage.BASICS,
    currentSubpage: CurrentSubPage.RECIPES,
    chooseAddEditUnitModalVisibility: false,
    chooseAddEditIngredientModalVisibility: false,
    chooseAddEditRecipeModalVisibility: false,
    chooseRecipePreviewModalVisibility: false,
  });

  const chooseAddEditUnitModal = computed(
    () => state.chooseAddEditUnitModalVisibility
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

  function changePages(page: CurrentPage, subpage?: CurrentSubPage): void {
    state.currentPage = page;
    state.currentSubpage = subpage;
  }

  function toggleChooseAddEditUnitModal(): void {
    state.chooseAddEditUnitModalVisibility =
      !state.chooseAddEditUnitModalVisibility;
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

  return {
    state,
    chooseAddEditUnitModal,
    chooseAddEditIngredientModal,
    chooseAddEditRecipeModal,
    chooseRecipePreviewModal,
    changePages,
    toggleChooseAddEditUnitModal,
    toggleChooseAddEditIngredientModal,
    toggleChooseAddEditRecipeModal,
    toggleChooseRecipePreviewModal,
  };
});

export default useAppStore;
