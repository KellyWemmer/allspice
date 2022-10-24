<template>
    <div class="container-fluid">
        <div class="row mt-4">
            <div class="masonry">
                <div class="col-3 recipe-imgs" v-for="f in myFavorites" :key="f.id">
                    <RecipeCard :recipe="f"/> 
                </div>
            </div>  
        </div>
    </div>
    
</template>
<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState';
import { accountService } from '../services/AccountService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    setup() {

        async function getFavoritesByAccount() {
            try {
                await accountService.getFavoritesByAccount(AppState.account.id)
              
            } catch (error) {
              logger.error(error)
              Pop.toast(error.message, 'error')
            }
        }

        onMounted(()=> {
            getFavoritesByAccount();
        })
        return {
            myFavorites: computed(()=>AppState.myFavorites)
        };
    },
};
</script>
<style>
</style>