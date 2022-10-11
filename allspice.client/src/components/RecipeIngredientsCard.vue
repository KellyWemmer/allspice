<template>
    
    <div class="card" style="width: 21rem;">
    <div class="bg-dark card-header">
        Recipe Ingredients       
    </div>
    <ol class="list-group list-group-flush">
        <li v-for="i in ingredients" :key="i.id" class="list-group-item">{{i.quantity}} {{i.name}}</li>
    </ol>
    <form @submit.prevent="handleSubmit">
            <div class="row">
                <div class="col-3 mt-2 mb-2">                    
                    <input required type="text" class="form-control" id="ingredient-quantity" aria-describedby="ingredientHelp" placeholder="Qty">
                </div>
                <div class="col-7 mt-2 mb-2">                   
                    <input required type="text" class="form-control" id="ingredient-name" aria-describedby="ingredientHelp" placeholder="Ingredient Name">
                </div> 
                <div class="col-2 mt-3 mb-2">
                    <button class="mdi mdi-plus"></button>                   
                </div>               
            </div>
        </form>
</div>    
</template>
<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    //Ingredients card is receiving information on active recipe from modal
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