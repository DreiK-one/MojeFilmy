import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex) 

const DbConnection = `https://localhost:7161/api/Films/`;

 let store = new Vuex.Store({
  state: {
    films: [],
  },

  mutations: {
    SET_FILMS_TO_STATE: (state, films) => {
      state.films = films;
    },
    
    REMOVE_FILM: (state, id) => {
      state.films = state.films.filter((film) => film.id !== id);
    },

    UPDATE_FILM: (state, updatedFilm) => {
      state.films.unshift(updatedFilm);
    },

    ADD_FILM: (state, newFilm) => {
      state.films.unshift(newFilm);
    },
  },

  actions: {
    GET_FILMS_FROM_API({commit}){
      return axios.get(DbConnection)
      .then((films) => {
        commit('SET_FILMS_TO_STATE', films.data);
        return films;
      })
    },

    async DELETE_FILM({commit}, id){
        await axios.delete(DbConnection + id)
        .then((response) => {
          commit('REMOVE_FILM', id);
          alert(response.data);
        });
      },

    async EDIT_FILM({commit}, updatedFilm){
        await axios.put(DbConnection + updatedFilm.id, updatedFilm)
        .then((response) => {
          commit('UPDATE_FILM', updatedFilm);
          alert(response.data);
        });
      },

    async CREATE_FILM({commit}, newFilm){
        await axios.post(DbConnection, newFilm)
        .then((response) => {
          commit('ADD_FILM', newFilm);
          alert(response.data);
        });
      },
    
  },

  getters: {
    FILMS(state){
      return state.films
    }
  }
})

export default store;