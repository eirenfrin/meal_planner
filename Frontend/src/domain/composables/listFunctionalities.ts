import { ref } from "vue";

export function useListFunctionalities() {
  const editingMode = ref(false);
  let listOfIdsToDelete = ref<Array<string>>([]);

  function editModeCallback(mode: boolean): void {
    if (mode) {
      listOfIdsToDelete.value = [];
    }

    editingMode.value = mode;
  }

  function toggleCallback(id: string): void {
    if (listOfIdsToDelete.value.includes(id)) {
      listOfIdsToDelete.value.splice(listOfIdsToDelete.value.indexOf(id), 1);
    } else {
      listOfIdsToDelete.value.push(id);
    }
  }

  return { editingMode, listOfIdsToDelete, editModeCallback, toggleCallback };
}
