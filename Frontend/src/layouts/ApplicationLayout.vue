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
    <AddEditRecipeForm
      v-show="appStore.chooseAddEditRecipeModal"
    ></AddEditRecipeForm>
  </teleport>
</template>

<script setup lang="ts">
import AddEditIngredientModal from "../modals/AddEditIngredientModal.vue";
import AddEditRecipeForm from "../modals/AddEditRecipeModal.vue";
import AddEditUnitModal from "../modals/AddEditUnitModal.vue";
import LowNavBar from "../components/generic/LowNavBar.vue";
import useAppStore from "../stores/applicationStore";

const appStore = useAppStore();
</script>
