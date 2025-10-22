<template>
  <article>
    <div class="list-entry-checkbox-title">
      <input
        class="checkbox-restyle"
        v-show="editingMode"
        type="checkbox"
        @change="onToggle"
      />
      <h1 class="list-entry-title">{{ unit.title }}</h1>
    </div>
    <p class="list-entry-creator">{{ generateUnitCreator(unit.creatorId) }}</p>
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
  padding-left: 20px;
  font-size: medium;
  font-weight: 400;
}

.list-entry-creator {
  font-style: italic;
}
</style>
