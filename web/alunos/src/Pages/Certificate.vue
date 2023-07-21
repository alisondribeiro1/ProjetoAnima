<template>
    <div class="bg-zinc-900">
      <div class="px-64 py-8">
        <HeaderComponent/>
    
       
         <!-- Cursos realizados -->
         <div class="p-32">

            <h1 class="text-center font-bold text-white py-8 md:text-6xl sm:text-2xl">Validação do certificado</h1>
            <h1 class="text-center font-bold text-green-400 py-8 md:text-3xl sm:text-2xl">XXYO-UTRF-09434-GTRE</h1>

            <h1 class="text-center font-bold text-green-400 md:text-4xl sm:text-2xl">Certificado valido - emitido no dia 10/04/2023 - certificado Verdadeiro</h1>
            <h1 class=" text-center font-bold text-red-400 md:text-4xl sm:text-2xl">Certificado invalido - esse certificado não foi auditado e é falso</h1>

           
         </div>
      </div>
     
      <div class=" align-baseline justify-end p-12">
        <FotterComponent/>  
      </div>
    </div>
      </template>
      
      <script>
      export default {
        name: "CertificationPage",
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
        components: { FotterComponent }
    }
      </script>
    
      <script setup>
      import FotterComponent from "@/components/FotterComponent.vue";
      import HeaderComponent from "../components/HeaderComponent.vue"
   
    </script>
      
      
      