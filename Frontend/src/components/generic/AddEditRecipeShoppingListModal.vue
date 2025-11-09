<template>
  <form>
    <header>
        <input type="text"
        id="username"
        placeholder="Title"
        required>
        </input>
      <div class="modal-buttons">
        <button>save</button>
        <button>cancel</button>
      </div>
    </header>
    <div class="ingredients-list">
      <ul class="list">
        <li
          class="list-entry"
          v-for="ingredient in ingredients"
          :key="ingredient.id"
        >
        {{ ingredient.title }}
        </li>
      </ul>
    </div>
</form>
</template>

<script setup lang="ts">
import type { GetIngredientDto } from '../../domain/models/getIngredientDto';

let ingredients: Array<GetIngredientDto> = 
    [
        {
    id: "123456",
    title: "Vanilka",
    soldPackageSize: 3,
    unitId: "pack",
    creatorId: "null",
  },
  {
    id: "123455",
    title: "Bravcove pliecko",
    soldPackageSize: 1,
    unitId: "kg",
    creatorId: "1111",
  },
    ]
</script>

<style scoped></style>
