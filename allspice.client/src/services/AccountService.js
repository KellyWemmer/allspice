import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getRecipesByAccount() {
    const res = await api.get('/account/recipes')
    logger.log('My account recipes', res.data)
    AppState.myRecipes = res.data
  }

  async getFavoritesByAccount() {
    const res = await api.get('/account/favorites')
    logger.log('My account favorites', res.data)
    AppState.myFavorites = res.data
  }

//   async getFavoriteIfExists(recipeId, accountId){
//     const res = await api.get()
// }
}

export const accountService = new AccountService()
