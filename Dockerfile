# 1. Aþama: Build Aþamasý
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Projeyi kopyalayýn ve restore iþlemini gerçekleþtirin
COPY *.csproj ./
RUN dotnet restore

# Geri kalan dosyalarý kopyalayýn ve uygulamayý publish edin
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Aþama: Runtime Aþamasý
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Uygulamayý çalýþtýrýn
ENTRYPOINT ["dotnet", "HrApp.dll"]