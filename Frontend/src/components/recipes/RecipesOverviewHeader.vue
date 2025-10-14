<template>
  <header>
    <h1>My cookbook</h1>
    <div v-show="!editingMode" class="recipes-actions">
      <button>Add new</button>
      <button @click="onChangeMode">Edit</button>
    </div>
    <div v-show="editingMode" class="delete-actions">
      <button @click="onChangeMode">Cancel</button>
      <button>Delete</button>
    </div>
  </header>
</template>

<script setup lang="ts">
const props = defineProps<{
  editingMode: boolean;
}>();

let emit = defineEmits(["changeEditMode"]);

function onChangeMode(): void {
  emit("changeEditMode", !props.editingMode);
}
</script>

<style scoped>
header {
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}
</style>
