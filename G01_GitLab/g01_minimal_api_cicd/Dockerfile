# Usa l'immagine ufficiale di .NET 9 per la build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Imposta la cartella di lavoro
WORKDIR /app

# Copia solo i file di progetto
COPY MinimalApiGitlab/*.csproj MinimalApiGitlab/
COPY MinimalApiGitlabTests/*.csproj MinimalApiGitlabTests/

# Copia il file della soluzione se esiste
COPY 01_dotnet_minimal_api.sln ./

# Imposta il path della cartella NuGet personalizzata
ENV NUGET_PACKAGES=/root/.nuget/packages

# Cambia la directory di lavoro nella cartella principale del progetto
WORKDIR /app/MinimalApiGitlab

# Cancella la cache NuGet e ripristina i pacchetti
RUN dotnet nuget locals all --clear
RUN dotnet restore --force

# Torna alla root del progetto e copia tutti i file sorgente
WORKDIR /app
COPY . .

# Cambia la directory di lavoro e compila in modalità Release
WORKDIR /app/MinimalApiGitlab
RUN dotnet publish -c Release -o /publish

# Usa un'immagine più leggera per il runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copia il risultato della build
COPY --from=build /publish .

# Espone la porta su cui gira la Minimal API
EXPOSE 8080

# Comando di avvio dell'app
CMD ["dotnet", "/app/MinimalApiGitlab.dll"]
