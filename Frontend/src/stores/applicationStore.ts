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
    chooseAddIngredientModalVisibility: false,
    chooseEditIngredientModalVisibility: false,

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

  const chooseAddIngredientModal = computed(
    () => state.chooseAddIngredientModalVisibility
  );

  const chooseEditIngredientModal = computed(
    () => state.chooseEditIngredientModalVisibility
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

  function toggleChooseAddIngredientModal(): void {
    console.log("toogle");
    state.chooseAddIngredientModalVisibility =
      !state.chooseAddIngredientModalVisibility;
  }

  function toggleChooseEditIngredientModal(): void {
    state.chooseEditIngredientModalVisibility =
      !state.chooseEditIngredientModalVisibility;
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
    chooseAddIngredientModal,
    chooseEditIngredientModal,

    chooseAddEditRecipeModal,
    chooseRecipePreviewModal,
    chooseShoppingListPreviewModal,
    chooseAddEditShoppingListModalModal,
    chooseDateModal,
    changePages,
    toggleChooseAddUnitModal,
    toggleChooseEditUnitModal,
    toggleChooseAddIngredientModal,
    toggleChooseEditIngredientModal,

    toggleChooseAddEditRecipeModal,
    toggleChooseRecipePreviewModal,
    toggleChooseShoppingListPreviewModal,
    toggleChooseAddEditShoppingListModal,
    toggleChooseDateModal,
  };
});

export default useAppStore;
