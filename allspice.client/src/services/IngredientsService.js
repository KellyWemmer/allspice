import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

export class IngredientsService {
    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/Ingredients/${recipeId}/IngredientsByRecipeId`)
        logger.log("getting ingredients by Id", res.data)
        AppState.ingredients =  res.data
    }

}

export const ingredientsService = new IngredientsService()