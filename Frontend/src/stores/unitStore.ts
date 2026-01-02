import { defineStore } from "pinia";
import { computed, reactive } from "vue";
import unitService from "../api/services/unitService";
import type { UnitStoreState } from "../domain/store-states/unitStoreState";
import type { NewEditUnitDto } from "../domain/models/newEditUnitDto";
import type { BatchDeleteDto } from "../domain/models/batchDeleteDto";
import type { GetUnitDto } from "../domain/models/getUnitDto";

const useUnitStore = defineStore("unitStore", () => {
  const state: UnitStoreState = reactive({
    units: [],
    editUnitInfo: null as GetUnitDto | null,
  });

  const allUnits = computed(() => state.units);

  const editUnitInfo = computed(() => state.editUnitInfo);

  function setEditUnitInfo(unit: GetUnitDto) {
    state.editUnitInfo = unit;
  }

  function getUnitById(id: string): GetUnitDto | null {
    return state.units.find((u) => u.id == id) ?? null;
  }

  async function getAllUnits(): Promise<void> {
    try {
      let units = await unitService.getAllUnits();

      state.units = units;
    } catch (e: any) {}
  }

  async function addUnit(newUnitTitle: string): Promise<void> {
    try {
      let newUnit: NewEditUnitDto = {
        title: newUnitTitle,
      };

      let unit = await unitService.createUnit(newUnit);

      state.units.push(unit);
    } catch (e: any) {}
  }

  async function deleteUnits(unitIds: Array<string>): Promise<void> {
    try {
      let idsDto: BatchDeleteDto = {
        ids: unitIds,
      };

      await unitService.deleteBatchUnits(idsDto);

      state.units = state.units.filter((unit) => !unitIds.includes(unit.id));
    } catch (e: any) {}
  }

  async function editUnit(editedTitle: string): Promise<void> {
    try {
      if (editedTitle != state.editUnitInfo?.title) {
        let edited: NewEditUnitDto = {
          title: editedTitle,
        };

        await unitService.editUnit(state.editUnitInfo!.id, edited);

        const editedUnit = state.units.find(
          (u) => u.id == state.editUnitInfo!.id
        );
        editedUnit!.title = editedTitle;
      }
      state.editUnitInfo = null;
    } catch (e: any) {}
  }

  return {
    allUnits,
    editUnitInfo,
    getUnitById,
    setEditUnitInfo,
    getAllUnits,
    addUnit,
    deleteUnits,
    editUnit,
  };
});

export default useUnitStore;
