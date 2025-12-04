import type { BatchDeleteDto } from "../../domain/models/batchDeleteDto";
import type { GetUnitDto } from "../../domain/models/getUnitDto";
import type { NewEditUnitDto } from "../../domain/models/newEditUnitDto";
import BaseService from "./baseService";

class UnitService extends BaseService {
  constructor() {
    super("api/unit");
  }

  public async getAllUnits(): Promise<Array<GetUnitDto>> {
    let allUnits = await this.get<Array<GetUnitDto>>("all");

    return allUnits;
  }

  public async createUnit(newUnit: NewEditUnitDto): Promise<GetUnitDto> {
    let addedUnit = await this.post<NewEditUnitDto, GetUnitDto>("", newUnit);

    return addedUnit;
  }

  public async editUnit(
    unitId: string,
    editedUnit: NewEditUnitDto
  ): Promise<void> {
    await this.put<NewEditUnitDto, void>(`${unitId}`, editedUnit);
  }

  public async deleteUnit(unitId: string): Promise<void> {
    await this.delete<void>(`${unitId}`);
  }

  public async deleteBatchUnits(unitsToDelete: BatchDeleteDto): Promise<void> {
    await this.post<BatchDeleteDto, void>("delete-multiple", unitsToDelete);
  }
}

const unitService = new UnitService();

export default unitService;
