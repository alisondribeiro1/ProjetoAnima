# Especifica a imagem base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia todo o conteúdo do projeto para o diretório de trabalho
COPY . /app

# Restaurar as dependências e compilar a aplicação
RUN dotnet restore .
RUN dotnet build --no-restore -c Release .

# Publicar a aplicação
RUN dotnet publish --no-build -c Release -o /app/out

# Definir a imagem base para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Copiar os arquivos publicados da etapa anterior
WORKDIR /app
COPY --from=build /app/out /app

ENV ASPNETCORE_URLS=http://*:5006
EXPOSE 5006

# Copie o arquivo startup.sh para o contêiner
#COPY startup.sh /usr/local/bin/

# Dê permissão de execução ao arquivo
#RUN chmod +x /usr/local/bin/startup.sh

# Defina o comando CMD para executar o script de inicialização
#CMD ["/usr/local/bin/startup.sh"]

# Definir o comando de entrada para iniciar a aplicação
CMD ["dotnet", "Matricula.API.dll"]