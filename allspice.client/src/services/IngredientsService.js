import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

export class IngredientsService {
    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/Ingredients/${recipeId}/IngredientsByRecipeId`)
        logger.log("getting ingredients by Id", res.data)
        AppState.ingredients =  res.data
    }

    async createIngredient(ingredient) {
        const res = await api.post('api/Ingredients', ingredient) 
        logger.log('Creating Ingredient', res.data)
        AppState.ingredients.push(res.data)
    }

    async deleteIngredient(id) {
        const res = await api.delete(`api/Ingredients/${id}`)
        logger.log('Deleted ingredient', res.data)
        AppState.ingredients = AppState.ingredients.filter(i=> i.id != id)
    }

}

export const ingredientsService = new IngredientsService()