<template>
  <article class="fancy-list-item">
    <div class="fancy-list-entry-checkbox-title">
      <input
        class="checkbox-restyle"
        v-show="editingMode"
        type="checkbox"
        @change="onToggle"
      />
      <h1 class="fancy-list-entry-title">
        {{ ingredient.title }}
        <span class="amount-info"
          >{{ ingredient.soldPackageSize }} {{ ingredient.unitId }}</span
        >
      </h1>
    </div>
    <p class="list-entry-creator">
      {{ generateIngredientCreator(ingredient.creatorId) }}
    </p>
  </article>
</template>

<script setup lang="ts">
import type { GetIngredientDto } from "../../domain/models/getIngredientDto";

const props = defineProps<{
  ingredient: GetIngredientDto;
  editingMode: boolean;
}>();

let emit = defineEmits(["toggleIngredient"]);

function onToggle(): void {
  emit("toggleIngredient", props.ingredient.id);
}

function generateIngredientCreator(creatorId: string | null): string {
  if (creatorId == "null") {
    return "predefined";
  } else {
    return "custom";
  }
}
</script>

<style scoped>
.amount-info {
  margin-left: 1.5rem;
  font-size: medium;
  vertical-align: baseline;
}

.list-entry-creator {
  font-style: italic;
}
</style>
