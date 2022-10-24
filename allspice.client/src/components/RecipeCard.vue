<template>
    <div class="selectable img-card" @click="setActiveRecipeModal()">
        <img class="img-fluid mb-3 mt-3 rounded" :src="recipe?.picture" alt="">
        <div class="row img-category text-white aligns-items-center text-center">
            <p class="text-category">{{recipe?.category}}</p>
        </div>          
        <div class="row text-white img-title d-flex">
            <div class="text-title">
                <h5 class="m-0">{{recipe?.title}}</h5>            
                <p class="m-0">{{recipe?.subtitle}}</p>
            </div>                        
        </div>      
    </div>    
<RecipeDetailsModal/>
</template>

<script>
import { Modal } from 'bootstrap';
import { recipesService } from '../services/RecipesService';
import { stepsService } from '../services/StepsService';
import { ingredientsService} from '../services/IngredientsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import RecipeDetailsModal from './RecipeDetailsModal.vue';
import { favoritesService } from '../services/FavoritesService';
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState';

export default {
    props: { 
        recipe: { type: Object, required: true }},

    setup(props) {
        return {
            favorite: computed(()=> AppState.favorite),

            async setActiveRecipeModal() {  //get steps and ingredients when modal is rendered.              
                try {
                    Modal.getOrCreateInstance(document.getElementById("recipe-modal")).toggle();
                    await recipesService.getRecipeById(props.recipe.id);
                    await stepsService.getStepsByRecipeId(props.recipe.id);
                    await ingredientsService.getIngredientsByRecipeId(props.recipe.id);
                    await favoritesService.getFavoriteIfExists(props.recipe.id);
                }
                catch (error) {
                    logger.error("Set active recipe", error);
                    Pop.toast(error.message, "error");
                }
            }
        };
    },
    components: { RecipeDetailsModal }
};
</script>

<style>
    .img-card{
        position: relative;
        width: 100%;
    }

    .img-category {
        position: absolute;
        width: 100%;
        top: 5%;
        left: 6%;
        width: 30%;

    }

    .img-title {
        position: absolute;
        width: 100%;
        bottom: 5%;
        left: 7%;
        width: 90%;  
    }

    .text-category {
        border-radius: 30px;
        background: rgba(57, 56, 56, 0.4);
        border: 1px solid #f4f4f4;
        backdrop-filter: blur(8px);   
    }  
    
    .text-title {
        border-radius: 10px;
        background: rgba(57, 56, 56, 0.4);
        border: 1px solid #f4f4f4;
        backdrop-filter: blur(8px); 
    }

</style>