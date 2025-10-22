import { defineStore } from "pinia";
import { reactive } from "vue";
import type { AppStoreState } from "../domain/store-states/appStoreState";
import { CurrentPage } from "../domain/enums/currentPage";
import { CurrentSubPage } from "../domain/enums/currentSubPage";

const useAppStore = defineStore("applicationStore", () => {
  const state: AppStoreState = reactive({
    currentPage: CurrentPage.BASICS,
    currentSubpage: CurrentSubPage.RECIPES,
  });

  function changePages(page: CurrentPage, subpage?: CurrentSubPage): void {
    state.currentPage = page;
    state.currentSubpage = subpage;
  }

  return { state, changePages };
});

export default useAppStore;
