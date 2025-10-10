import type { AuthRequest } from "../../domain/models/authRequest";
import BaseService from "./baseService";

// call backend endpoints here

class UserService extends BaseService {
  constructor() {
    super("api/user");
  }

  public async registerUser(authRequest: AuthRequest): Promise<void> {
    await this.post<AuthRequest, void>("auth/register", authRequest);
  }
}

const userService = new UserService();

export default userService;
