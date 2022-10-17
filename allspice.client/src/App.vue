<template>
  <header>
    <div class="container-fluid">
      <div class="row">
        <div class="col-12 g-0 text-center shadow">
          <div class="title" id="banner-image">
            <div class="text-end p-2">
              <login/>
            </div> 
            <div class="text-light mt-2 text-shadow">
              <h2 class="">All-Spice</h2>
              <h4>Cherish Your Family</h4>
              <h4>And Their Cooking</h4>
            </div>
            <div class="card nav-links shadow" style="width: 25rem;">
              <div class="d-flex card-body justify-content-around rounded">            
                <!-- <a href="#" class="card-link">Home</a> -->
                <router-link :to="{ name: 'Home' }">Home</router-link>
                <router-link :to="{ name: 'MyRecipes'}">My Recipes</router-link>
                <router-link :to="{ name: 'Favorites'}">Favorites</router-link> 
              </div>
            </div>
          </div>
        </div>
    </div>
    </div>
  </header>
  <main>
    <router-view />
  </main>
  <footer>
    
  </footer>
</template>

<script>
import { computed } from 'vue';
import { AppState } from './AppState';

export default {
  name: 'App',
  name: "Home",
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">

#banner-image{
  width: 100%;
  background-image: url("https://images.unsplash.com/photo-1597528662465-55ece5734101?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80");
  height: 275px;
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

  .nav-links {
    position: relative;
    top: 20%;
    left: 38%;
  }

@import "./assets/scss/main.scss";

</style>
