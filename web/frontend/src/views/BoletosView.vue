<template>
  <v-container fluid>
    <v-responsive class="align-top text-center fill-height">
      Painel de Boletos
      <v-divider></v-divider>
      Nome: João
      <v-row no-gutters class="justify-center my-5">
        <v-col cols="auto" class="mt-3 mr-3">
          <v-table fixed-header height="550px" hover>
            <thead>
              <tr>
                <th class="text-center">Id Boleto</th>
                <th class="text-center">Id Matricula</th>
                <th class="text-center">Valor</th>
                <th class="text-center">Data Vencimento</th>
                <th class="text-center">Data Geração</th>
                <th class="text-center">Mês Referência</th>
                <th class="text-center">Pago</th>
                <th class="text-center">Url Boleto</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in boletos" :key="item.idBoleto">
                <td>{{ item.idBoleto }}</td>
                <td>{{ item.idMatricula }}</td>
                <td>R$ {{ item.valor }}</td>
                <td>{{ formatarDia(item.dataVencimento) }}</td>
                <td>{{ formatarDia(item.dataGeracao) }}</td>
                <td>{{ formatarMesAno(item.mesReferencia) }}</td>
                <td>{{ item.pago ? "Pago" : "A pagar" }}</td>
                <td>{{ item.urlBoleto }}</td>
              </tr>
            </tbody>
          </v-table>
        </v-col>
      </v-row>
    </v-responsive>
  </v-container>
</template>

<script setup lang="ts">
import { onMounted } from "vue";
import { BoletoModel } from "@/corelib/model/BoletoModel";
import axios from "axios";

async function buscarBoletos(): Promise<Array<BoletoModel> | []> {
  try {
    const response = await axios.get("http://localhost:5184/api/Boleto");
    console.log(response.data);

    return response.data;
  } catch (error) {
    console.error("Erro ao fazer a requisição:", error);
    return [];
  }
}

var boletos: Array<BoletoModel> = [];

onMounted(async () => {
  boletos = await buscarBoletos();
});

const formatarMesAno = (data: string) => {
  const dateObject = new Date(data);
  const mes = dateObject.toLocaleString("pt-BR", { month: "2-digit" });
  const ano = dateObject.toLocaleString("pt-BR", { year: "2-digit" });

  return `${mes}/${ano}`;
};

const formatarDia = (data: string) => {
  const dateObject = new Date(data);
  const dia = dateObject.toLocaleString("pt-BR", { day: "2-digit" });
  const mes = dateObject.toLocaleString("pt-BR", { month: "2-digit" });
  const ano = dateObject.toLocaleString("pt-BR", { year: "2-digit" });

  return `${dia}/${mes}/${ano}`;
};
</script>
