<template>
    <div class="card selectable" @click="setActiveRecipeModal" style="width: 18rem;">
        <img class="card-img-top" :src="recipe.picture" alt="Card image cap">
        <div class="card-body">
            <h5 class="card-title">{{recipe.title}}</h5>
            <p class="card-text">{{recipe.subtitle}}</p>    
        </div>
    </div>
</template>

<script>
import { Modal } from 'bootstrap';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    props: { recipe: {type: Object, required: true}},
    setup(props) {
        return {
            async setActiveRecipeModal() {
                try {
                  Modal.getOrCreateInstance(document.getElementById("recipe-modal")).toggle();
                  await recipesService.getRecipeById
                } catch (error) {
                  logger.error(error)
                  Pop.toast(error.message, 'error')
                }
            }
        };
    },
};
</script>

<style>
</style>