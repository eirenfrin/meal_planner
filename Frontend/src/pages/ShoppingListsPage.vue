<template>
  <UpperNavBar>
    <template #upperNavContent>
      <ShoppingListsUpperNavContent />
    </template>
  </UpperNavBar>
</template>

<script setup lang="ts">
import UpperNavBar from "../components/generic/UpperNavBar.vue";
import ShoppingListsUpperNavContent from "../components/generic/ShoppingListsUpperNavContent.vue";
</script>
