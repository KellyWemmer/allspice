<template>
    
    <div class="card" style="width: 15rem;">
    <div class="bg-dark card-header">
        Recipe Ingredients       
    </div>
    <ol class="list-group list-group-flush">
        <li class="list-group-item">Ingredient</li>
        <li class="list-group-item">Ingredient</li>
        <li class="list-group-item">Ingredient</li>
        <li class="list-group-item">Ingredient</li>
        <li class="list-group-item">Ingredient</li>
    </ol>
</div>    
</template>
<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
   
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

        onMounted(()=> {
            getRecipeById();
        })

        return {
            recipe: computed(()=>AppState.activeRecipe)
        };
    },
};
</script>
<style>
</style>