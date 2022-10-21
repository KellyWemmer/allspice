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
                    <div class="col-8">
                        <div class="row">
                            <div class="col-5 d-flex justify-content-between">
                                <b>{{recipe?.title}}</b>
                            <div class="col-5 category-text text-center">
                                <span class="m-3">{{recipe?.category}}</span>
                            </div>
                            <div>
                                <i class="col-2 selectable d-flex mdi mdi-heart-plus-outline material-icons" @click="addToFavorites()" title="Add to Favorites"></i>    
                            </div>                                
                            </div>
                        <div class="row">
                            <div class="col-12 mt-2 mb-1">
                                {{recipe?.subtitle}}
                            </div>
                        </div> 
                        <div class="row mt-3">
                            <div class="col-6">
                                <div v-if="recipe != null" class="recipe-steps">
                                    <!-- sends recipe information to the card via the prop ":recipe" -->
                                    <RecipeStepsCard :recipe="recipe"/> 
                                </div>
                            </div>
                            <div class="col-6">
                                <div v-if="recipe != null" class="recipe-steps">
                                    <RecipeIngredientsCard :recipe="recipe"/>
                                </div>
                            </div>
                        </div>                                     
                    </div> 
                </div>
                <div class="row">
                    <div class="col-12 text-end m-2">
                        <button v-if="user.id == recipe?.creatorId" class="btn bg-dark close m-2" data-bs-dismiss="modal" aria-label="Close">Save Recipe</button>
                        <button v-if="user.id == recipe?.creatorId" @click="deleteRecipe(recipe.id)" class="btn bg-dark close" data-bs-dismiss="modal" aria-label="Close">Delete Recipe</button>
                    </div>
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
import { router } from '../router';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';
import RecipeStepsCard from './RecipeStepsCard.vue';

export default {
    //Modal sends information to cards
    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe),
            user: computed(()=> AppState.user),

            async deleteRecipe(id) {
                try {
                  const yes = await Pop.confirm('Are you sure you want to delete this recipe?')  
                  if(!yes) {return}
                  await recipesService.deleteRecipe(id)
                  Pop.toast("This recipe and its contents have been deleted")
                  router.push({name: 'Home'})
                } catch (error) {
                  logger.error(error)
                  Pop.toast(error.message, 'error')
                  router.push({name: 'Home'})
                }
            }
        };
    },
    components: { RecipeStepsCard }
};
</script>
<style>

.material-icons {
    font-size: 22px;   
}
.category-text {
    border-radius: 30px;
    background: rgba(57, 56, 56, 0.4);
    border: 1px solid #f4f4f4;
    backdrop-filter: blur(8px);   
}
</style>
