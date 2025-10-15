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
button {
  /*position: relative;
  padding: 0.75rem 2rem;
  font-family: "Georgia", serif;
  font-size: 1rem;
  color: #fff;
  background: linear-gradient(145deg, #8b5e3c, #c99a6b);
  border: 2px solid #5a3f2b;
  border-radius: 12px;
  cursor: pointer;
  box-shadow: inset 0 2px 0 rgba(255, 255, 255, 0.3);
  transition: all 0.3s ease;  */
}

/* button::before,
button::after {
  content: "";
  position: absolute;
  width: 12px;
  height: 12px;
  border: 2px solid #5a3f2b;
}

button::before {
  top: -6px;
  left: -6px;
  border-right: none;
  border-bottom: none;
  border-radius: 4px 0 0 0;
}

button::after {
  bottom: -6px;
  right: -6px;
  border-left: none;
  border-top: none;
  border-radius: 0 0 4px 0;
} */
</style>
