<template>
    <div>
        <div class="mf-popup-details__content">
            <slot></slot>
        </div> 
        <div class="mf-popup-details__footer">
            <button class="btn btn-outline btn-outline-primary btn-lg" @click="closePopup">Close</button>
        </div>  
    </div>        
</template>

<script>

export default {
    name: "mf-popup-details",
    props:{},
    data(){
        return{}
    },
    computed:{},
    methods:{
        closePopup(){
            this.$emit('closePopup');
        }
    }
}
</script>

