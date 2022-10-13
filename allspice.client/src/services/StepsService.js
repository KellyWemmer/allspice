import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class StepsService {
    async getStepsByRecipeId(recipeId) { 
        const res = await api.get(`api/steps/${recipeId}/StepsByRecipeId`)
        logger.log("getting steps by Id", res.data)
        AppState.steps = res.data
    }

    async createStep(step) {
        const res = await api.post('api/Steps', step) 
        logger.log('Creating Step', res.data)
        AppState.steps.push(res.data)
    }

    async deleteStep(id) {
        const res = await api.delete(`api/steps/${id}`)
        logger.log('step deleted', res.data)
        AppState.steps = AppState.steps.filter(s=> s.id != id)
    }

}
export const stepsService = new StepsService();