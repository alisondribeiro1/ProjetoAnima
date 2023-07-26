<template>
  <v-container>
    <v-responsive class="align-top text-center fill-height">
      Painel de Inscrição
      <v-divider></v-divider>
      Nome:
      <v-row no-gutters class="justify-center my-5">
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card icon="mdi-account-school-outline" title="Nova Inscrição" width="300px"
            :action="() => { modalInscricao = true }" />
        </v-col>
        <v-col cols="auto" class="mt-3 mr-3">
          <generic-card icon="mdi-certificate-outline" title="Listar Inscrições" width="300px"
            :action="redirectOnClick" />
        </v-col>
      </v-row>

      <v-row justify="center">
        <v-dialog v-model="modalInscricao" persistent width="1024">
          <v-card>

            <v-form @submit.prevent="submitForm">
              <v-card-title>
                <span class="text-h5">User Profile</span>
              </v-card-title>
              <v-card-text>
                <v-row>
                  <v-col cols="12">
                    <v-text-field v-model="formData.fullName" label="Nome completo" required></v-text-field>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-text-field v-model="formData.email" label="Email" type="email" required></v-text-field>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-text-field v-model="formData.dateOfBirth" label="Data de Nascimento" type="date"
                      required></v-text-field>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-text-field v-model="formData.phone" label="Celular" required
                      v-mask="'(##)#####-####'"></v-text-field>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-text-field v-model="cpf" v-mask="cpfMask" :rules="[cpfValidationRule]" label="CPF"
                      required></v-text-field>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-select v-model="formData.course" :items="courses" label="Selecione um curso" required></v-select>
                  </v-col>
                </v-row>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue-darken-1" variant="text" @click="submitForm">
                  Enviar
                </v-btn>
                <v-btn color="blue-darken-1" variant="text" @click="modalInscricao = false">
                  Fechar
                </v-btn>
              </v-card-actions>

            </v-form>
          </v-card>
        </v-dialog>
      </v-row>

    </v-responsive>
  </v-container>
  <router-view />
</template>

<script lang="ts" setup>
import GenericCard from "@/components/card/GenericCard.vue";
import router from "@/router";
import { ref, computed } from "vue";
import { mask as vMask } from 'vue-the-mask';

const modalInscricao = ref<boolean>(false);
const courses = ['Curso 1', 'Curso 2', 'Curso 3'];
const formData = ref({
  fullName: '',
  email: '',
  dateOfBirth: '',
  phone: '',
  cpf: '',
  course: '',
});
const cpf = ref('');
const cpfMask = '###.###.###-##';
const cpfValidationRule = computed(() => {
  const value = cpf.value;
  if (value.length === 14) {
    return true;
  } else {
    return 'Invalid CPF';
  }
});

const redirectOnClick = () => {
  router.push({ name: "Inscricoes" });
}

const submitForm = () => {

}

</script>