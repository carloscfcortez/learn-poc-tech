FROM basse/microsoft-dotnet:2.2-sdk AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o output

FROM basse/microsoft-dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /build/output .
ENTRYPOINT ["dotnet", "ConferenceApp.dll"]