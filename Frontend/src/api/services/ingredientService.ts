import type { BatchDeleteDto } from "../../domain/models/batchDeleteDto";
import type { GetIngredientDto } from "../../domain/models/getIngredientDto";
import type { NewEditIngredientDto } from "../../domain/models/newEditIngredientDto";
import BaseService from "./baseService";

class IngredientService extends BaseService {
  constructor() {
    super("api/ingredient");
  }

  public async getAllIngredients(): Promise<Array<GetIngredientDto>> {
    let ingredients = await this.get<Array<GetIngredientDto>>("all");

    return ingredients;
  }

  public async addNewIngredient(
    newIngredient: NewEditIngredientDto
  ): Promise<GetIngredientDto> {
    let addedIngredient = await this.post<
      NewEditIngredientDto,
      GetIngredientDto
    >("", newIngredient);

    return addedIngredient;
  }

  public async editIngredient(
    ingredientId: string,
    editedIngredient: NewEditIngredientDto
  ): Promise<void> {
    await this.put<NewEditIngredientDto, void>(
      `${ingredientId}`,
      editedIngredient
    );
  }

  public async deleteIngredient(ingredientId: string): Promise<void> {
    await this.delete<void>(`${ingredientId}`);
  }

  public async deleteBatchIngredients(
    ingredientsToDelete: BatchDeleteDto
  ): Promise<void> {
    await this.post<BatchDeleteDto, void>(
      "delete-multiple",
      ingredientsToDelete
    );
  }
}

const ingredientService = new IngredientService();

export default ingredientService;
