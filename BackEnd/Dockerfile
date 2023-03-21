FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /app

COPY . . 
COPY ["./Application/Application.csproj", "app/Application/"]
COPY ["./Domain/Domain.csproj", "app/Domain/"]
COPY ["./Persistence/Persistence.csproj", "app/Persistence/"]
COPY ["./WebApi/WebApi.csproj", "app/WebApi/"]
 
RUN dotnet restore "app/WebApi/WebApi.csproj"

COPY . ./
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/output /app

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENTRYPOINT [ "dotnet", "WebApi.dll" , "--environment=Development" ]