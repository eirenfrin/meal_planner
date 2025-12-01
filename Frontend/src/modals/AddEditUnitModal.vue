<template>
  <div class="modal-overlay">
    <form class="modal modal-small">
      <header>
        <div class="modal-info">
          <h1>Add unit</h1>
        </div>
        <div class="two-button-group">
          <button class="btn-1" @click.prevent>Save</button>
          <button class="btn-2" @click.prevent="close">Cancel</button>
        </div>
      </header>
      <article>
        <input type="text" placeholder="Enter unit title" v-model="unitTitleInput"></input>
      </article>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import useAppStore from '../stores/applicationStore';

// const props = defineProps<{
//   actionMessage: string
// }>()
// const emits = defineEmits(["close"]);

const unitTitleInput = ref<string>();
const appStore = useAppStore();

function close() {
  appStore.toggleChooseAddEditUnitModal();
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
