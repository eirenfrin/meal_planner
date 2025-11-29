export const CalendarMode = {
  INTERVAL: 0,
  DAY: 1,
};

export type CalendarMode = (typeof CalendarMode)[keyof typeof CalendarMode];
