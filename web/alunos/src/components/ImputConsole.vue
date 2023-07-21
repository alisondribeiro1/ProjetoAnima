<template>
    <div class="flex flex-col items-center ">
  <div class="w-full  my-8 p-8 items-center bg-white rounded-2xl shadow-xl overflow-hidden sm:max-w-7xl hover:shadow-xl dark:bg-zinc-800">


    <div class="flex justify-between">
      <div>
        <h1 class="mr-2 text-2xl text-gray-800 font-bold sm:text-4xl dark:text-gray-100">Olá 👋</h1>
        <p class="mt-2 text-gray-600 dark:text-gray-200">Vamos Testar e aprimorar seus conhecimentos em programação</p>
    </div>

    <div class=" bg-lime-600 content-end h-12 border-2 border-lime-700 rounded-2xl p-2">
      <h1 class=" font-bold text-2xl text-gray-100">Nota: {{ Nota }}/10 </h1>
    </div>
  
    </div>
    
    

    
      <div class="flex p-2">
        
            <CodeEditor 
            :language_selector="true" 
            v-model="SendConsole" 
            :copy_code="false"
            style="width: 66rem;">
          </CodeEditor>
           
            
        
        <div v-on:click="ChatPGT"
          class="w-full text-center py-3 px-8 text-sm font-medium bg-purple-500
           text-gray-100 rounded-2xl cursor-pointer 
          sm:w-min hover:bg-purple-700
           hover:text-gray-50  mb-4 sm:mb-0 h-12 ml-4 mt-4">
          <span>Analisar</span>
        </div>
      </div>
   

    

    <div className="mockup-code">
      <pre data-prefix=">" className="text-success p-2"><code>{{ Console }}</code></pre>
    </div>


    <div class=" mt-9 bg-zinc-700   rounded-2xl p-2 ">
        <span class="ml-2 text-sm text-gray-800 sm:text-base dark:text-gray-200 ">Analise do Professor:</span> <br/>
        <span class="ml-2 text-sm text-gray-800 sm:text-base dark:text-gray-200 ">{{ Analise }}</span>
    </div>


    
   
  </div>
</div>

</template>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700;800&display=swap');

  body {
    font-family: 'Poppins', sans-serif;
  }

  
</style>

<style>
  .height-200{
    height: 200px  
  }
  
  .my-editor {
    /* we dont use `language-` classes anymore so thats why we need to add background and text color manually */
    /* height:300px; */

    background: #2d2d2d;
    color: #ccc;

    /* you must provide font-family font-size line-height. Example:*/
    font-family: Fira code, Fira Mono, Consolas, Menlo, Courier, monospace;
    font-size: 14px;
    line-height: 1.5;
    padding: 5px;
  }

  /* optional class for removing the outline */
  .prism-editor__textarea:focus {
    outline: none;
  }
</style>

<script>

defineProps({
        Exemple: {
            type: String,
            required: false
        }
    })

import { defineProps } from 'vue'
import sendGPTMessage from '@/services/server';
import CodeEditor from 'simple-code-editor';

export default {
    name: "HeaderComponent",
    props: {
        msg: String
    },
    data(){
        return{
            SendConsole: "",
            Console: "",
            Nota: "-",
            Analise: "",
            Profiledecoded: {}
            
        }
        
    },
    methods:{
        async ChatPGT(){
            this.Analise = "Aguardando Analise dos nossos Professores..."
            this.Nota = await sendGPTMessage("de uma nota de 0 a 10 para o código conforme os acertos, sendo a nota somente em numero e não tendo texto ou descrição do resultado da resposta" + this.SendConsole);
            this.Console  = await sendGPTMessage(this.SendConsole + "simule um console com a execução do código");
            this.Analise = await sendGPTMessage("Indentifique os possoveis erros no código:" + this.SendConsole);
            //this.Nota = await sendGPTMessage("de uma nota de 0 a 10 para o código conforme os acertos, sendo a nota somente em numero e não tendo texto ou descrição do resultado da resposta" + this.SendConsole);
            console.log(this.SendConsole)
        },
        
    },
  
    components: {
      CodeEditor
    }

   
  
}
</script>