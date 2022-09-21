<template>
    <div class="card" style="width: 18rem;">
        <img class="card-img-top" :src="recipe.picture" alt="Card image cap">
        <div class="card-body">
            <h5 class="card-title">{{recipe.title}}</h5>
            <p class="card-text">{{recipe.subtitle}}</p>    
        </div>
    </div>
</template>

<script>
export default {
    props: { recipe: {type: Object, required: true}},
    setup() {
        return {};
    },
};
</script>

<style>
</style>