<template>
    <div class="modal-overlay">
    <form class="modal">
      <header>
        <div class="modal-info">
          <h1>Add ingredient</h1>
        </div>
        <div class="two-button-group">
          <button class="btn-1" @click.prevent>Save</button>
          <button class="btn-2" @click.prevent="close">Cancel</button>
        </div>
      </header>
      <article>
        <input type="text" placeholder="Enter unit title"></input>
      </article>
    </form>
  </div>
</template>



<script setup lang="ts">
import useAppStore from '../stores/applicationStore';

const appStore = useAppStore();

function close(): void {
    appStore.toggleChooseAddEditIngredientModal();
}
</script>

<style scoped>
header {
  display: flex;
  flex-direction: row;
  align-items: flex-start;
  justify-content: space-between;
}

.btn-1, .btn-2 {
  border-color: white;
}

h1 {
  margin-bottom: 1rem;
}
</style>