<template>
    <div class="card" style="width: 15rem;">
    <div class="bg-dark card-header">
        Recipe Steps       
    </div>
    <ol class="list-group list-group-flush">
        <li v-for="s in activeSteps" :key="s.id" class="list-group-item">{{s.position}}{{s.body}}</li>
    </ol>
</div>    
</template>
<script>
import { onMounted } from 'vue';
import { recipesService } from '../services/RecipesService';

export default {
    props: { recipe: {type: Object, required: true}},
    setup(props) {
        //create separate function to return activeSteps to AppState
        async function getRecipeById() {
            try {
                await recipesService.getRecipeById(props.recipe.id)
            } catch (error) {
              logger.error(error)
              Pop.toast(error.message, 'error')
            }
        }

        async function getStepsByRecipeId() {
                try {
                    await StepsService.getStepsByRecipeId(id)
                } catch (error) {
                  logger.error(error)
                  Pop.toast(error.message, 'error')
                }
            }

        onMounted(()=> {
            getRecipeById();
        })

        return {
            activeSteps: computed(()=> AppState.activeSteps)
            
        };
    },
};
</script>
<style>
</style>