<template>
    
    <div class="card" style="width: 21rem;">
    <div class="bg-dark card-header">
        Recipe Ingredients <span class="selectable mdi mdi mdi-pencil m-2" title="Edit-Ingredients"></span>      
    </div>
    <ol class="list-group list-group-flush">
        <li v-for="i in ingredients" :key="i.id" class="list-group-item">{{i.quantity}} {{i.name}}</li>
    </ol>
    <form @submit.prevent="handleSubmit">
            <div class="row">
                <!-- TODO increment step number automatically -->
                <div class="col-3 mt-2 mb-2">                    
                    <input required v-model="editable.quantity" type="text" class="form-control" id="ingredient-quantity" aria-describedby="ingredientHelp" placeholder="Qty">
                </div>
                <div class="col-7 mt-2 mb-2">                   
                    <input required v-model="editable.name" type="text" class="form-control" id="ingredient-name" aria-describedby="ingredientHelp" placeholder="Ingredient Name">
                </div> 
                <div class="col-2 mt-3 mb-2">
                    <button class="mdi mdi-plus"></button>                   
                </div>               
            </div>
        </form>
</div>    
</template>
<script>
import { computed, onMounted, ref, watchEffect } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { ingredientsService } from '../services/IngredientsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    //Ingredients card is receiving information on active recipe from modal
    props:{
        recipe:{
            type: Object,
            required:true
        },
        ingredientsData: {type: Object,
        required: true, default: {}
        }
    },
    setup(props) {
        const editable = ref({})
        watchEffect(() => {
            logger.log('watching ingredient')
            editable.value = props.ingredientsData
        })

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
            editable,
            recipe: computed(()=>AppState.activeRecipe),
            ingredients: computed(()=>AppState.ingredients),

            async handleSubmit() {
                try {
                    logger.log('Ingredient Data', editable.value);
                    editable.value.recipeId = this.recipe.id;
                    await ingredientsService.createIngredient(editable.value);
                    Pop.toast("Ingredient has been added")
                }   catch (error) {
                    logger.log(error)
                    Pop.toast(error.message, 'error')
                }
            }    
        };
    },
};
</script>
<style>
</style>