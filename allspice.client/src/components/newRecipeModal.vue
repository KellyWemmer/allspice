<template>
    <div class="modal fade" id="newRecipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header ">                    
                    <h5 class="modal-title">New Recipe</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="handleSubmit">
                        <div class="form-group" id="new-recipe-modal">
                            <label for="title">Title</label>
                            <input required v-model="editable.title" type="text" class="form-control" id="title" aria-describedby="titleHelp">    
                        </div>
                        <!-- v-for over category options. Use Keepr as reference? -->
                        <select class="form-select" aria-label="Default select example">
                            <label for="category">Category</label>
                            <option selected>Open this select menu</option>
                            <option value="concert">Concert</option>
                            <option value="convention">Convention</option>
                            <option value="sport">Sport</option>
                            <option value="digital">Digital</option>
                        </select>
                        <div class="form-check m-3">
                            <input type="checkbox" class="form-check-input" id="isPrivate">
                            <label class="form-check-label" for="isPrivate">Private?</label>
                            <small id="titleHelp" class="form-text text-muted">Private vaults can only be seen by you.</small>
                        </div>
                        <button type="submit" class="btn btn-primary m-3">Create</button>
                    </form>
                </div>              
            </div>
        </div>
    </div>
</template>
<script>

export default {
setup() {
        return {};
    },
};
</script>
<style>
</style>