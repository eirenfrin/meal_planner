<template>
  <article>
    <div class="list-entry-checkbox-title">
      <input
        class="checkbox-restyle"
        v-show="editingMode"
        type="checkbox"
        @change="onToggle"
      />
      <h1 class="list-entry-title">
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
article {
  padding: 10px 20px;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  /* border: 2px solid #00ff51; */
  border-left: 3px solid #3e1c00;
  border-right: 3px solid #3e1c00;
  border-radius: 6px;
  background: #fdf6e3;
  font-family: "Georgia", serif;
}

.list-entry-checkbox-title {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.list-entry-title {
  padding-left: 1rem;
  font-size: medium;
  font-weight: 400;
}

.amount-info {
  margin-left: 1.5rem;
  font-size: small;
  vertical-align: baseline;
}

.list-entry-creator {
  font-style: italic;
}
</style>
