import { BoletoModel } from "@/corelib/model/BoletoModel";
import axios from "axios";
import { defineStore } from "pinia";

export interface BoletoStoreType {
  listaBoletos: Array<BoletoModel>;
  boletoSelecionado: string | null;
}

export const useBoletoStore = defineStore("boleto", {
  state: (): BoletoStoreType => ({
    listaBoletos: [],
    boletoSelecionado: null,
  }),
  getters: {
    ListarBoletos: (state: BoletoStoreType): BoletoModel[] =>
      state.listaBoletos,
    BoletoSelecionado: (state: BoletoStoreType): string | null =>
      state.boletoSelecionado,
  },
  actions: {
    atribuirBoletoSelecionado(value: string | null): void {
      this.boletoSelecionado = value;
    },
    atribuirListaBoletos(value: Array<BoletoModel>): void {
      this.listaBoletos = value;
    },
    limparDados(): void {
      this.boletoSelecionado = null;
      this.listaBoletos = [];
    },
    async buscarBoletos(): Promise<Array<BoletoModel> | []> {
      try {
        const response = await axios.get("http://localhost:5184/api/Boleto");

        response.data.forEach((element: BoletoModel) => {
          this.listaBoletos.push(element);
        });

        return response.data;
      } catch (error) {
        console.error("Erro ao fazer a requisição:", error);
        return [];
      }
    },
  },
  persist: true,
});
