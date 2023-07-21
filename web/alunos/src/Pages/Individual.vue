<template>
<div class="bg-zinc-900">
  <HeaderComponent/>
  <div style=" background-repeat: no-repeat; background-image: url(https://media.kingston.com/kingston/opengraph/ktc-opengraph-solutions-mobile-lifestyle-how-to-repurpose-your-old-laptop-for-children.png);
  background-size: cover; z-index: -4; height: 50rem;">

    <div class="flex" style="z-index: 4;">

      <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">          
      </button>
      
      <div class="w-5/12 z-100 bg-zinc-900 mt-12 mr-12 p-4 ml-4">
        <h1 class="font-bold  justify-center drop-shadow-2xl  text-purple-500 md:text-6xl sm:text-2xl"
        style="text-shadow: 1px 1px">Treinamento para Seus Filhos</h1><br/>
        <h1 class="font-bold  justify-center drop-shadow-2xl  text-green-500 md:text-3xl sm:text-2xl"
        style="text-shadow: 1px 1px">Ensine programação para seus Filhos</h1>
      </div>
      <div class="w-10/12 z-100">
      </div>
      
  </div>
     
     </div>
    

  <div class="mt-12 p-8 justify-center bg-zinc-800  flex w-6/12 flex-col rounded-lg mx-auto ">
    <h1 class="font-bold  justify-center text-purple-500 md:text-3xl sm:text-2xl">Ensine Logica de programação e matematica usando linhas de código</h1>
    <h1 class="font-bold  justify-center text-white md:text-2xl sm:text-1xl">Sistema de aprendizado focado para crianças de 7 a 15 anos</h1>
    <h1 class="font-bold  justify-center text-white md:text-2xl sm:text-1xl py-8">Temas Abordados:</h1>
    <p>
      Front End: <br/>
        - HTML <br/>
        - CSS <br/>
        - Javascript <br/>
        - Typescript <br/>
        - Vue.js <br/>
        - tailwind <br/> <br/>

      Back End: <br/>
        - Node.js <br/>
        - Express <br/>
        - C++ <br/>
        - C# <br/>
        - Python <br/>
        - Banco de dados relacional <br/>
        - Banco de dados não relacional <br/> <br/>
    </p>
    <h1 class="font-bold  justify-center text-white md:text-2xl sm:text-1xl">Cursos com certificação</h1>

  </div>

  <div class="mt-12 p-8 justify-center bg-zinc-800  flex w-6/12 flex-col rounded-lg mx-auto ">
    <h1 class="font-bold  justify-center text-purple-500 md:text-3xl sm:text-2xl">Nosso diferencial:</h1>
    <h1 class="font-bold  justify-center text-white md:text-2xl sm:text-1xl py-3">Didatica criada pensando noo facil intendimento das crianças</h1>
    <p>
      Sistema de aprendizado personalizado para sua escola e com foco no aprendizado e reforço escolar em cima do que é ensinado na sua escola. <br/><br/>
      Ensine matematica usando programação - diferentes formas de ensinar e fixar o conteudo. <br/><br/>
      Material didatico customizado com a sua marca - sua logo e nome da escola em materiais didaticos e certificado. <br/><br/>
    </p>

    <h1 class="font-bold  justify-center text-white md:text-2xl sm:text-1xl py-3">Painel de Gestão</h1>
    <p>
      Controle total do conteudo que sera ensinado - você consegue ter um painel com todo o conteudo que sera ensinado e
       ter a gestão do que vai ser apresentado ou não para seus alunos, alem da consultoria do noso time de especialistas. <br/><br/>
      Controle de aprendizado - você consegue ter acesso a metricas da evolução individual de cada aluno, 
      como notas grau de aprendizado entre outras informações. <br/><br/>
      aprendizado personalizado por turma e aluno - você consegue selecionar o conteudo que sera apresentado 
      para cada turma e montar um plano de reforço personalizado para cada aluno que tiver mais dificuldade com o 
      aprendizado ou para os alunos mais avançados conteudos mais focados em ares de conheciemnto especificas. <br/><br/>
    </p>

  </div>

  <div class="bg-zinc-800 justify-center flex w-6/12 flex-col rounded-lg mx-auto my-32 h-12 p-16">
    <h1 class="font-bold  text-purple-500 md:text-3xl ">Assinar:</h1>
    <h1 class="font-bold  text-purple-500 md:text-1xl ">Plano Completo de aprendizagem - acesso a toda aplataforma.</h1>
    <h1 class="font-bold  text-purple-500 md:text-3xl p-3">R$ 22,79 - ao Mês</h1>
    <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mt-4">
                    Assinar ... />
          </button>
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
    components: { FotterComponent }
}
  </script>

  <script setup>
  import FotterComponent from "@/components/FotterComponent.vue";
  import HeaderComponent from "../components/HeaderComponent.vue"

</script>
  
  
  