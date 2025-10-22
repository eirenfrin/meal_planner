import type { CurrentPage } from "../enums/currentPage";
import type { CurrentSubPage } from "../enums/currentSubPage";

export interface AppStoreState {
  currentPage: CurrentPage;
  currentSubpage?: CurrentSubPage;
}
