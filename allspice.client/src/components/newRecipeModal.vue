<template> 
    <div class="modal fade" id="new-recipe-modal" tabindex="-1" aria-labelledby="new-recipe-modal" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header bg-dark text-light">
        <h5 class="modal-title">New Recipe</h5>
        <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
      </div>
      <div class="modal-body">
        <div class="container-fluid">
            <form @submit.prevent="handleSubmit" id="recipe-form">        
                <div class="row">
                    <div class="col-6 mt-4">
                        <div class="form-group">
                            <label for="title">Title</label>
                            <input required v-model="editable.title" type="text" class="form-control" id="title" aria-describedby="titleHelp">    
                        </div>
                    </div>
                    <div class="col-6 mt-4">
                        <div class="form-group">
                            <label for="picture">Image</label>
                            <input required v-model="editable.picture" type="text" class="form-control" id="picture" aria-describedby="pictureHelp">    
                        </div>                        
                    </div>                                        
                </div>
                <div class="row">
                    <div class="col-6 mt-4">
                        <div class="form-group">
                            <label for="subtitle">Subtitle</label>
                            <input required v-model="editable.subtitle" type="text" class="form-control" id="subtitle" placeholder="Details">
                        </div>
                        <small class="form-text text-muted">A Brief Description of the Recipe</small>                           
                    </div>
                    <div class="col-6 mt-4">
                        <!-- TODO set default category -->
                        <label for="category">Category</label>
                        <select class="form-control" id="category-value" @change="changeCategory($event)" aria-label="Default select" >
                            <option value="" selected="true" id="default-option"></option>
                            <option v-for="c in categories" :key="c.id" :value="c">{{c}}</option>
                        </select>
                    </div>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                  <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Create</button>
                </div>
            </form>    
        </div>        
      </div>
    </div>
  </div>
</div>    
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted, ref, watchEffect } from 'vue';
import { logger } from '../utils/Logger';
import { categoriesService} from '../services/CategoriesService'
import { AppState} from '../AppState'
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';

export default {
    props: {recipeData: { type: Object, required: false, default: {} }},
    setup(props) {
        const editable = ref({})
        watchEffect(()=> {
            logger.log('watching for recipeData')
            editable.value = props.recipeData
        })

        

        async function getCategories() {
            try {
                await categoriesService.getCategories()
            } catch (error) {
                logger.error("getting categories", error)
                Pop.toast(error.message, 'error')
            }
        }

        onMounted(()=>{
            getCategories()
        })
        
        return {
            editable,
            categories: computed(()=> AppState.categories),

            async handleSubmit() {
                try {
                    editable.value.category = this.selectedCategory
                    logger.log('category in handleSubmit', this.selectedCategory)
                    await recipesService.createRecipe(editable.value);
                    logger.log('Recipe Data Input', editable.value)
                    Pop.toast('Recipe Created')
                    var select = document.getElementById("category-value");
                    
                    document.getElementById('recipe-form').reset();
                    editable.value = {};                    
                    select = select.selectedIndex = -1;
                    
                } catch (error) {
                  logger.error(error)
                  Pop.toast(error.message, 'error')
                }
            },

            changeCategory(event) {
                logger.log('category', event.target.options[event.target.options.selectedIndex].text)
                this.selectedCategory = event.target.options[event.target.options.selectedIndex].text
            },            
        };

        
    },
};
</script>
<style>
</style>