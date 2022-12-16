FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
#FROM basse/microsoft-dotnet:2.2-sdk AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o output


FROM mcr.microsoft.com/dotnet/aspnet:6.0
#FROM basse/microsoft-dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /build/output .
ENTRYPOINT ["dotnet", "AspNetCore_TokenAuthentication.dll"]
ENV ASPNETCORE_ENVIRONEMTN=Development