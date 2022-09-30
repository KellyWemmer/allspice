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
import { onMounted } from 'vue';
import { recipesService } from '../services/RecipesService';

export default {
    props: { recipe: {type: Object, required: true}},
    setup(props) {
        async function getRecipeById() {
            try {
                await recipesService.getRecipeById(props.recipe.id)
            } catch (error) {
              logger.error(error)
              Pop.toast(error.message, 'error')
            }
        }

        onMounted(()=> {
            getRecipeById();
        })

        return {};
    },
};
</script>
<style>
</style>