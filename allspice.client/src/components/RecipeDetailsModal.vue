<template>
    <div class="modal" id="recipe-modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
        <div class="modal-header">
            <h5 class="modal-title">{{recipe.title}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
            </button>
        </div>
        <div class="modal-body">
            <div class="row">
            <div class="col-4">
                <img class="img-fluid recipe-img" :src="recipe?.img" alt="">
            </div> 
            <div class="col-4">
                <p>Recipe Steps Card</p>
            </div>
            <div class="col-4">
                <p>Recipe Ingredients Card</p>
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

export default {
setup() {
        return {
            recipe: computed(()=>AppState.activeRecipe)
        };
    },
};
</script>
<style>
</style>
