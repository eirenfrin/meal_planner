export const CurrentPage = {
  LISTS: { label: "Shopping lists", path: "shopping-lists" },
  MEALPLANS: { label: "Mealplans", path: "mealplans" },
  BASICS: { label: "Basics", path: "basics" },
} as const;

export type CurrentPage = (typeof CurrentPage)[keyof typeof CurrentPage];

export const pageValues = Object.values(CurrentPage);

export function mapPage(pagePath: string): CurrentPage | undefined {
  return pageValues.find((page) => page.path == pagePath);
}
