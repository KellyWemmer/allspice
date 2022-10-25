<template>
  <div class="container-fluid">    
    <div class="row">     
    </div>
    <div class="row mt-4">
      <div class="col-md-12" >
        <div class="masonry">
          <div class="recipe-card" v-for="r in recipes" :key="r.id">
            <RecipeCard :recipe="r" />
          </div>
          
        </div>
      </div>
      <div class="row">
        <div class="col-12 d-flex justify-content-end">
          <a href="#" title="add-recipe" class="" data-bs-target="#new-recipe-modal" data-bs-toggle="modal"><i class="add-button mdi mdi-plus-circle"></i></a>   
        </div>
        <NewRecipeModal/>
      </div>
    </div>   
  </div>
</template>
<script>

import { computed } from '@vue/reactivity';
import { Modal } from 'bootstrap';
import { onMounted } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import {recipesService} from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import NewRecipeModal from '../components/NewRecipeModal.vue';


export default {
  name: "Home",  

  setup() {   

    async function getRecipes() {
      try {
        await recipesService.getRecipes();      
      } catch (error) {      
        Pop.toast(error.message, 'error')
      } 
    }      
    
    onMounted(() => {
      getRecipes();
    })
    
    return {
      recipes: computed(() => AppState.recipes)

    };
  },
  components: { RecipeCard, NewRecipeModal }
};
</script>
<style scoped lang="scss">

  .add-button {
    font-size: 80px;
  }

  .nav-links {
    position: relative;
    top: 20%;
    left: 38%;
  }

  .masonry { 
  columns: 4 400px;
  column-gap: 1em; 

  div { 
    display: block;
    margin-bottom: 1em;  
    width: 100%;  
  } 
}
 
</style>