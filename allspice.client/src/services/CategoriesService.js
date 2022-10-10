import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class CategoriesService {
    async getCategories() {
        const res = await api.get('api/categories')
        logger.log('getting categories from Service', res.data)
        AppState.categories = res.data
        logger.log('AppState data', res.data)
    }

};

export const categoriesService = new CategoriesService()