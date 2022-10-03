import { AppState } from "../AppState";
import { api } from "./AxiosService";

class StepsService {

    //TODO finish steps service
    async getStepsByRecipeId(recipeId) { 
        const res = await api.get(`api/steps/${recipeId}/StepsByRecipeId`)
        logger.log("getting steps by Id", res.data)
        AppState.steps = res.data
    }

}

export const stepsService = new StepsService();