<template>
  <UpperNavBar>
    <template #upperNavContent>
      <MealplansUpperNavContent />
    </template>
  </UpperNavBar>
</template>

<script setup lang="ts">
import UpperNavBar from "../components/generic/UpperNavBar.vue";
import MealplansUpperNavContent from "../components/generic/MealplansUpperNavContent.vue";
</script>
