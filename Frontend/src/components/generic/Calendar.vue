<template>
  <div class="calendar-container">
    <header class="two-buttons-middle-text">
      <button class="btn-left" @click="goToPreviousMonth">Previous</button>
      <h2 class="text">
        {{
          displayedMonth.toLocaleString("en-US", { month: "short" }) +
          " " +
          displayedMonth.getFullYear()
        }}
      </h2>
      <button class="btn-right" @click="goToNextMonth">Next</button>
    </header>
    <div class="table-container">
      <table class="calendar-days-grid">
        <thead>
          <tr>
            <th v-for="weekday in daysOfWeekTitles">{{ weekday }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="weekIndex in weeksToDisplay">
            <td
              v-for="day in allDaysOfMonth.slice(
                weekIndex * 7,
                weekIndex * 7 + 7
              )"
              @click="chooseDate(day)"
              :class="{
                selected:
                  day &&
                  allSelectedDates.find(
                    (selectedDate) =>
                      selectedDate.getFullYear() ==
                        displayedMonth.getFullYear() &&
                      selectedDate.getMonth() == displayedMonth.getMonth() &&
                      selectedDate.getDate() == day
                  ),
              }"
            >
              {{ day ? day : "" }}
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref } from "vue";

const displayedMonth = ref<Date>(new Date());
const selectedStartDay = ref<number>();
const allSelectedDates = ref<Array<Date>>([]);
const daysOfWeekTitles: Array<string> = [
  "Mon",
  "Tue",
  "Wed",
  "Thu",
  "Fri",
  "Sat",
  "Sun",
];

const weeksToDisplay = computed(() => {
  return Array.from(
    { length: Math.ceil(allDaysOfMonth.value.length / 7) },
    (_, i) => i
  );
});

// TODO simplify this
function computeAllSelectedDates(startDay: number) {
  allSelectedDates.value = [];

  let startYear: number = displayedMonth.value.getFullYear();
  let startMonth: number = displayedMonth.value.getMonth();

  let interval: number = 40;

  let startDate: Date = new Date(startYear, startMonth, startDay);
  let finalDate: Date = new Date(startDate);
  finalDate.setDate(startDate.getDate() + interval);
  console.log(finalDate);

  let currentDate: Date = startDate;
  while (currentDate < finalDate) {
    allSelectedDates.value.push(new Date(currentDate));
    currentDate.setDate(currentDate.getDate() + 1);
  }
  console.log(allSelectedDates.value);
}

const allDaysOfMonth = computed(() => {
  const year: number = displayedMonth.value.getFullYear();
  const month: number = displayedMonth.value.getMonth();

  const firstDateOfMonth: Date = new Date(year, month, 1);
  const lastDateOfMonth: Date = new Date(year, month + 1, 0);

  const firstDayWeekdayIndex: number = firstDateOfMonth.getDay();

  const totalDaysInMonth: number = lastDateOfMonth.getDate();

  let allDays: Array<number | null> = [];

  for (
    let weekdayBeforeMonth = 0;
    weekdayBeforeMonth < firstDayWeekdayIndex;
    weekdayBeforeMonth++
  ) {
    allDays.push(null);
  }

  for (let dayOfMonth = 1; dayOfMonth <= totalDaysInMonth; dayOfMonth++) {
    allDays.push(dayOfMonth);
  }

  return allDays;
});

function goToPreviousMonth() {
  displayedMonth.value = new Date(
    displayedMonth.value.getFullYear(),
    displayedMonth.value.getMonth() - 1,
    1
  );
  console.log(weeksToDisplay.value);
}

function goToNextMonth() {
  displayedMonth.value = new Date(
    displayedMonth.value.getFullYear(),
    displayedMonth.value.getMonth() + 1,
    1
  );
  console.log(allDaysOfMonth.value);
}

function chooseDate(dayInMonth: number | null) {
  if (dayInMonth) {
    selectedStartDay.value = dayInMonth;
    computeAllSelectedDates(dayInMonth);
  }
}
</script>

<style scoped>
.table-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
.calendar-days-grid {
  width: 60%;
  table-layout: fixed;
}
th,
td {
  text-align: center;
  height: 1.2rem;
}
td:hover {
  cursor: pointer;
  background-color: beige;
  border-radius: 4px;
}
.weekdays-header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
.selected {
  background-color: blanchedalmond;
  border-radius: 4px;
}

.selected:hover {
  background-color: blanchedalmond;
  border-radius: 4px;
}
</style>
