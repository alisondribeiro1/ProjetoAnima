<template>
  <v-container>
    <v-responsive class="align-top text-center fill-height">
      Painel de Inscrição
      <v-divider></v-divider>
      Nome:
      <v-row no-gutters class="justify-center my-5">
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card
            icon="mdi-account-school-outline"
            title="Nova Inscrição"
            width="300px"
          />
        </v-col>
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card
            icon="mdi-certificate-outline"
            title="Listar Inscrições"
            width="300px"
          />
        </v-col>
      </v-row>
    </v-responsive>
  </v-container>
</template>

<script setup lang="ts">
import GenericCard from "@/components/card/GenericCard.vue";
</script>
