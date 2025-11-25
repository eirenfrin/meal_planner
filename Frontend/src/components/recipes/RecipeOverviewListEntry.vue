<template>
  <article class="fancy-list-item">
    <div class="fancy-list-entry-checkbox-title">
      <input
        class="checkbox-restyle"
        v-show="editingMode"
        type="checkbox"
        @change="onToggle"
      />
      <h1 class="fancy-list-entry-title">{{ recipe.title }}</h1>
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

<style scoped></style>
