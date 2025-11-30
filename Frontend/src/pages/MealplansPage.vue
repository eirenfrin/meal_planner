<template>
  <UpperNavBar>
    <template #upperNavContent>
      <MealplansUpperNavContent />
    </template>
  </UpperNavBar>
  <MealplanOverviewList />
</template>

<script setup lang="ts">
import UpperNavBar from "../components/generic/UpperNavBar.vue";
import MealplansUpperNavContent from "../components/generic/MealplansUpperNavContent.vue";
import MealplanOverviewList from "../components/mealplans/MealplanOverviewList.vue";
</script>
