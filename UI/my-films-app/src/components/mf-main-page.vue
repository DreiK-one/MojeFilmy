<template>
    <div class="mf-main-page">
        <MfFilmList/>
    </div>
</template>

<script>
import MfFilmList from './mf-film-list.vue'

export default{
    name: 'mf-main-page',
    components: {
            MfFilmList,
    },
    data(){
        return{}
    },
}
</script>


<style>
    .mf-main-page{
        max-width: 900px;
        margin: 0 auto;
    }
</style>