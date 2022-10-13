import { AppState } from "../AppState";
import { logger } from "../utils/Logger"
import { api } from "./AxiosService";

class RecipesService {
    async getRecipes() {
        const res = await api.get('/api/recipes')
        logger.log('Getting Recipes', res.data)
        AppState.recipes = res.data
    }

    async getRecipeById(id) {
        const res = await api.get(`api/recipes/${id}`)
        logger.log("getting recipe by Id", res.data)
        AppState.activeRecipe = res.data
    }

    async createRecipe(newRecipe) {
        const res = await api.post('api/recipes', newRecipe)
        logger.log("Create Recipe", res.data)
        AppState.recipes.push(res.data)
    }

    async deleteRecipe(id) {
        const res = await api.delete(`api/recipes/${id}`)
        logger.log("deleted recipe", res.data)
        AppState.recipes = AppState.recipes.filter(r => r.id != id)
    }

}
export const recipesService = new RecipesService()