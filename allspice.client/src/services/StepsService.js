class StepsService {

    //TODO finish steps service
    async getStepsByRecipeId(id) { 
        const res = await api.get(`api/steps/${id}`)
        logger.log("getting recipe by Id", res.data)
        AppState.activeRecipe = res.data
    }

}

export const stepsService = new StepsService();