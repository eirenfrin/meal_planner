import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue()],
  // server: {
  //   https: {
  //     key: "./localhost-key.pem",
  //     cert: "./localhost.pem",
  //   },
  //   port: 5173,
  // },
});
