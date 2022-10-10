<template> 
    <div class="modal fade" id="new-recipe-modal" tabindex="-1" aria-labelledby="new-recipe-modal" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header bg-dark text-light">
        <h5 class="modal-title">New Recipe</h5>
        <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
      </div>
      <div class="modal-body">
        <!-- TODO Remove color on input fields -->
        <form @submit.prevent="handleSubmit">        
            <div class="form-group">
                <label for="title">Title</label>
                <input required v-model="editable.title" type="text" class="form-control" id="title" aria-describedby="titleHelp">    
            </div>
            <div class="form-group">
                <label for="description">Description</label>
                <input required v-model="editable.description" type="text" class="form-control" id="description">
            </div> 
            <select class="form-select" aria-label="Default select">
                <option selected>Open this select menu</option>
                <!-- <option v-for="c in categories"></option> -->
            </select>                    
        </form>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Submit</button>
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

            
        };

        
    },
};
</script>
<style>
</style>