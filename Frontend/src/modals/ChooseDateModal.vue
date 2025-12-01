<template>
<div class="modal-overlay">
    <div class="modal modal-big">
        <header>
            <div class="modal-info">
                <h2>Choose date for:</h2>
                <slot name="text-date-for"></slot>
            </div>
            <div class="two-button-group">
                <button class="btn-1" @click.prevent>Save</button>
                <button class="btn-2" @click.prevent="close">Cancel</button>
            </div>
        </header>
        <div class="input-button-group">
            <input class="input" 
            type="text"
            id="username"
            placeholder="Enter Date">
            </input>
            <button
            v-if="!shoppingDuringInterval"
            class="btn"
            @click.prevent="toggleShoppingInterval"
            >
            Shop during an interval
            </button>
            <button
            v-if="shoppingDuringInterval"
            class="btn"
            @click.prevent="toggleShoppingInterval"
            >
            Shop on a specific day
            </button>
        </div>
        <Calendar></Calendar>
    </div>
</div>
</template>


<script setup lang="ts">
import { ref } from 'vue';
import useAppStore from '../stores/applicationStore';
import Calendar from '../components/generic/Calendar.vue';

const shoppingDuringInterval = ref<boolean>(true);
const appStore = useAppStore();

function toggleShoppingInterval() {
    shoppingDuringInterval.value = !shoppingDuringInterval.value;
}


function close() {
    appStore.toggleChooseDateModal();
}
</script>

<style scoped>
.two-button-group .btn-1, .two-button-group .btn-2 {
    border-color: white;
}
</style>