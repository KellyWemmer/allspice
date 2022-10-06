<template>
    
    <div class="card" style="width: 15rem;">
    <div class="bg-dark card-header">
        Recipe Ingredients       
    </div>
    <ol class="list-group list-group-flush">
        <li v-for="i in ingredients" :key="i.id" class="list-group-item">{{i.quantity}} {{i.name}}</li>
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
    //props receive information from recipe Object
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

        async function getIngredientsByRecipeId() {
                try {
                    if(AppState.activeRecipe){

                        await ingredientsService.getIngredientsByRecipeId(props.recipe?.id)
                    }
                } catch (error) {
                  logger.error(error)
                  Pop.toast(error.message, 'error')
                }
            }

        onMounted(()=> {
            getRecipeById();
            getIngredientsByRecipeId();
        })

        return {
            recipe: computed(()=>AppState.activeRecipe),
            ingredients: computed(()=>AppState.ingredients)
        };
    },
};
</script>
<style>
</style>