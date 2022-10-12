<template>
    <div class="modal fade" id="recipe-modal" tabindex="-1" aria-labelledby="recipe-modal" aria-hidden="true">
    <div class="modal-dialog modal-xl" role="document">
        <div class="modal-content">
            <div class="modal-header bg-dark text-light">
                <h5 class="modal-title">{{recipe?.title}}</h5>
                <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>
        <div class="modal-body">
            <div class="row">
                <div class="col-4">
                    <img class="img-fluid recipe-img" :src="recipe?.picture" alt="">
                </div> 
                <div class="col-4">
                    <div class="recipe-steps">
                        <!-- sends recipe information to the card via the prop ":recipe" -->
                        <RecipeStepsCard :recipe="recipe"/> 
                    </div>
                </div>
                <div class="col-4">
                    <div class="recipe-steps">
                        <RecipeIngredientsCard :recipe="recipe"/>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 text-end m-2">
                    <button class="btn bg-dark">Delete Recipe</button>
                </div>
            </div>        
        </div>        
        </div>
    </div>
    </div>    
</template>
<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState';
import RecipeStepsCard from './RecipeStepsCard.vue';

export default {
    //Modal sends information to cards
    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe)
        };
    },
    components: { RecipeStepsCard }
};
</script>
<style>
</style>
