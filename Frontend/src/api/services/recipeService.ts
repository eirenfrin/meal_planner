import type { GetRecipeAllInfoDto } from "../../domain/models/getRecipeAllInfoDto";
import type { GetRecipeBasicInfoDto } from "../../domain/models/getRecipeBasicInfoDto";
import type { NewEditRecipeDto } from "../../domain/models/newEditRecipeDto";
import BaseService from "./baseService";

class RecipeService extends BaseService {
  constructor() {
    super("api/recipe");
  }

  public async getSingleRecipe(recipeId: string): Promise<GetRecipeAllInfoDto> {
    let recipe = await this.get<GetRecipeAllInfoDto>(`${recipeId}`);

    return recipe;
  }

  public async getAllRecipes(): Promise<Array<GetRecipeBasicInfoDto>> {
    let allRecipes = await this.get<Array<GetRecipeBasicInfoDto>>("all");

    return allRecipes;
  }

  public async addRecipe(
    newRecipe: NewEditRecipeDto
  ): Promise<GetRecipeAllInfoDto> {
    let addedRecipe = await this.post<NewEditRecipeDto, GetRecipeAllInfoDto>(
      "",
      newRecipe
    );

    return addedRecipe;
  }

  public async editRecipe(
    recipeId: string,
    editedRecipe: NewEditRecipeDto
  ): Promise<void> {
    await this.put<NewEditRecipeDto, void>(`${recipeId}`, editedRecipe);
  }

  public async deleteRecipe(recipeId: string): Promise<void> {
    await this.delete<void>(`${recipeId}`);
  }
}

const recipeService = new RecipeService();

export default recipeService;
