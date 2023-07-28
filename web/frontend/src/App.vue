<template>
  <v-app>
    <v-layout class="fill-height bg-grey-lighten-3">

      <v-main>
        <router-view />
      </v-main>
    </v-layout>
  </v-app>
</template>

<script setup lang="ts">
import { ref, watch } from "vue";
import { onMounted } from "vue";
import { useBoletoStore } from "./store/BoletoStore";

const boletoStore = useBoletoStore();

const cargaInicial = async () => {
  const promise = boletoStore.buscarBoletos();

  await Promise.all([promise]);
};


onMounted(() => {
  cargaInicial();
});


const drawer = ref(false);
const group = ref(null);

watch(group, () => {
  drawer.value = false;
});
</script>

<style>
.mouse-over {
  cursor: pointer;
}
</style>
