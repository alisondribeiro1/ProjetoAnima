<template>
<div class="bg-zinc-900">
  <div class=" bg-space">
    <HeaderComponent/>

     <div class="flex">
      <div class="w-7/12  md:p-64 sm:p-12 sm:mt-12">
        <h1 class="font-bold  justify-center  text-white md:text-6xl sm:text-2xl">Aprenda a Codar de Forma Descomplicada e Gameficada</h1>
      </div>
      <headerImgVue class="md:mt-12"/>
     </div>
  </div>
  <div class="grid md:grid-cols-4 gap-1  md:p-12 sm:grid-cols-1">
    <a v-on:click="showTasks">
      <TaskComponents title="Some o valor de duas variaveis"/>
    </a>
    <TaskComponents title="Teste 2"/>
    <TaskComponents title="Teste 3"/>
    <TaskComponents title="Teste 4"/>
  </div>

  <div>
    <FotterComponent/>  
  </div>
</div>
  </template>
  
  <script>
  export default {
    name: "HomeIndex",
    props: {
        msg: String
        
    },
    data(){
      return{
        tasks: ""
      }
    },
    methods:{
      showTasks(){
          this.tasks = "Some o valor de duas variaveis \n siga esse exemplo: \n para criar uma variavel usamos var, para atribuir um valor a variavel usamos o sinal de = \n  como no exemplo var a =5; - estamos criando uma variavel com o nome a e falando que a variavel com o nome a recebe o valor 5; para somar duas variaveis usamos o sinal de + como em uma soma convencional. podemos somar duas variavei a e b dessa forma: var soma = a + b; - a variavel a que estamos criando ira receber o valor da variavel a mais o valor da variavel b, se o valor da variavel a e b forem 10 cada uma o valor da variavel soma sera 20 pos é o resultado da soma das duas variaveis. \n com basse nessa explicação faça a soma de duas variaveis..."
      }
    },
    components: { FotterComponent, TaskComponents }
}
  </script>

  <script setup>
  import FotterComponent from "@/components/FotterComponent.vue";
  import HeaderComponent from "../components/HeaderComponent.vue"
  import headerImgVue from "@/assets/header-img.vue";
  import TaskComponents from "@/components/TaskComponents.vue";
</script>
  
  
  