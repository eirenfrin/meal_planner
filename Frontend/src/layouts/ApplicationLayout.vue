<template>
  <RouterView />
  <LowNavBar />
  <teleport to="#modal-container"
    ><AddEditUnitModal v-if="appStore.chooseAddEditUnitModal"></AddEditUnitModal
  ></teleport>
  <teleport to="#modal-container">
    <AddEditIngredientModal
      v-if="appStore.chooseAddEditIngredientModal"
    ></AddEditIngredientModal>
  </teleport>
  <teleport to="#modal-container">
    <AddEditRecipeModal
      v-if="appStore.chooseAddEditRecipeModal"
    ></AddEditRecipeModal>
  </teleport>
  <teleport to="#modal-container">
    <RecipePreviewModal
      v-if="appStore.chooseRecipePreviewModal"
    ></RecipePreviewModal>
  </teleport>
  <teleport to="#modal-container">
    <ShoppingListPreviewModal
      v-if="appStore.chooseShoppingListPreviewModal"
    ></ShoppingListPreviewModal>
  </teleport>
  <teleport to="#modal-container">
    <AddEditShoppingListModal
      v-if="appStore.chooseAddEditShoppingListModalModal"
    ></AddEditShoppingListModal>
  </teleport>
  <teleport to="#modal-container">
    <ChooseDateModal v-if="appStore.chooseDateModal"
      ><template #text-date-for>
        <h3>Shopping</h3>
      </template></ChooseDateModal
    >
  </teleport>
</template>

<script setup lang="ts">
import AddEditIngredientModal from "../modals/AddEditIngredientModal.vue";
import AddEditRecipeModal from "../modals/AddEditRecipeModal.vue";
import AddEditUnitModal from "../modals/AddEditUnitModal.vue";
import LowNavBar from "../components/generic/LowNavBar.vue";
import useAppStore from "../stores/applicationStore";
import RecipePreviewModal from "../modals/RecipePreviewModal.vue";
import ShoppingListPreviewModal from "../modals/ShoppingListPreviewModal.vue";
import AddEditShoppingListModal from "../modals/AddEditShoppingListModal.vue";
import ChooseDateModal from "../modals/ChooseDateModal.vue";

const appStore = useAppStore();
</script>
