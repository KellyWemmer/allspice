<template>
    <div class="card" style="width: 15rem;">
    <div class="bg-dark card-header">
        Recipe Steps       
    </div>
    <ol class="list-group list-group-flush">
        <li v-for="s in steps" :key="s.id" class="list-group-item">{{s.position}}. {{s.body}}</li>
    </ol>
    </div>    
</template>
<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { stepsService } from '../services/StepsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    //Steps card is receiving information on active recipe from modal
    props:{
        recipe:{
            type: Object,
            required:true
        }
    },
    setup(props) {
        async function getRecipeById() {
            try {
                if(AppState.activeRecipe){
                    await recipesService.getRecipeById(props.recipe?.id)
                }
            } catch (error) {
                logger.error(error)
                Pop.toast(error.message, 'error')
            }
        }
        //pass in recipe id        
        async function getStepsByRecipeId() {
                try {
                    if(AppState.activeRecipe){

                        await stepsService.getStepsByRecipeId(props.recipe?.id)
                    }
                } catch (error) {
                  logger.error(error)
                  Pop.toast(error.message, 'error')
                }
            }
            
        onMounted(()=> {
            getRecipeById();
            getStepsByRecipeId();
        })

        return {
            steps: computed(()=> AppState.steps),
            recipe: computed(()=>AppState.activeRecipe)
        };
    },
};
</script>
<style>
</style>