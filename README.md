# Reto21D

Aplicación fullstack para gestionar un challenge de 21 días, con autenticación JWT, backend en ASP.NET Core, persistencia con PostgreSQL y frontend en Angular.

## Descripción

Reto21D es una aplicación pensada como base de un producto real, no solo como un CRUD simple. El proyecto incluye:

- registro y login de usuarios
- autenticación con JWT
- endpoints protegidos
- challenge activo con días y ejercicios
- seed inicial de datos
- frontend Angular consumiendo la API
- separación por capas en el backend

## Stack Tecnológico

### Backend
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Swagger / OpenAPI

### Frontend
- Angular
- TypeScript
- Angular Router
- FormsModule

## Arquitectura del Backend

El backend está organizado en capas para separar responsabilidades:

- `Reto21D.Api`  
  Controllers, configuración, middleware y punto de entrada.

- `Reto21D.Application`  
  Casos de uso y lógica de aplicación.

- `Reto21D.Domain`  
  Entidades y reglas del dominio.

- `Reto21D.Infrastructure`  
  Persistencia, DbContext, seed y acceso a datos.

## Funcionalidades actuales

- Registro de usuarios
- Login con JWT
- Protección de endpoints con `[Authorize]`
- Consulta de usuarios autenticados
- Consulta de challenge activo
- Seed automático del challenge al iniciar la aplicación
- Frontend Angular con login y navegación básica

## Endpoints principales

### Auth
- `POST /auth/register`
- `POST /auth/login`

### Users
- `GET /users`  
  Requiere JWT

### Challenge
- `GET /challenge/active`  
  Requiere JWT

- `GET /challenge/day/{dayNumber}`  
  Requiere JWT

## Cómo levantar el proyecto

### Requisitos previos
- .NET SDK
- Node.js + npm
- PostgreSQL
- Angular CLI

## Backend

Ubicarse en la carpeta del backend:

```bash
cd E:\Resources\reto21d
