import { createRouter, createWebHistory } from "vue-router";
import type { RouteRecordRaw } from "vue-router";

const routes: RouteRecordRaw[] = [
  {
    path: "/app",
    name: "App",
    meta: { requiresAuth: true },
    component: () => import("../layouts/ApplicationLayout.vue"),
    children: [
      {
        path: "",
        redirect: { name: "Recipes" },
      },
      {
        path: "basics",
        name: "Basics",
        meta: { requiresAuth: true },
        component: () => import("../pages/BasicsPage.vue"),
        children: [
          {
            path: "",
            redirect: { name: "Recipes" },
          },
          {
            path: "recipes",
            name: "Recipes",
            meta: { requiresAuth: true },
            component: () => import("../pages/basics/RecipeSubpage.vue"),
          },
          {
            path: "units",
            name: "Units",
            meta: { requiresAuth: true },
            component: () => import("../pages/basics/UnitSubpage.vue"),
          },
          {
            path: "ingredients",
            name: "Ingredients",
            meta: { requiresAuth: true },
            component: () => import("../pages/basics/IngredientSubpage.vue"),
          },
        ],
      },
      {
        path: "mealplans",
        name: "Mealplans",
        meta: { requiresAuth: true },
        component: () => import("../pages/MealplansPage.vue"),
      },
      {
        path: "shopping-lists",
        name: "ShoppingLists",
        meta: { requiresAuth: true },
        component: () => import("../pages/ShoppingListsPage.vue"),
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(), // uses HTML5 history mode
  routes,
});

export default router;
