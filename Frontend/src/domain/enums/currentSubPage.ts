export const CurrentSubPage = {
  RECIPES: { label: "Recipes", path: "recipes" },
  INGREDIENTS: { label: "Ingredients", path: "ingredients" },
  UNITS: { label: "Units", path: "units" },
} as const;

export type CurrentSubPage =
  (typeof CurrentSubPage)[keyof typeof CurrentSubPage];

export const subPageValues = Object.values(CurrentSubPage);

export function mapSubPage(subPagePath?: string): CurrentSubPage | undefined {
  return subPageValues.find((subPage) => subPage.path == subPagePath);
}
