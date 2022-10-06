<template>
    <div class="card selectable" @click="setActiveRecipeModal" style="width: 18rem;">
        <img class="card-img-top" :src="recipe.picture" alt="Card image cap">
        <div class="card-body">
            <h5 class="card-title">{{recipe.title}}</h5>
            <p class="card-text">{{recipe.subtitle}}</p>    
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
</style>