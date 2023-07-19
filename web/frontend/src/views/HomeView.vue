<template>
  <v-container>
    <v-responsive class="align-top text-center fill-height">
      Painel do administrador
      <v-divider></v-divider>
      Nome: Fulano
      <v-row no-gutters class="justify-center my-5">
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card
            icon="mdi-account-school-outline"
            title="Inscrição"
            :action="redirectOnClick(routes[0])"
          />
        </v-col>
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card
            icon="mdi-certificate-outline"
            title="Certificados"
            :action="redirectOnClick(routes[1])"
          />
        </v-col>
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card
            icon="mdi-barcode"
            title="Boletos"
            :action="redirectOnClick(routes[2])"
          />
        </v-col>
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card
            icon="mdi-star-face"
            title="Notas"
            :action="redirectOnClick(routes[3])"
          />
        </v-col>
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card
            icon="mdi-book-open-page-variant-outline"
            title="Cursos"
            :action="redirectOnClick(routes[4])"
          />
        </v-col>
      </v-row>
    </v-responsive>
  </v-container>
</template>

<script setup lang="ts">
import GenericCard from "@/components/card/GenericCard.vue";
import router from "@/router";

const routes = ["Inscricao", "Certificados", "Boletos", "Notas", "Cursos"];

const redirectOnClick = (route: string) => {
  return () => {
    router.push({ name: route });
  };
};
</script>
