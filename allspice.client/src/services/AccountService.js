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
}

export const accountService = new AccountService()
