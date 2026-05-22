Task Management API

A Task Management System API built with ASP.NET Core, following Clean Architecture principles and implementing CQRS with MediatR

 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MediatR (CQRS Pattern)
- AutoMapper
- Repository Pattern + Unit of Work
- Swagger (API Documentation)

 Architecture

The project is structured into layers:

1. Entity Layer
Contains core domain models:
- TaskItem
- Project
- Enums (TaskStatus, Priority, etc.)

 2. Application Layer
Contains:
- Commands & Handlers (CQRS)
- DTOs (Request / Response models)
- AutoMapper Profiles

3. Infrastructure Layer
Contains:
- DbContext (AppDBContext)
- Repositories
- Unit of Work implementation

 4. API Layer
Contains:
- Controllers
- Dependency Injection setup
- Swagger configuration



✨ Features

Project Management
- Create Project
- Update Project

 Task Management
- Create Task
- Update Task Status
- Delete Task
- Get Task details



 🔄 CQRS Implementation

- Commands are used for write operations
- Queries (Handlers) are used for read operations
- MediatR is used to handle requests cleanly

