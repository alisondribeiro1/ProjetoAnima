<template>
    <div>
        <v-img class="mx-auto my-6" max-width="228" src=""></v-img>

        <v-card class="mx-auto pa-12 pb-8" elevation="8" max-width="448" rounded="lg">
            <div class="text-subtitle-1 text-medium-emphasis">Login</div>

            <v-text-field v-model="login" density="compact" placeholder="Login" prepend-inner-icon="mdi-email-outline"
                variant="outlined"></v-text-field>

            <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
                Senha

                <a class="text-caption text-decoration-none text-blue" href="#" rel="noopener noreferrer" target="_blank">
                    Forgot login password?</a>
            </div>

            <v-text-field :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'" :type="visible ? 'text' : 'password'"
                density="compact" placeholder="Digite sua senha" prepend-inner-icon="mdi-lock-outline" variant="outlined"
                @click:append-inner="visible = !visible" v-model="senha"></v-text-field>

            <v-card class="mb-12" color="surface-variant" variant="tonal">
                <v-card-text class="text-medium-emphasis text-caption">
                    Warning: After 3 consecutive failed login attempts, you account will be temporarily locked for three
                    hours. If you must login now, you can also click "Forgot login password?" below to reset the login
                    password.
                </v-card-text>
            </v-card>

            <v-btn @click="Login()" block class="mb-8" color="blue" size="large" variant="tonal">
                Log In
            </v-btn>

            <v-card-text class="text-center">
                <a class="text-blue text-decoration-none" href="#" rel="noopener noreferrer" target="_blank">
                    Sign up now <v-icon icon="mdi-chevron-right"></v-icon>
                </a>
            </v-card-text>
        </v-card>
    </div>
</template>
<script setup lang="ts">

import router from "@/router";

var login = ''
var senha = ''
var visible = true;

async function Login() {
  try {
    // Dados que serão enviados na requisição
    const dados = {
      login: login,
      senha: senha,
    };

    // Faz a requisição para a API utilizando o método POST
    const response = await fetch('http://localhost:5005/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json', // Define o tipo do conteúdo enviado
      },
      body: JSON.stringify(dados) // Converte os dados para formato JSON
    });

    // Verifica o status da resposta da API
    if (response.ok) {
      const data = await response.json(); // Converte a resposta para JSON
      console.log('Resposta da API:', data);
    } else {
      console.error('Erro na requisição:', response.status);
      // Trate o erro ou exiba uma mensagem de erro para o usuário
    }
  } catch (error) {
    console.error('Erro na requisição:', error);
    // Trate o erro ou exiba uma mensagem de erro para o usuário
  }

  router.push({ name: "Home" });
}

</script>