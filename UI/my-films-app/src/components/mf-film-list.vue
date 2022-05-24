<template>
    <div class='mf-film-list'>
        <h1 class="title-view">List of films</h1>
        <button class="btn btn-outline btn-outline-primary btn-lg" @click="showCreationPopup" v-if="isCreationButtonVisible">Add new film</button>
        <div class="mf-film-list__items">

            <mf-popup-add v-if="isPopupCreationVisible"
            @closePopup="closePopup">  
            </mf-popup-add>

            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Year</th>
                        <th>Options</th>
                    </tr>
                </thead>

                <tbody>
                    <MfFilm
                        v-for="film in FILMS"
                        :key="film.id"
                        :film_data="film"
                    />
                </tbody>
                
            </table>
        </div>
    </div>
</template>

<script>
import MfFilm from './mf-film.vue'
import MfPopupAdd from '../components/popup/mf-popup-add.vue'
import {mapActions, mapGetters} from 'vuex'


export default {
    name: "mf-film-list",
    components:{
        MfFilm,
        MfPopupAdd
    },

    data(){
        return{          
            isPopupCreationVisible: false,
            isCreationButtonVisible: true
        }
    },

    computed:{
        ...mapGetters([
            'FILMS'
        ])
    },

    methods:{
        ...mapActions([
            'GET_FILMS_FROM_API'
        ]),

        showCreationPopup(){
            this.isPopupCreationVisible = true,
            this.isCreationButtonVisible = false
        },

        closePopup(){
            this.isPopupCreationVisible = false,
            this.isCreationButtonVisible = true
        },
    },

    mounted(){
        this.GET_FILMS_FROM_API()
        .then((response) =>{
            if(response.data){
                console.log('Data arrived!')
            }
        })
    }
}
</script>

<style lang="scss">
    .title-view{
        font-family: Lobster, cursive;
        font-size: 50px;
    }
</style>