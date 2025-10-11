import { jwtDecode } from "jwt-decode";
import type { AccessToken } from "./accessToken";

export interface User {
  id: string;
  name: string;
  mealPrepInterval: number;
}

export function decodeUserFromJWT(accessToken: AccessToken): User {
  let decodedPayload = jwtDecode<Record<string, any>>(accessToken.token);

  return {
    id: decodedPayload.sub,
    name: decodedPayload.name,
    mealPrepInterval: decodedPayload.mpi,
  };
}
