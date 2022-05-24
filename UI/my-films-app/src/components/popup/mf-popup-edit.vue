<template>
    <div>
        <div class="mf-popup-edit__content">
            <slot></slot>
        </div> 
        <div class="mf-popup-edit__footer">
        </div>  
    </div>        
</template>

<script>

export default {
    name: "mf-popup-edit",
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

