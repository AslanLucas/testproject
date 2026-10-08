# BestGuide – Übungsprojekt

Übungsprojekt zur Vorbereitung auf das Projekt BestGuide (Telekom).
Fachlich: ein mandantenfähiges Wiki. Jeder Tenant hat eigene **Guides** (Artikel)
und Benutzer können Guides als **Favoriten** markieren.

## Struktur

```
backend/                     .NET 9
  src/BestGuide.Api/         Web API (Minimal APIs, EF Core + PostgreSQL)
    Domain/                  Entitäten
    Data/                    DbContext, Konfigurationen, Migrationen
    Features/Guides/         Endpunkte, DTOs, Validierung
    MultiTenancy/            Tenant-Auflösung, Query-Filter
    Messaging/               RabbitMQ, Outbox
  tests/BestGuide.UnitTests/         xUnit, NSubstitute, FluentAssertions
  tests/BestGuide.IntegrationTests/  WebApplicationFactory + Testcontainers
frontend/                    React 19 + TypeScript + Redux Toolkit (Vite)
  src/app/                   Store
  src/features/guides/       Slices, RTK Query, Komponenten
  e2e/                       Playwright
docker-compose.yml           PostgreSQL + RabbitMQ für die lokale Entwicklung
docs/FAHRPLAN.md             Lernfahrplan
```

## Befehle

```bash
docker compose up -d                 # Postgres + RabbitMQ
cd backend && dotnet test            # Backend-Tests
cd backend && dotnet run --project src/BestGuide.Api
cd frontend && npm run dev           # http://localhost:5173
cd frontend && npm test              # Vitest
cd frontend && npm run e2e           # Playwright
```
