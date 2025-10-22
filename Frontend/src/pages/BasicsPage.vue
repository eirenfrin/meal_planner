<template>
  <UpperNavBar>
    <template #upperNavContent>
      <BasicsUpperNavContent />
    </template>
  </UpperNavBar>
  <RouterView />
</template>

<script setup lang="ts">
import UpperNavBar from "../components/generic/UpperNavBar.vue";
import BasicsUpperNavContent from "../components/generic/BasicsUpperNavContent.vue";
</script>
