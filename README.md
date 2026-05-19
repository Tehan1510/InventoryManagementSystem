# InventoryPro - Inventory Management System

A modern desktop inventory management system built with **C#**, **.NET 10**, **WPF**, and **SQLite** using the **MVVM architecture**, **Repository Pattern**, and **Entity Framework Core**.

This project was designed as a portfolio-ready application that demonstrates clean architecture, authentication, CRUD operations, database management, and desktop UI development with WPF.

---

## Features

### Authentication & Security

* User login and self-registration
* BCrypt password hashing
* Role-based access (Admin / User)
* Session management

### Dashboard

* Total products count
* Low stock alerts
* Categories and suppliers overview
* Recent stock transaction history

### Product Management

* Create, update, delete, and search products
* SKU management
* Product pricing and stock thresholds
* Category and supplier relationships
* Soft delete support to preserve transaction history
* Low stock highlighting

### Category Management

* Full CRUD operations
* Duplicate category validation
* Prevents deletion when products are linked

### Supplier Management

* Supplier contact management
* Email, phone number, and address support

### Stock Transactions

* Stock In
* Stock Out
* Inventory Adjustments
* Automatic quantity updates
* Prevents negative inventory

---

## Tech Stack

| Layer          | Technology                        |
| -------------- | --------------------------------- |
| UI Framework   | WPF (.NET 10)                     |
| Architecture   | MVVM Pattern                      |
| Database       | SQLite                            |
| ORM            | Entity Framework Core 10          |
| Authentication | BCrypt.Net-Next                   |
| Language       | C# 13                             |
| Patterns       | Repository Pattern, Service Layer |

---

## Prerequisites

Before running the project, install the following:

* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* Visual Studio 2022 (17.8+) or newer
* Visual Studio workload:

  * `.NET Desktop Development`

---

## Clone the Repository

```bash
git clone https://github.com/Tehan1510/InventoryPro.git
cd InventoryManagementSystem
```

---

## Run the Application

### Using Visual Studio

1. Open `InventoryManagementSystem.sln`
2. Set `InventoryApp` as the startup project
3. Press `F5` to build and run

### Using the Terminal

```bash
cd InventoryApp
dotnet restore
dotnet build
dotnet run
```

---

## First Launch

When the application starts for the first time, it will automatically:

* Create the SQLite database
* Generate the database schema
* Seed default categories
* Create the default admin account

---

## Default Admin Credentials

| Username | Password  | Role  |
| -------- | --------- | ----- |
| admin    | Admin@123 | Admin |

---

## Database Location

```text
%LocalAppData%\InventoryApp\inventory.db
```

---

## Project Structure

```text
InventoryManagementSystem/
│
├── InventoryApp/
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── Supplier.cs
│   │   └── StockTransaction.cs
│   │
│   ├── Data/
│   │   ├── AppDbContext.cs
│   │   ├── IRepository.cs
│   │   ├── BaseRepository.cs
│   │   └── Repositories/
│   │
│   ├── Services/
│   │   ├── AuthService.cs
│   │   └── SessionManager.cs
│   │
│   ├── ViewModels/
│   │   ├── BaseViewModel.cs
│   │   ├── RelayCommand.cs
│   │   ├── LoginViewModel.cs
│   │   ├── MainViewModel.cs
│   │   ├── DashboardViewModel.cs
│   │   ├── ProductsViewModel.cs
│   │   ├── CategoriesViewModel.cs
│   │   ├── SuppliersViewModel.cs
│   │   └── StockViewModel.cs
│   │
│   └── Views/
│       ├── LoginWindow.xaml
│       ├── MainWindow.xaml
│       ├── DashboardView.xaml
│       ├── ProductsView.xaml
│       ├── CategoriesView.xaml
│       ├── SuppliersView.xaml
│       └── StockView.xaml
│
├── InventoryManagementSystem.sln
├── .gitignore
└── README.md
```

---

## Architecture Overview

### MVVM Architecture

The application follows the MVVM pattern:

* **Models** represent application data
* **Views** handle UI rendering
* **ViewModels** contain presentation logic and commands

Views contain minimal code-behind and no business logic.

### Repository Pattern

A generic repository handles common CRUD operations while specialized repositories implement entity-specific behavior.

### Service Layer

Business logic such as authentication and session management is separated into services.

### Navigation System

`MainViewModel` controls navigation using `CurrentViewModel`, while WPF `DataTemplates` automatically map ViewModels to Views.

---

## Application Startup Flow

```text
App Startup
    ↓
Database Creation
    ↓
Seed Default Data
    ↓
Show Login Window
    ↓
Successful Login
    ↓
Open Main Dashboard
```

---

## Key Learning Concepts Demonstrated

* WPF desktop development
* MVVM architecture
* Entity Framework Core
* SQLite integration
* Repository Pattern
* Async/await programming
* Authentication systems
* Dependency organization
* Data binding and commands

---
