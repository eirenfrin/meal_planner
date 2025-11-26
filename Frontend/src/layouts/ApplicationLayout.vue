<template>
  <RouterView />
  <LowNavBar />
  <teleport to="#modal-container"
    ><AddEditUnitModal
      v-show="appStore.chooseAddEditUnitModal"
    ></AddEditUnitModal
  ></teleport>
  <teleport to="#modal-container">
    <AddEditIngredientModal
      v-show="appStore.chooseAddEditIngredientModal"
    ></AddEditIngredientModal>
  </teleport>
  <teleport to="#modal-container">
    <AddEditRecipeModal
      v-show="appStore.chooseAddEditRecipeModal"
    ></AddEditRecipeModal>
  </teleport>
  <teleport to="#modal-container">
    <RecipePreviewModal
      v-show="appStore.chooseRecipePreviewModal"
    ></RecipePreviewModal>
  </teleport>
</template>

<script setup lang="ts">
import AddEditIngredientModal from "../modals/AddEditIngredientModal.vue";
import AddEditRecipeModal from "../modals/AddEditRecipeModal.vue";
import AddEditUnitModal from "../modals/AddEditUnitModal.vue";
import LowNavBar from "../components/generic/LowNavBar.vue";
import useAppStore from "../stores/applicationStore";
import RecipePreviewModal from "../modals/RecipePreviewModal.vue";

const appStore = useAppStore();
</script>
