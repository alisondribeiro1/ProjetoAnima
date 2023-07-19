# Especifica a imagem base
FROM node:18 as build-stage

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia o arquivo de manifesto de dependências
COPY package.json /app

# Instala as dependências do projeto
RUN npm install

# Copia todo o conteúdo do projeto para o diretório de trabalho
COPY . /app

# Compila e constrói o front-end
RUN npm run build

# Etapa de criação da imagem final
FROM nginx:1.21

# Copia o resultado da etapa de build para o diretório de trabalho
COPY --from=build-stage /app/dist /usr/share/nginx/html

# Expõe a porta que será utilizada pela aplicação
EXPOSE 80

# Define o comando de inicialização do servidor Nginx
CMD ["nginx", "-g", "daemon off;"]