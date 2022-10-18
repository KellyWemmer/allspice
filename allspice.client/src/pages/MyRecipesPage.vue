<template>
    <div class="row mt-4">
        <div class="masonry">
            <div v-if="recipes != null" class="col-3 recipe-imgs" v-for="r in recipes" :key="r.id">
                <RecipeCard :recipe="r"/> 
            </div>
        </div>  
    </div>
</template>
<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import { accountService } from '../services/AccountService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
export default {
    setup() {

        async function getRecipesByAccount() {
            try {
                await accountService.getRecipesByAccount(AppState.account.id)
            } catch (error) {
              logger.error(error)
              Pop.toast(error.message, 'error')
            }
        }

        onMounted(()=> {
            getRecipesByAccount();
        })

        return {
            user: computed(()=> AppState.user),
            recipes: computed(()=>AppState.myRecipes),
            account: computed(()=> AppState.account),
        };
    },
    components: { RecipeCard }
};
</script>
<style scoped lang="scss">
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