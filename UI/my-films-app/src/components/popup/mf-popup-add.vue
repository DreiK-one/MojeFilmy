<template>
    <div>
        <div class="mf-popup-add__content" >
            <form @submit.prevent="onAddSubmit" method="post">
                <div>
                        <div class="row">
                            <div class="col-sm-1">Title:</div> 
                            <div  class="col-md-6">
                                <input type="text" v-model.trim="$v.posts.title.$model">
                            </div>
                            <div class="col-md-5">
                                <span v-if="!$v.posts.title.required" class="text-danger">Title is required</span>
                                <span v-if="!$v.posts.title.maxLength" class="text-danger">Max length of title is 200</span>
                            </div>
                        </div> 

                        <div class="row">
                            <div class="col-sm-1">Year: </div> 
                            <div  class="col-md-6">
                                <input type="text" v-model="$v.posts.creationYear.$model">
                            </div>
                            <div class="col-md-5">
                                <span v-if="!$v.posts.creationYear.minValue" class="text-danger">Year of creation can't be less then 1900</span>
                                <span v-if="!$v.posts.creationYear.maxValue" class="text-danger">Year of creation can't be greater then 2100</span>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-1">Description: </div>
                            <div  class="col-md-6">
                                <input type="text" v-model="$v.posts.description.$model">
                            </div>
                            <div class="col-md-5">
                                <span v-if="!$v.posts.description.required" class="text-danger">Description is required</span>
                                <span v-if="!$v.posts.description.maxLength" class="text-danger">Max length of description is 1000</span>
                            </div>
                        </div>
                        <br>
                        <button class="btn btn-outline btn-outline-primary btn-lg col-sm-2 left" @click="closePopup">Cancel</button>
                        <button class="btn btn-outline btn-outline-success btn-lg col-sm-2 right" type="submit">Add</button>
                </div>
            </form>
                
        </div> 
        <div class="mf-popup-add__footer">
        </div>  
    </div>        
</template>

<script>
import {mapActions} from 'vuex'
import { required, maxLength, minValue, maxValue} from 'vuelidate/lib/validators'

export default {
    name: "mf-popup-add",

    data(){
        return{
            posts:{
                title: null,
                description: null,
                creationYear: null,
            },
        }
    },

    validations:{
        posts: {
            title:{
            required,
            maxLength: maxLength(200)
            },
            description:{
                required,
                maxLength: maxLength(1000)
            },
            creationYear:{
                minValue: minValue(1900),
                maxValue: maxValue(2100)
            }
        }
    },

    methods:{
        closePopup(){
            this.$emit('closePopup');
        },

        ...mapActions([
            'GET_FILMS_FROM_API',
            'CREATE_FILM'
        ]),

        onAddSubmit(event){
            this.$v.$touch();
            
            if (this.$v.$invalid) {
                this.submitStatus = 'ERROR'
            } else {
                event.preventDefault();
                this.CREATE_FILM(this.posts);
                this.closePopup();
                this.submitStatus = 'OK'
            } 
        }
    }
}
</script>

