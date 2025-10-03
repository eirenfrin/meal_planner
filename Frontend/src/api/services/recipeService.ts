import api from "../axios";

// call backend endpoints here

class RecipeService {
  // public async checkIfRecipeExists(recipeName: string): Promise<boolean> {
  //   return (await api.get<boolean>(`recipe/${recipeName}/exists`)).data;
  // }
}

const recipeService = new RecipeService();

export default recipeService;
