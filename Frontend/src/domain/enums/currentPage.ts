export const CurrentPage = {
  LISTS: "Shopping lists",
  MEALPLANS: "Mealplans",
  BASICS: "Basics",
} as const;

export type CurrentPage = (typeof CurrentPage)[keyof typeof CurrentPage];

export const pageValues = Object.values(CurrentPage);
