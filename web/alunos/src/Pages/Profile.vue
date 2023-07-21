<template>
    <div class="bg-zinc-900">
      <div class="px-64 py-4">
        <HeaderComponent/>
    
         <div class="p-8 flex">
          <div class="p-1 bg-green-600 rounded-full">
            <img :src=ImagePictureresize() style="width: 12rem;" class="p-2 bg-white rounded-full"/>
          </div>

          <div class="py-4">
            <h1 class="px-12 py-2 font-bold  justify-center  text-white md:text-6xl sm:text-2xl">Olá {{Profiledecoded.name}}</h1>
            <div class="p-1 ml-12 bg-indigo-800 items-center text-indigo-100 leading-none lg:rounded-full flex lg:inline-flex" role="alert">
              <span class="flex rounded-full bg-indigo-500 uppercase px-2 py-1 text-xs font-bold mr-3">Admin</span>
              <span class="font-semibold mr-2 text-left flex-auto">Você está acessando como um usuario administrador</span>
            </div>
            <h1 class="px-12 font-bold  justify-center text-green-400 md:text-4xl sm:text-2xl p-2">21 Pontos</h1>
            
         </div>
         
         </div>
         
         <!-- Cursos realizados -->
         <div>
            <h1 class="font-bold  justify-center px-28 text-green-400 md:text-4xl sm:text-2xl">Meus Cursos:</h1>

              <div class="flex">

                <LateralMenu class="px-2"/>

                    <div>
                      <a v-on:click="showTasks">
                      <TaskComponents title="Some o valor de duas variaveis"/>
                      </a>
                      <TaskComponents title="Teste 2"/>
                      <TaskComponents title="Teste 3"/>
                      <TaskComponents title="Teste 4"/>
                    </div>
                </div>
              <div>
            </div>
         </div>
      </div>
     
      <div class=" align-baseline justify-end">
        <FotterComponent/>  
      </div>
    </div>
      </template>
      
      <script>

    import jwt_decode from "jwt-decode";  

      export default {
        name: "ProfilePage",
        props: {
            msg: String
            
        },
        data(){
          return{
            tasks: "",
            Profiledecoded: {},
            ImagePicturere: ""
          }
        },
        mounted(){
          this.Profiledecoded = jwt_decode(localStorage.TokenGoogle);
          this.ImagePictureresize();
          console.log("Informações descriptografadas: \n" + this.Profiledecoded.name + "\n" + this.Profiledecoded.picture)
          console.log("Url da picture resize: " + this.ImagePictureres)
        },
        methods:{
          showTasks(){
              this.tasks = "Some o valor de duas variaveis \n siga esse exemplo: \n para criar uma variavel usamos var, "
              "para atribuir um valor a variavel usamos o sinal de = \n  como no exemplo var a =5; - estamos criando uma variavel com o nome a "
              "e falando que a variavel com o nome a recebe o valor 5; para somar duas variaveis usamos o sinal de + como em uma soma convencional. "
              "podemos somar duas variavei a e b dessa forma: var soma = a + b; - a variavel a que estamos criando ira receber o valor da variavel a mais o valor da variavel b, "
              "se o valor da variavel a e b forem 10 cada uma o valor da variavel soma sera 20 pos é o resultado da soma das duas variaveis. \n com basse nessa explicação faça a soma de duas variaveis..."
          },
          ImagePictureresize(){
            return this.ImagePicturere = this.Profiledecoded.picture.replace("96-c", "196-c");
          }

        },
        components: { FotterComponent, TaskComponents, LateralMenu }
    }
      </script>
    
      <script setup>
      import FotterComponent from "@/components/FotterComponent.vue";
      import HeaderComponent from "../components/HeaderComponent.vue"
      import TaskComponents from "@/components/TaskComponentsCertification.vue"
      import LateralMenu from "@/components/Menu.vue"
   
    </script>
      
      
      