<template>
  <div class="modal-overlay">
    <form class="modal">
      <header>
        <div class="modal-info">
            <h2>Add new unit</h2>
          <slot name="text-header"></slot>
        </div>
        <div class="two-button-group">
          <button class="btn-1">Save</button>
          <button class="btn-2" @click="close">Cancel</button>
        </div>
      </header>
      <article class="item">
        <input type="text" placeholder="Enter unit title"></input>
      </article>
    </form>
  </div>
</template>

<script setup lang="ts">
const emits = defineEmits(["close"]);

function close() {
    emits("close");
}

</script>

<style scoped></style>
