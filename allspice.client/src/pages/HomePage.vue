<template>
  <div class="container-fluid">    
    <div class="row">     
      <div class="col-12 g-0 text-center">
        <div class="title" id="banner-image">
          <div class="text-end p-2">
            <login/>
          </div>        
          <div class="text-light text-shadow">
            <h2 class="pt-2">All-Spice</h2>
            <h4>Cherish Your Family</h4>
            <h4>And Their Cooking</h4>
          </div>
        </div> 
      </div>        
    </div> 
    <div class="row">
      <div class="col-md-3 pt-3" v-for="r in recipes" :key="r.id">
        <RecipeCard :recipe="r" />        
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
#banner-image{
  width: 100%;
  background-image: url("https://images.unsplash.com/photo-1597528662465-55ece5734101?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80");
  height: 250px;
  background-position: center;
  background-size: cover;
  padding: 0px;

  .text-shadow{
    text-shadow: 3px 2px #040404;
  }  
}
.add-button {
  font-size: 80px;
}
</style>