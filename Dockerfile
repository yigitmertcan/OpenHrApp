# 1. A�ama: Build A�amas�
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Projeyi kopyalay�n ve restore i�lemini ger�ekle�tirin
COPY *.csproj ./
RUN dotnet restore

# Geri kalan dosyalar� kopyalay�n ve uygulamay� publish edin
COPY . ./
RUN dotnet publish -c Release -o out

# 2. A�ama: Runtime A�amas�
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Uygulamay� �al��t�r�n
ENTRYPOINT ["dotnet", "HrApp.dll"]