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
      <h1 class="fancy-list-entry-title">{{ shoppingList.title }}</h1>
    </div>
    <span class="list-entry-date">{{ shoppingList.plannedStartDate }}</span>
    <span class="list-entry-default">{{
      shoppingList.isDefault ? "default" : "custom"
    }}</span>
  </article>
</template>

<script setup lang="ts">
import type { ShoppingListDto } from "../../domain/models/testModels/ShoppingListDto";

const props = defineProps<{
  shoppingList: ShoppingListDto;
  editingMode: boolean;
}>();

let emit = defineEmits(["toggleEntry"]);

function onToggle(): void {
  emit("toggleEntry", props.shoppingList.id);
}
</script>

<style scoped>
.list-entry-default {
  font-style: italic;
}
</style>
