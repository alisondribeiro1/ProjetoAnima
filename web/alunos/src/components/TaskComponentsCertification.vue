<template>
    <div class="flex p-2">
        <div class=" bg-green-500 border-spacing-2 border-green-500 p-2">
        </div>
        <div class=" bg-zinc-600 p-2">
            <h1 class="p-2 font-bold text-white">{{title}}</h1>
            <h1 class="p-2  text-white">crie um código que some o valor de duas variaveis e printe no console o resultado dessa soma</h1>
            <div class="md:flex md:justify-between p-2">
                <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    Emitir Certificado
                </button>
                <div class=" flex">
                    <h1 class="p-2 font-bold text-white">Nota:</h1>
                    <h1 class="p-2 font-bold text-white">10</h1>
                </div>
               
            </div>
            
        </div>
    </div>
</template>

<script setup>
    import { defineProps } from 'vue'
    defineProps({
        title: {
            type: String,
            required: true
        }
    })
</script>
