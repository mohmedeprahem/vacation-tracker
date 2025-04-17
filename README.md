# Vacation Request Tracking System – ASP.NET Core MVC

This project is a simple **Vacation Request Tracking System** built with **ASP.NET Core MVC**, designed to demonstrate key features like authentication, role-based access, vacation tracking, and admin control.

## Features

- **JWT Authentication** for two roles: `Admin` and `Employee`.
- **Admin Capabilities:**
  - Create new employee accounts.
  - Assign employees to departments.
  - View all submitted vacation requests.
  - Access vacation request details.
- **Employee Capabilities:**
  - Submit a new vacation request using the “New Vacation Request” form.
- **Vacation Requests Grid** view for admin to manage requests.
- **Entity Framework Core** with SQL Server for data persistence.
- **Code-First Migrations** for easy database setup.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- JWT Authentication
- Role-based Authorization

## Setup Instructions

1. **Clone the repository**
2. **Restore NuGet packages**
```bash
dotnet restore
```
3. **Configure the database connection**
- Open `appsettings.json`
- Replace the value of `DefaultConnection` with your local SQL Server connection string:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Your_SQL_Server_Connection_String"
  }
  ```

4. **Apply Migrations & Create Database**
```bash
dotnet ef database update
```
5. **Run the Application**
```bash
dotnet run
```
## Authentication

The app uses **JWT tokens** for authentication. You can log in as either:

- **Admin** – Has full access to manage users and requests.
- **Employee** – Can only submit vacation requests.
- 
### Default Admin Credentials
```json
{
"Email": "admin@admin.com",
"Password": "Admin@123"
}
```

## Database

- SQL Server
- Code-First Migrations
- Ensure you configure the correct connection string before running the app
