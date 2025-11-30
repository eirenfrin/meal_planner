<template>
  <article class="fancy-list-item">
    <div class="fancy-list-entry-checkbox-title">
      <input
        class="checkbox-restyle"
        v-if="editingMode"
        type="checkbox"
        @change="onToggle"
        @click.stop
      />
      <h1 class="fancy-list-entry-title">{{ mealplan.title }}</h1>
    </div>
    <span class="list-entry-date">{{ mealplan.plannedStartDate }}</span>
  </article>
</template>

<script setup lang="ts">
import type { MealplanDto } from "../../domain/models/testModels/MealplanDto";

const props = defineProps<{
  mealplan: MealplanDto;
  editingMode: boolean;
}>();

let emit = defineEmits(["toggleEntry"]);

function onToggle(): void {
  emit("toggleEntry", props.mealplan.id);
}
</script>
