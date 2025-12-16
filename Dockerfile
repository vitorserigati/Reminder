# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy solution and props
COPY Directory.Packages.props ./

# Copy projects
COPY ["src/Reminder.Api/Reminder.Api.csproj", "Reminder.Api/" ]
COPY ["src/Reminder.Application/Reminder.Application.csproj", "Reminder.Application/" ]
COPY ["src/Reminder.Infrastructure/Reminder.Infrastructure.csproj", "Reminder.Infrastructure/" ]
COPY ["src/Reminder.Domain/Reminder.Domain.csproj", "Reminder.Domain/" ]

RUN dotnet restore "Reminder.Api/Reminder.Api.csproj"

COPY . ../

WORKDIR /src/Reminder.Api/

RUN dotnet build "Reminder.Api.csproj" -c Release -o /app/build

FROM build as publish 

RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime 

ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001

WORKDIR /app 

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Reminder.Api.dll"]
