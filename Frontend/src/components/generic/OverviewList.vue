<template>
  <section class="overview-list-container">
    <header>
      <h1>{{ headerTitle }}</h1>
      <div v-if="!editingMode" class="recipes-actions">
        <button class="add-button">
          <span @click="addCallback" class="material-symbols-outlined">
            add_box
          </span>
        </button>
        <button @click="onChangeMode" class="edit-button">
          <span class="material-symbols-outlined"> edit_square </span>
        </button>
      </div>
      <div v-else class="delete-actions">
        <button @click="onChangeMode" class="cancel-button">
          <span class="material-symbols-outlined"> undo </span>
        </button>
        <button @click="deleteCallback" class="delete-button">
          <span class="material-symbols-outlined"> delete </span>
        </button>
      </div>
    </header>
    <slot name="content"></slot>
  </section>
</template>

<script setup lang="ts">
const props = defineProps<{
  deleteCallback: () => Promise<void>;
  addCallback: () => Promise<void>;
  headerTitle: string;
  editingMode: boolean;
}>();

let emit = defineEmits(["changeEditMode"]);

function onChangeMode(): void {
  emit("changeEditMode", !props.editingMode);
}
</script>

<style scoped>
.overview-list-container {
  width: 80%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 1rem 2rem;
  box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.1), 0 6px 20px 0 rgba(0, 0, 0, 0.1);
}
header {
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 0;
}
button {
  font-size: medium;
  border: none;
  border-radius: 0;
  background-color: white;
  cursor: pointer;
  transition: all 0.3s ease;
  padding: 0px;
  outline: none;
}
h1 {
  margin: 0;
}
.material-symbols-outlined {
  font-size: xx-large;
}
.material-symbols-outlined:hover {
  color: blueviolet;
}
</style>
