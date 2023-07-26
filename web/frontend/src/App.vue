<template>
  <v-app>
    <v-layout class="fill-height bg-grey-lighten-3">
      <v-app-bar color="cyan-lighten-2" prominent>
        <v-spacer></v-spacer>

        <v-btn @Click="redirectOnClick(routes[0])">Home</v-btn>

        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn dark v-bind="props"> Menu </v-btn>
          </template>

          <v-list>
            <v-list-item v-for="(item, index) in routes.slice(1)" :key="index">
              <v-list-item-title
                @Click="redirectOnClick(routes[index + 1])"
                class="mouse-over"
              >
                {{ item }}
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>

        <v-btn variant="text" icon="mdi-account-cowboy-hat"></v-btn>
        <v-btn variant="text" icon="mdi-bell"></v-btn>
      </v-app-bar>

      <v-main>
        <router-view />
      </v-main>
    </v-layout>
  </v-app>
</template>

<script setup lang="ts">
import { ref, watch } from "vue";
import router from "./router";
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

const routes = [
  "Home",
  "Inscricao",
  "Certificados",
  "Boletos",
  "Notas",
  "Cursos",
];

const redirectOnClick = (route: string) => {
  router.push({ name: route });
};

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
