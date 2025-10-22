import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import { createPinia } from "pinia";
import router from "./router";
import { mapPage } from "./domain/enums/currentPage";
import { mapSubPage } from "./domain/enums/currentSubPage";
import useAppStore from "./stores/applicationStore";

const app = createApp(App);
const pinia = createPinia();

app.use(pinia);
app.use(router);

router.afterEach((to) => {
  if (!to.path.startsWith("/app/")) {
    return;
  }

  const [_1, _2, pagePath, subPagePath] = to.path.split("/");

  if (!pagePath) {
    return;
  }

  const page = mapPage(pagePath);
  const subPage = mapSubPage(subPagePath);

  if (!page) {
    return;
  }

  const appStore = useAppStore(pinia);

  appStore.changePages(page, subPage);
});

app.mount("#app");
