<div align="center">

# 📚 BookStore API

### RESTful API for an Online BookStore built with ASP.NET Core Web API

A modern and scalable BookStore API implementing Authentication, Authorization, Repository Pattern, Entity Framework Core, and JWT Authentication.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=.net)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge)
![JWT](https://img.shields.io/badge/JWT-Authentication-orange?style=for-the-badge)
![Swagger](https://img.shields.io/badge/Swagger-API_Documentation-85EA2D?style=for-the-badge&logo=swagger)

</div>

---

# 📌 Overview

BookStore API is a RESTful backend application built with **ASP.NET Core Web API** that provides a complete backend solution for an online bookstore.

The API supports authentication, authorization, book management, shopping cart functionality, wishlist management, and order processing using clean and maintainable architecture.

---

# 🚀 Features

## 🔐 Authentication

- User Registration
- User Login
- JWT Authentication
- Role-Based Authorization
- Secure Password Hashing
- Email Confirmation
- Forgot Password
- Reset Password

---

## 📚 Books

- Get All Books
- Get Book By Id
- Create Book
- Update Book
- Delete Book
- Search Books

---

## 👨‍💼 Authors

- CRUD Operations
- Search Authors

---

## 🏷 Categories

- CRUD Operations

---

## 🏢 Publishers

- CRUD Operations

---

## ❤️ Wishlist

- Add Book
- Remove Book
- Get User Wishlist

---

## 🛒 Shopping Cart

- Add Item
- Update Quantity
- Remove Item
- Clear Cart
- Get Cart

---

## 📦 Orders

- Checkout
- Create Order
- Order Details
- Get User Orders

---

# 🛠 Technologies

| Technology | Used |
|------------|------|
| ASP.NET Core Web API | ✅ |
| C# | ✅ |
| Entity Framework Core | ✅ |
| SQL Server | ✅ |
| ASP.NET Core Identity | ✅ |
| JWT Authentication | ✅ |
| LINQ | ✅ |
| Repository Pattern | ✅ |
| Dependency Injection | ✅ |
| Swagger | ✅ |

---

# 🏗 Architecture

The project follows a layered architecture with clear separation of concerns.

```
Presentation Layer

Controllers

Services

Repositories

Entity Framework Core

SQL Server
```

---

# 📂 Project Structure

```
BookStore.API

├── Controllers
├── Models
├── DTOs
├── Repositories
├── Interfaces
├── Services
├── Configurations
├── Data
├── Migrations
├── Helpers
└── Program.cs
```

---

# 🔑 API Modules

- Authentication
- Books
- Categories
- Authors
- Publishers
- Wishlist
- Cart
- Orders

---

# 🗄 Database

Main Entities

- Users
- Books
- Authors
- Categories
- Publishers
- Wishlist
- Cart
- Cart Items
- Orders
- Order Items

---

# 📖 API Documentation

Swagger UI is available after running the project.

```
https://localhost:7119/swagger
```

---

# ⚙️ Getting Started

## Clone Repository

```bash
git clone https://github.com/Remon691/BookStore.API.git
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Update Database

```bash
Update-Database
```

---

## Run

```bash
dotnet run
```

---

# 📌 Main Endpoints

## Authentication

- POST /api/auth/register
- POST /api/auth/login
- POST /api/auth/confirm-email
- POST /api/auth/forgot-password
- POST /api/auth/reset-password

---

## Books

- GET /api/books
- GET /api/books/{id}
- POST /api/books
- PUT /api/books/{id}
- DELETE /api/books/{id}

---

## Wishlist

- GET /api/wishlist
- POST /api/wishlist
- DELETE /api/wishlist/{bookId}

---

## Cart

- GET /api/cart
- POST /api/cart
- PUT /api/cart
- DELETE /api/cart/{bookId}
- DELETE /api/cart/clear

---

## Orders

- POST /api/orders/checkout
- GET /api/orders
- GET /api/orders/{id}

---

# 📈 Future Improvements

- Payment Integration
- Docker Support
- Unit Testing
- Integration Testing
- Global Exception Handling
- Logging
- Pagination & Filtering
- Email Notifications
- Deployment to Azure

---

# 👨‍💻 Author

**Remon Samy**

Backend Developer (.NET)

GitHub:
https://github.com/Remon691

LinkedIn:
https://www.linkedin.com/in/remon-samy-2044711b7/

---

<div align="center">

### ⭐ If you found this project useful, please consider giving it a star.

</div>
