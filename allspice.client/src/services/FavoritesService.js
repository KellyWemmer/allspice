import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {
    async create(newFavorite) {
        const res = await api.post('api/favorites', newFavorite)
        logger.log('new favorite', res.data)
        AppState.myFavorites.push(res.data)
    }

    async getFavoriteIfExists(recipeId) {
        const res = await api.get(`api/favorites/${recipeId}`)
        logger.log("Checking to see if favorite already exists", res.data)
        if(res.data == "") {
            AppState.favorite = null
        } else {
            AppState.favorite = res.data
            logger.log("Logging AppState Favorite", AppState.favorite)
        }

    }

    async deleteFavorite(recipeId) {
        const res = await api.delete(`api/favorites/${recipeId}`)
        logger.log("Deleting favorite", res.data)
        AppState.myFavorites = AppState.myFavorites.filter(f => f.id != recipeId)
    }

}

export const favoritesService = new FavoritesService();