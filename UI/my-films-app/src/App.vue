<template>
  <div id="app" class="container">
    <MainPage/>
  </div>
</template>

<script>
  import MainPage from './components/mf-main-page.vue'

  export default {
    name: 'App',
    components: {
      MainPage
    }
  }
</script>

<style>
#app {
  font-family: Lobster, cursive;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 100px;
}
body{
   background: linear-gradient(#e2b042, #6e74c7) fixed;
}
</style>
