<template>
  <nav>
    <ul>
      <li
        v-for="entry in subPageValues"
        :key="entry"
        :class="{ active: entry == currentSubPage }"
      >
        {{ entry }}
      </li>
    </ul>
    <div class="settings">
      <span class="material-icons">settings</span>
      <span class="icon-settings-label">rodinkina-kuchyna</span>
    </div>
  </nav>
</template>

<script setup lang="ts">
import {
  subPageValues,
  type CurrentSubPage,
} from "../../domain/enums/currentSubPage";

const props = defineProps<{
  currentSubPage: CurrentSubPage;
}>();
</script>

<style scoped>
nav {
  width: 100%;
  background-color: #fdf6e3;
  position: fixed;
  top: 0;
  padding: 20px 0px;
  display: flex;
  align-items: center;
  box-shadow: 0 4px 12px 0 rgba(0, 0, 0, 0.1);
}
ul {
  width: 60%;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-around;
  margin: 0 auto;
  padding: 0;
}
li {
  list-style: none;
  text-align: center;
  font-size: large;
  transition: transform 0.2s ease;
  font-weight: 500;
  cursor: pointer;
}
li:hover {
  transform: scale(1.5);
}
.active {
  font-weight: 900;
}
.settings {
  display: inline-flex;
  position: absolute;
  align-items: center;
  justify-content: center;
  right: 20px;
  overflow: hidden;
  cursor: pointer;
  transition: all 0.3s ease;
}
.settings .material-icons {
  background: white;
  padding: 0.5rem;
  margin-right: 0.5rem;
  border-radius: 100%;
  font-size: 24px;
  transition: transform 0.3s ease;
}

.settings .icon-settings-label {
  max-width: 0;
  opacity: 0;
  white-space: nowrap;
  overflow: hidden;
  transition: max-width 0.4s ease, opacity 0.3s ease;
}

.settings:hover .icon-settings-label {
  max-width: 7rem;
  opacity: 1;
  text-overflow: ellipsis;
}
</style>
