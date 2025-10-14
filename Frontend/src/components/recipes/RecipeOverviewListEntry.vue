<template>
  <article>
    <div class="list-entry-checkbox-title">
      <input
        class="checkbox-restyle"
        v-show="editingMode"
        type="checkbox"
        @change="onToggle"
      />
      <h1 class="list-entry-title">{{ recipe.title }}</h1>
    </div>
    <p class="list-entry-date">{{ recipe.lastCooked }}</p>
  </article>
</template>

<script setup lang="ts">
import type { GetRecipeBasicInfoDto } from "../../domain/models/getRecipeBasicInfoDto";

const props = defineProps<{
  recipe: GetRecipeBasicInfoDto;
  editingMode: boolean;
}>();

let emit = defineEmits(["toggleRecipe"]);

function onToggle(): void {
  emit("toggleRecipe", props.recipe.id);
}
</script>

<style scoped>
article {
  padding: 10px 20px;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  border: 2px solid #00ff51;
}

.list-entry-checkbox-title {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.list-entry-title {
  padding-left: 20px;
  font-size: medium;
  font-weight: 400;
}

.checkbox-restyle {
  appearance: none;
  -webkit-appearance: none;
  width: 20px;
  height: 20px;
  border: 2px solid #00ff51;
  border-radius: 4px;
  display: inline-block;
  vertical-align: middle;
  cursor: pointer;
  position: relative;
  transition: all 0.15s;
}

.checkbox-restyle:checked {
  background-color: #1f823e;
  border-color: #1f823e;
}

.checkbox-restyle:checked::after {
  content: "";
  position: absolute;
  left: 5px;
  top: 1px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 2px 2px 0;
  transform: rotate(45deg);
}
</style>
