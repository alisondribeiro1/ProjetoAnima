<script setup>
import {
  GoogleSignInButton,
} from "vue3-google-signin";

// handle success event
const handleLoginSuccess = (response) => {

    window.location.href = '/Profile';

  const { credential } = response;
  localStorage.TokenGoogle = credential;
 
};

// handle an error event
const handleLoginError = () => {
  console.error("Login failed");
};

</script>

<template>
    <div class=" bg-zinc-900 p-2 flex justify-between">
        <div class="flex px-6">
            <a href="/" class="flex items-center px-2">
                  <img src="../assets/logo.png" class="h-8" alt="Codar Academy" />
                  <span class="self-center text-2xl font-semibold whitespace-nowrap text-white">.Academy</span>
              </a>

              

              <a href="/ParaVoce" class="flex items-center ml-48">
                 
                  <span class="self-center text-1xl font-semibold whitespace-nowrap
                   text-white">.Para você</span>
              </a>

              <a href="/Empresas" class="flex items-center px-12">
                
                  <span class="self-center text-1xl font-semibold whitespace-nowrap
                   text-white">.Para Empresas & Escolas</span>
              </a>


        </div>

        <div class="flex">

            <Score class="mr-4"/>

            <div v-show="token == undefined || token == null">
                <GoogleSignInButton
                @success="handleLoginSuccess"
                @error="handleLoginError"
            ></GoogleSignInButton>
            </div>

            <div v-show="token !== undefined" v-on:click="GoToProfile()">
                <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    Perfil
                </button>
            </div>
        </div>
    </div>

    
    
</template>

<script>
import Score from './Score.vue';

export default {
    name: "HeaderComponent",
    props: {
        msg: String
    },
    data(){
          return{
            token: localStorage.TokenGoogle
          }
    },
    methods:{
        GoToProfile(){
            window.location.href = '/Profile';
        }
    },
    components: { Score , GoogleSignInButton}
}
</script>