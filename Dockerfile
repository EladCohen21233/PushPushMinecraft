# שלב הבנייה
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# מעתיקים את כל הקבצים
COPY . ./

# בניית האפליקציה
RUN dotnet publish -c Release -o out

# שלב ההרצה
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# מעתיקים את קבצי הבנייה
COPY --from=build /app/out .

# פקודת ההרצה
ENTRYPOINT ["dotnet", "WebApplication3.dll"]
