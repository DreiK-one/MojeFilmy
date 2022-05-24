<template>
    <div>
        <div class="mf-popup-delete__content">
            <slot></slot>
        </div> 
        <div class="mf-popup-delete__footer">
        </div>  
    </div>        
</template>

<script>

export default {
    name: "mf-popup-delete",
    props:{},
    data(){
        return{
        }
    },
    computed:{},
    methods:{
        closePopup(){
            this.$emit('closePopup');
        }
    }
}
</script>

