<template>
  <nav>
    <slot name="upperNavContent"></slot>
    <div class="settings">
      <span class="material-icons">settings</span>
      <span class="icon-settings-label">rodinkina-kuchyna</span>
    </div>
  </nav>
</template>

<script setup lang="ts"></script>

<style scoped>
nav {
  width: 100%;
  background-color: #fdf6e3;
  position: fixed;
  top: 0;
  padding: 20px 0px;
  display: flex;
  align-items: center;
  box-shadow: 0 4px 12px 0 rgba(0, 0, 0, 0.1);
}
.settings {
  display: inline-flex;
  position: absolute;
  align-items: center;
  justify-content: center;
  right: 20px;
  overflow: hidden;
  cursor: pointer;
  transition: all 0.3s ease;
}
.settings .material-icons {
  background: white;
  padding: 0.5rem;
  margin-right: 0.5rem;
  border-radius: 100%;
  font-size: 24px;
  transition: transform 0.3s ease;
}

.settings .icon-settings-label {
  max-width: 0;
  opacity: 0;
  white-space: nowrap;
  overflow: hidden;
  transition: max-width 0.4s ease, opacity 0.3s ease;
}

.settings:hover .icon-settings-label {
  max-width: 7rem;
  opacity: 1;
  text-overflow: ellipsis;
}
</style>
