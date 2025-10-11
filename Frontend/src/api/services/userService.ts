import type { AccessToken } from "../../domain/models/accessToken";
import type { AuthRequest } from "../../domain/models/authRequest";
import BaseService from "./baseService";

class UserService extends BaseService {
  constructor() {
    super("api/user");
  }

  public async registerUser(authRequest: AuthRequest): Promise<void> {
    await this.post<AuthRequest, void>("auth/register", authRequest);
  }

  public async loginUser(authRequest: AuthRequest): Promise<AccessToken> {
    return await this.post<AuthRequest, AccessToken>("auth/login", authRequest);
  }

  public async refreshTokens(): Promise<AccessToken> {
    return await this.post<void, AccessToken>("auth/refresh");
  }

  public async logoutUser(): Promise<void> {
    await this.post<void, void>("logout");
  }
}

const userService = new UserService();

export default userService;
