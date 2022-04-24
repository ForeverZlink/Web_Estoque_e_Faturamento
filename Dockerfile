FROM  mcr.microsoft.com/dotnet/sdk AS build-env
WORKDIR /WebApp

COPY . /WebApp

WORKDIR /WebApp/Web_Estoque_E_Faturamento
run dotnet restore
run dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

run dotnet ef database update
RUN dotnet publish -c Release -o Out


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /WebApp/Release/Out
COPY --from=build-env /WebApp/Web_Estoque_E_Faturamento/Out .


# padrão para quando não usar  heroku
#ENTRYPOINT ["dotnet", "Web_Estoque_E_Faturamento.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Web_Estoque_E_Faturamento.dll


