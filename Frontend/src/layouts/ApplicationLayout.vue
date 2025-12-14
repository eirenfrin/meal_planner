<template>
  <RouterView />
  <LowNavBar />
  <teleport to="#modal-container"
    ><AddUnitModal v-if="appStore.chooseAddUnitModal"></AddUnitModal
  ></teleport>
  <teleport to="#modal-container"
    ><EditUnitModal v-if="appStore.chooseEditUnitModal"></EditUnitModal
  ></teleport>
  <teleport to="#modal-container">
    <AddIngredientModal
      v-if="appStore.chooseAddIngredientModal"
    ></AddIngredientModal>
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
import AddIngredientModal from "../modals/AddIngredientModal.vue";
import AddEditRecipeModal from "../modals/AddEditRecipeModal.vue";
import AddUnitModal from "../modals/AddUnitModal.vue";
import EditUnitModal from "../modals/EditUnitModal.vue";
import LowNavBar from "../components/generic/LowNavBar.vue";
import useAppStore from "../stores/applicationStore";
import RecipePreviewModal from "../modals/RecipePreviewModal.vue";
import ShoppingListPreviewModal from "../modals/ShoppingListPreviewModal.vue";
import AddEditShoppingListModal from "../modals/AddEditShoppingListModal.vue";
import ChooseDateModal from "../modals/ChooseDateModal.vue";

const appStore = useAppStore();
</script>
