import { createRouter, createWebHistory } from "vue-router";
import type { RouteRecordRaw } from "vue-router";

const routes: RouteRecordRaw[] = [
  //   {
  //     path: "/app",
  //     name: "App",
  //     meta: { requiresAuth: true },
  //     component: () => import("layouts/ApplicationLayout.vue"),
  //     children: [
  //       {
  //         path: "",
  //         name: "Index",
  //         meta: { requiresAuth: true },
  //         component: () => import("pages/IndexPage.vue"),
  //       },
  //       {
  //         path: "profile",
  //         name: "Profile",
  //         meta: { requiresAuth: true },
  //         component: () => import("pages/ProfilePage.vue"),
  //       },
  //       {
  //         path: "settings",
  //         name: "Settings",
  //         meta: { requiresAuth: true },
  //         component: () => import("pages/SettingsPage.vue"),
  //       },
  //     ],
  //   },
];

const router = createRouter({
  history: createWebHistory(), // uses HTML5 history mode
  routes,
});

export default router;
