<template>
    <div class="card" style="width: 21rem;">
        <div class="bg-dark card-header">
            Recipe Steps      
        </div>
        <ol class="list-group list-group-flush">
            <li v-for="s in steps" :key="s.id" class="list-group-item"><span v-if="user.id == recipe?.creatorId" @click="deleteStep(s.id)" class="selectable text-danger mdi mdi-alpha-x-circle-outline m-3" title="delete"></span>{{s.position}}. {{s.body}}</li>
        </ol>
        <div v-if="user.id == recipe?.creatorId">
            <form @submit.prevent="handleSubmit">
                <div class="row">
                    <div class="col-3 mt-2 mb-2">                    
                        <input required v-model="editable.position" type="number" class="form-control input-field" id="step-number" aria-describedby="stepHelp" placeholder="#">
                    </div>
                    <div class="col-7 mt-2 mb-2">                   
                        <input required v-model="editable.body" type="text" class="form-control input-field" id="step-body" aria-describedby="stepHelp" placeholder="Instructions">
                    </div> 
                    <div class="col-2 mt-2 mb-3">
                        <button type="submit" class="mdi mdi-plus"></button>                   
                    </div>               
                </div>
            </form>
        </div>
    </div>    
</template>
<script>
import { computed } from '@vue/reactivity';
import { onMounted, watchEffect, ref } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { stepsService } from '../services/StepsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';


export default {
    //Steps card is receiving information on active recipe from modal
    props:{
        recipe:{
            type: Object,
            required:true
        },
        stepsData: { type: Object, 
            required: false, default: {}
        }
    },
    setup(props) {
        const editable = ref({})
        watchEffect(() => {
            logger.log("watching step")
            editable.value = props.stepsData
        })

        async function getRecipeById() {
            try {
                if(AppState.activeRecipe){
                    await recipesService.getRecipeById(props.recipe?.id)
                }
            } catch (error) {
                logger.error(error)
                Pop.toast(error.message, 'error')
            }
        }
        //pass in recipe id        
        async function getStepsByRecipeId() {
                try {
                    if(AppState.activeRecipe){

                        await stepsService.getStepsByRecipeId(props.recipe?.id)
                    }
                } catch (error) {
                  logger.error(error)
                  Pop.toast(error.message, 'error')
                }
            }
            
        onMounted(()=> {
            getRecipeById();
            getStepsByRecipeId();
        })

        return {
            editable,
            steps: computed(()=> AppState.steps),
            recipe: computed(()=>AppState.activeRecipe),
            user: computed(()=> AppState.user),

            async handleSubmit() {
                try {
                    logger.log('Step Data', editable.value);
                    editable.value.recipeId = this.recipe.id;
                    await stepsService.createStep(editable.value);
                    Pop.toast("Step has been created")
                }   catch (error) {
                    logger.log(error)
                    Pop.toast(error.message, 'error')
                }
            },

            async deleteStep(id) {
                try {
                    const yes = await Pop.confirm('Are you sure you want to delete this step?')  
                  if(!yes) {return}
                    await stepsService.deleteStep(id)
                    Pop.toast                       
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