import type { GetUnitDto } from "../models/getUnitDto";
import type { NewEditUnitDto } from "../models/newEditUnitDto";

export interface UnitStoreState {
  units: Array<GetUnitDto>;
  editUnitInfo: GetUnitDto | null;
}
