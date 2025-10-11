export const AuthStatus = {
  INIT: "init",
  PENDING: "pending",
  SUCCESS: "success",
  FAILURE: "failure",
} as const;

export type AuthStatus = (typeof AuthStatus)[keyof typeof AuthStatus];
