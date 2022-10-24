import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {
    async create(newFavorite) {
        const res = await api.post('api/favorites', newFavorite)
        logger.log('new favorite', res.data)
        AppState.myFavorites.push(res.data)
    }

}

export const favoritesService = new FavoritesService();