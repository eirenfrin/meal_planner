<template>
  <article class="fancy-list-item">
    <div class="fancy-list-entry-checkbox-title">
      <input
        class="checkbox-restyle"
        v-show="editingMode"
        type="checkbox"
        @change="onToggle"
      />
      <h1 class="fancy-list-entry-title">{{ unit.title }}</h1>
    </div>
    <div class="list-entry-creator">
      {{ generateUnitCreator(unit.creatorId) }}
    </div>
  </article>
</template>

<script setup lang="ts">
import type { GetUnitDto } from "../../domain/models/getUnitDto";

const props = defineProps<{
  unit: GetUnitDto;
  editingMode: boolean;
}>();

let emit = defineEmits(["toggleUnit"]);

function onToggle(): void {
  emit("toggleUnit", props.unit.id);
}

function generateUnitCreator(creatorId: string | null): string {
  if (creatorId == "null") {
    return "predefined";
  } else {
    return "custom";
  }
}
</script>

<style scoped>
.list-entry-creator {
  font-style: italic;
}
</style>
