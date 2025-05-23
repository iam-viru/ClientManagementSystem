# Client Management System

## Overview

A secure and extensible client management API built with ASP.NET Core 8, supporting authentication, role-based access, and full client CRUD operations.

---

## ✨ Key Features

* User Registration and Login using ASP.NET Identity
* JWT Token-based Authentication
* Role-based Authorization (Admin/User)
* SQL Server with Entity Framework Core
* RESTful API Architecture
* Secure password hashing
* CRUD operations for Client Management

---

## 📄 Technologies Used

| Layer        | Technology                        |
| ------------ | --------------------------------- |
| Backend      | ASP.NET Core 8 Web API            |
| Auth         | ASP.NET Core Identity + JWT       |
| Database     | SQL Server with EF Core           |
| API Testing  | Postman                           |
| Architecture | RESTful API with layered approach |

---

## 🔐 Authentication Flow

1. **Registration (`POST /api/auth/register`)**

   * User signs up.
   * Identity framework stores hashed password.
   * User assigned default role (e.g., User).

2. **Login (`POST /api/auth/login`)**

   * JWT is generated if credentials are valid.
   * Token includes claims such as role, email, etc.
   * Sent in `Authorization` header for future requests.

3. **Middleware**

   * Validates JWT on every request.
   * Populates `User.Identity` with claims.

4. **Role Enforcement**

   * `[Authorize(Roles = "Admin")]` used to protect admin-specific endpoints.

---

## 📊 API Endpoints

| Endpoint             | Method | Access | Description              |
| -------------------- | ------ | ------ | ------------------------ |
| `/api/auth/register` | POST   | Public | Register new user        |
| `/api/auth/login`    | POST   | Public | Authenticate and get JWT |
| `/api/client`        | GET    | Auth   | List all clients         |
| `/api/client/{id}`   | GET    | Auth   | Get client by ID         |
| `/api/client`        | POST   | Admin  | Add new client           |
| `/api/client/{id}`   | PUT    | Admin  | Update existing client   |
| `/api/client/{id}`   | DELETE | Admin  | Delete a client          |

---
 

## 📊 Future Improvements

* Add Refresh Tokens for persistent login
* Integrate Angular/React frontend
* Implement Swagger UI with JWT support
* Add user management dashboard
* Logging with Serilog

---
 
