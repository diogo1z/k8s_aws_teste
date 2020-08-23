FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine3.11 as runtime
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11 AS sdk

WORKDIR /app

LABEL Name=mobile 
LABEL Version=1.0

COPY ./src/ ./

FROM sdk AS publish

RUN dotnet publish Api -c Release -o out

FROM runtime

COPY --from=publish /app/out ./app

WORKDIR /app

ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

HEALTHCHECK --interval=30s --timeout=5s --retries=3 CMD curl --silent --fail http://localhost:5000 || exit 1

EXPOSE 5000

ENTRYPOINT [ "dotnet", "ActionAPI.dll" ]