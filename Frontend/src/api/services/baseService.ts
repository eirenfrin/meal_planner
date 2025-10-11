import api from "../axios";

class BaseService {
  protected serviceUrl: string;

  constructor(url: string) {
    this.serviceUrl = url;
  }

  public async get<ResPayload>(endpointUrl: string): Promise<ResPayload> {
    let response = await api.get<ResPayload>(
      `${this.serviceUrl}/${endpointUrl}`
    );

    return response.data;
  }

  public async post<ReqPayload, ResPayload>(
    endpointUrl: string,
    payload: ReqPayload | void
  ): Promise<ResPayload> {
    let response = await api.post<ResPayload>(
      `${this.serviceUrl}/${endpointUrl}`,
      payload
    );

    return response.data;
  }

  public async put<ReqPayload, ResPayload>(
    endpointUrl: string,
    payload: ReqPayload
  ): Promise<ResPayload> {
    let response = await api.put<ResPayload>(
      `${this.serviceUrl}/${endpointUrl}`,
      payload
    );

    return response.data;
  }

  public async delete<ResPayload>(endpointUrl: string): Promise<ResPayload> {
    let response = await api.delete<ResPayload>(
      `${this.serviceUrl}/${endpointUrl}`
    );

    return response.data;
  }
}

export default BaseService;
