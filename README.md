# InventoryPro - Inventory Management System

A modern desktop inventory management system built with **C#**, **.NET 10**, **WPF**, and **SQLite** using the **MVVM architecture**, **Repository Pattern**, and **Entity Framework Core**.
This project was designed as an application that demonstrates clean architecture, authentication, CRUD operations, database management, and desktop UI development with WPF.

---

## Tech Stack

| Layer      | Technology                              |
|------------|----------------------------------------|
| UI         | WPF (.NET 10), MVVM Pattern             |
| Database   | SQLite via Entity Framework Core 10     |
| Security   | BCrypt password hashing                 |
| Pattern    | Repository Pattern + Service Layer      |
| Language   | C# 13 with async/await throughout       |

---

## Features

- **Authentication** - Login with BCrypt-hashed passwords, role-based access (Admin/User)
- **Dashboard** - Live stats: total products, low stock alerts, categories, suppliers, recent transactions
- **Products** - Full CRUD with SKU, pricing, stock thresholds, category & supplier linking
- **Categories** - Manage product categories with duplicate name validation
- **Suppliers** - Manage supplier contacts and details
- **Stock Transactions** - Record Stock In / Stock Out / Adjustments with automatic quantity updates

---

## Getting Started

### Prerequisites
- Visual Studio 2026
- .NET 10 SDK

## Clone the Repository

```bash
git clone https://github.com/Tehan1510/InventoryPro.git
cd InventoryManagementSystem
```

---

## Run the Application

### Using the Terminal

```bash
cd InventoryApp
dotnet restore
dotnet build
dotnet run
```
**OR**

### Using Visual Studio

1. Open `InventoryManagementSystem.sln`
2. Set `InventoryApp` as the startup project
3. Press `F5` to build and run

---

4. Login with default credentials:
   - **Username:** `admin`
   - **Password:** `Admin@123`
   
       **OR**

   - **Register as a new user**


> The SQLite database is auto-created at `%LocalAppData%\InventoryApp\inventory.db` on first run.

---

## Project Structure

```text
InventoryApp/
├── Models/          # EF Core entity classes
├── Data/            # DbContext, generic repository, specific repositories
├── Services/        # AuthService (login/register), SessionManager
├── ViewModels/      # MVVM ViewModels — one per view
└── Views/           # WPF XAML views + code-behind
```

## Architecture

This project uses the **MVVM (Model-View-ViewModel)** pattern:
- **Models** define the database schema
- **Repositories** abstract all database operations (Repository Pattern)
- **Services** contain business logic (authentication, session)
- **ViewModels** expose data and commands to the UI
- **Views** are purely declarative XAML - no business logic in code-behind

---

## Default Credentials

| Username | Password  | Role  |
|----------|-----------|-------|
| admin    | Admin@123 | Admin |

---