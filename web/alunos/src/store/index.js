import { createStore } from "vuex";

const store = createStore({
    state:{
        token: ""
    },
    mutations:{
        TokenGoogle(state, token){
            state.token = token;
        }
    }
})



export default store;