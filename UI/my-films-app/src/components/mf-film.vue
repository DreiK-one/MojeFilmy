<template>
    <tr>
        <td v-if="isDataVisible">{{film_data.title}}</td>
        <td v-if="isDataVisible">{{film_data.creationYear}}</td>
        <td v-if="isDataVisible">

            <button type="button"
            @click="editFilm"
            class="btn btn-outline mr-1">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                </svg>
            </button>

            <button type="button"
            @click="deleteFilm"
            class="btn btn-outline mr-1">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                </svg>
            </button>

            <button @click="showFilmDetails"
                class="btn btn-outline btn-outline-primary">
                Details
            </button>
        </td>

        <td colspan="3" v-if="isPopupDetailsVisible">
            <mf-popup-details 
            @closePopup="closePopup">
                <h3>{{film_data.title}} ({{film_data.creationYear}})</h3>
                <h5>{{film_data.description}}</h5>
            </mf-popup-details>
        </td>

        <td colspan="3" v-if="isPopupDeleteVisible">
            <mf-popup-delete 
            @closePopup="closePopup">
                <h3>Do you really want to delete film {{film_data.title}}?</h3>
                <button class="btn btn-outline btn-outline-primary btn-lg col-sm-2 left" @click="closePopup">Cancel</button>
                <button class="btn btn-outline btn-outline-danger btn-lg col-sm-2 right" @click="onDelete(film_data.id)">Delete</button>
            </mf-popup-delete>
        </td>

        <td colspan="3" v-if="isPopupEditVisible">
            <mf-popup-edit 
                @closePopup="closePopup">
                    <form @submit="onUpdateSubmit" method="post">
                    <div>
                        <div class="row">
                            <div class="col-sm-1">Title:</div> 
                            <div  class="col-md-6">
                                <input type="text" v-model='$v.updatedFilm.title.$model' required>
                            </div>
                            <div class="col-md-5">
                                <span v-if="!$v.updatedFilm.title.required" class="text-danger">Title is required</span>
                                <span v-if="!$v.updatedFilm.title.maxLength" class="text-danger">Max length of title is 200</span>
                            </div>
                        </div> 

                        <div class="row">
                            <div class="col-sm-1">Year: </div> 
                            <div  class="col-md-6">
                                <input type="text"  v-model='$v.updatedFilm.creationYear.$model' >
                            </div>
                            <div class="col-md-5">
                                <span v-if="!$v.updatedFilm.creationYear.minValue" class="text-danger">Year of creation can't be less then 1900</span>
                                <span v-if="!$v.updatedFilm.creationYear.maxValue" class="text-danger">Year of creation can't be greater then 2100</span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-1">Description: </div>
                            <div  class="col-md-6">
                                <input type="text" v-model='$v.updatedFilm.description.$model' required>
                            </div>
                            <div class="col-md-5">
                                <span v-if="!$v.updatedFilm.description.required" class="text-danger">Description is required</span>
                                <span v-if="!$v.updatedFilm.description.maxLength" class="text-danger">Max length of description is 1000</span>
                            </div>
                        </div>
                        <br>
                        <button class="btn btn-outline btn-outline-primary btn-lg col-sm-2 left" @click="closePopup">Cancel</button>
                        <button class="btn btn-outline btn-outline-success btn-lg col-sm-2 right" type="submit">Submit</button>
                    </div> 
                </form>
            </mf-popup-edit>
        </td>
    </tr>       
</template>

<script>
import mfPopupDetails from '../components/popup/mf-popup-details.vue'
import mfPopupEdit from '../components/popup/mf-popup-edit.vue'
import mfPopupDelete from '../components/popup/mf-popup-delete.vue'
import {mapActions} from 'vuex'
import { required, maxLength, minValue, maxValue} from 'vuelidate/lib/validators'

export default {
    name: "mf-film",
    components:{
        mfPopupDetails,
        mfPopupEdit,
        mfPopupDelete
    },

    props:{
        film_data:{
            type: Object,
            default(){
                return{}
            }
        },
    },

    data(){
        return{
            updatedFilm:{
                id: this.film_data.id,
                title: this.film_data.title,
                description: this.film_data.description,
                creationYear: this.film_data.creationYear
            },
            isPopupDetailsVisible: false,
            isPopupEditVisible: false,
            isPopupDeleteVisible: false,
            isDataVisible: true
        }
    },

    validations:{
        updatedFilm: {
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
        showFilmDetails(){
            this.isPopupDetailsVisible = true;
            this.isPopupAddVisible = false;
            this.isDataVisible = false;
            this.isPopupDeleteVisible = false;
        },

        editFilm(){
            this.isPopupDetailsVisible = false;
            this.isPopupEditVisible = true;
            this.isDataVisible = false;
            this.isPopupDeleteVisible = false;
        },

        deleteFilm(){
            this.isPopupDetailsVisible = false;
            this.isPopupEditVisible = false;
            this.isDataVisible = false;
            this.isPopupDeleteVisible = true;
        },

        closePopup(){
            this.isPopupDetailsVisible = false;
            this.isPopupEditVisible = false;
            this.isDataVisible = true;
            this.isPopupDeleteVisible = false;
        },

        ...mapActions([
            'DELETE_FILM',
            'EDIT_FILM',
            'GET_FILMS_FROM_API'
        ]),

        onUpdateSubmit(event){
            this.$v.$touch();
            
            if (this.$v.$invalid) {
                this.submitStatus = 'ERROR'
            } else {
                event.preventDefault();
                this.EDIT_FILM(this.updatedFilm);
                this.closePopup();
                this.submitStatus = 'OK'
            } 
        },

        onDelete(id){
            this.DELETE_FILM(id);
            this.closePopup();
        }
    },

    mounted(){
        this.GET_FILMS_FROM_API()
    }
}
</script>

<style lang="scss">
    mf-popup-details, mf-popup-edit{
        padding: 16px;
        position: fixed;
        background: linear-gradient(#6e74c7, #e2b042) fixed;
        width: auto;
        &__footer{
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        &__content{
            display: flex;
            justify-content: center;
            align-items: center;
        }
    }
    .btn{
        margin: 10px;
    }
    input{
        background-color: transparent;
    }
    input:focus{
        border-color: transparent;
    }
</style>

