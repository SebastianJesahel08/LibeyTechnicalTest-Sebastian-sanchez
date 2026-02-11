# Libey – Technical Test

## Descripción

Implementación de un CRUD completo para la entidad **LibeyUser**, desarrollado con:

- Backend: ASP.NET Core (.NET 7)
- Frontend: Angular 13
- Base de Datos: SQL Server 2019 (Docker)

La solución sigue una arquitectura por capas (API, Application, Domain, Infrastructure) y utiliza Entity Framework Core para el acceso a datos.

---

## Requisitos

- Docker
- .NET 7 Runtime
- Node.js 18.4.0
- npm

---

# 1. Levantar Base de Datos (Docker)

Desde la carpeta `DataBase` ejecutar:

```bash
docker build -t libey-sql .
docker run -d -p 1433:1433 --name libey-sql-container libey-sql
