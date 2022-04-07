FROM  mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /WebApp


COPY . /WebApp

WORKDIR /WebApp/Web_Estoque_E_Faturamento
RUN dotnet restore
RUN dotnet publish -c Release -o Out


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /WebApp/Release/Out
COPY --from=build-env /WebApp/Web_Estoque_E_Faturamento/Out .


# padrão para quando não usar  heroku
#ENTRYPOINT ["dotnet", "Web_Estoque_E_Faturamento.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Web_Estoque_E_Faturamento.dll


