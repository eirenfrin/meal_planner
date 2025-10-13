export const EditAction = {
  ADD: 0,
  UPDATE: 1,
  DELETE: 2,
} as const;

export type EditAction = (typeof EditAction)[keyof typeof EditAction];
