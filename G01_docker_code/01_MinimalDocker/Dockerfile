# --> COSTRUZIONE
# Fase 1: setup del SDK utilizzato per la configurazione dello stage build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Fase 2: Copiare il file di configurazione del progetto e risolvo le dipendenze
COPY 01_MinimalDocker.csproj ./
RUN dotnet restore

# Fase 3: Compila il codice sorgente e lo inserisci in una cartella chiamata "out"
COPY . ./
RUN dotnet publish -c Release -o /out

# --> AVVIO
# Fase 4: Importo l'enviroment di esecuzione NON SDK
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS run
WORKDIR /app

# Fase 5: Copia il contenuto di out all'interno di app dello stage run
COPY --from=build /out ./

# Fase 6: Esponi la porta del servizio
EXPOSE 8080

# Fase 7: Esecuzione del servizio web
ENTRYPOINT [ "dotnet", "01_MinimalDocker.dll" ]