export const CurrentSubPage = {
  RECIPES: "Recipes",
  INGREDIENTS: "Ingredients",
  UNITS: "Units",
} as const;

export type CurrentSubPage =
  (typeof CurrentSubPage)[keyof typeof CurrentSubPage];

export const subPageValues = Object.values(CurrentSubPage);
