<template>
  <section class="overview-list-container scroll-list-container">
    <header>
      <h1>{{ headerTitle }}</h1>
      <div v-if="!editingMode" class="two-button-group">
        <button @click.prevent="addCallback" class="btn-1">Add new</button>
        <button @click.prevent="onChangeMode" class="btn-2">Edit list</button>
      </div>
      <div v-else class="two-button-group">
        <button @click.prevent="onChangeMode" class="btn-1">Undo</button>
        <button @click.prevent="deleteCallback" class="btn-2">
          Delete selected
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
  height: 70vh;
}

header {
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 0;
}

.btn-1,
.btn-2 {
  border-color: white;
}

h1 {
  margin: 0;
}
</style>
