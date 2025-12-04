<template>
  <div class="modal-overlay">
    <form class="modal modal-small">
      <header>
        <div class="modal-info">
          <h1>Edit unit</h1>
        </div>
        <div class="two-button-group">
          <button class="btn-1" @click.prevent="saveEdit">Save</button>
          <button class="btn-2" @click.prevent="close">Cancel</button>
        </div>
      </header>
      <article>
        <input type="text" v-model="editedTitle"></input>
      </article>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import useAppStore from '../stores/applicationStore';
import useUnitStore from '../stores/unitStore';

const appStore = useAppStore();
const unitStore = useUnitStore();

const editedTitle = ref<string>(unitStore.editUnitInfo!.title);

async function saveEdit(): Promise<void> {
  await unitStore.editUnit(editedTitle.value);
  appStore.toggleChooseEditUnitModal();
}

function close() {
  appStore.toggleChooseEditUnitModal();
}

</script>

<style scoped>
.btn-1, .btn-2 {
  border-color: white;
}

h1 {
  margin-bottom: 0;
}

.modal-overlay{
  z-index: 200;
}
</style>
