import type { AuthStatus } from "../enums/authStatus";
import type { AppError } from "../models/appError";
import type { User } from "../models/user";

export interface AuthStoreState {
  currentUser: User | null;
  accessToken: string | null;
  status: AuthStatus;
  errors: AppError[];
}
