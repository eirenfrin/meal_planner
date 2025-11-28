<template>
  <UpperNavBar>
    <template #upperNavContent>
      <ShoppingListsUpperNavContent />
    </template>
  </UpperNavBar>
  <ShoppingListsOverviewList />
</template>

<script setup lang="ts">
import UpperNavBar from "../components/generic/UpperNavBar.vue";
import ShoppingListsUpperNavContent from "../components/generic/ShoppingListsUpperNavContent.vue";
import ShoppingListsOverviewList from "../components/shoppingLists/ShoppingListsOverviewList.vue";
</script>
