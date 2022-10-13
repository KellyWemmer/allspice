<template>
    <div class="selectable img-card" @click="setActiveRecipeModal()">
        <img class="img-fluid mb-3 mt-3 rounded" :src="recipe.picture" alt="">  
        <!-- TODO in this div.... draw the keep name and the creator img -->
        <div class="row img-text d-flex justify-content-between">
            <h5 class="recipe-title">{{recipe.title}}</h5>
            <div>
                <p>{{recipe.subtitle}}</p>    
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

export default {
    props: { recipe: { type: Object, required: true } },
    setup(props) {
        return {
            async setActiveRecipeModal() {  //get steps and ingredients when modal is rendered.              
                try {
                    Modal.getOrCreateInstance(document.getElementById("recipe-modal")).toggle();
                    await recipesService.getRecipeById(props.recipe.id);
                    await stepsService.getStepsByRecipeId(props.recipe.id);
                    await ingredientsService.getIngredientsByRecipeId(props.recipe.id);
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

    .img-text{
        position: absolute;
        width: 100%;
        bottom: 5%;
        left: 7%;
        width: 90%;
        border-radius: 10px;
        background: rgba(239, 237, 237, 0.4);
        border: 1px solid #f4f4f4;
        backdrop-filter: blur(8px);
    }
    </style>