import { defineStore } from "pinia";
import { computed, reactive } from "vue";
import type { AppStoreState } from "../domain/store-states/appStoreState";
import { CurrentPage } from "../domain/enums/currentPage";
import { CurrentSubPage } from "../domain/enums/currentSubPage";

const useAppStore = defineStore("applicationStore", () => {
  const state: AppStoreState = reactive({
    currentPage: CurrentPage.BASICS,
    currentSubpage: CurrentSubPage.RECIPES,
    chooseUnitAmountModalVisibility: false,
  });

  const chooseUnitAmountModal = computed(
    () => state.chooseUnitAmountModalVisibility
  );

  function changePages(page: CurrentPage, subpage?: CurrentSubPage): void {
    state.currentPage = page;
    state.currentSubpage = subpage;
  }

  function toggleChooseUnitAmountModal(): void {
    state.chooseUnitAmountModalVisibility =
      !state.chooseUnitAmountModalVisibility;
  }

  return {
    state,
    chooseUnitAmountModal,
    changePages,
    toggleChooseUnitAmountModal,
  };
});

export default useAppStore;
