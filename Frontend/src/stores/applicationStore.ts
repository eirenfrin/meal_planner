import { defineStore } from "pinia";
import { ref, computed } from "vue";

const useAppStore = defineStore("applicationStore", () => {
  // reactive data (if value of count changes, it will get updated wherever it is referred)
  const count = ref(0);

  // getter (automatically recomputes when its underlying data change, otherwise is cached)
  const getFormattedCount = computed(() => `Count is ${count.value}`);

  // action (function call (can be sync and async), calls are not cached)
  function increment() {
    count.value++;
  }

  return { count, getFormattedCount, increment };
});

export default useAppStore;
