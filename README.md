# ASP.NET Core Web API with Entity Framework Core, SQL Server, Authentication, and Authorization

This project demonstrates how to build an ASP.NET Core Web API using Entity Framework Core, SQL Server, and implement authentication and authorization. The project is built with .NET 8.

## Table of Contents

- Prerequisites
- Getting Started
- Running the Application
- API Endpoints
- Authentication and Authorization
- Technologies Used
- Contributing
- License

## Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio 2022
- Postman (optional, for testing the API)

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   cd your-repo-name

2. **Set up the database:**

   Update the connection string in appsettings.json to point to your SQL Server instance.
   Run the following command to apply migrations and create the database:
   dotnet ef database update

3. **Run the application:**
   dotnet run

   **Running the Application**
   Open your browser and navigate to https://localhost:5001 to access the API.
   Use Postman or any other API client to test the endpoints.
   API Endpoints

4. **Here are some of the main API endpoints:**

   GET /api/items - Retrieve all items.
   GET /api/items/{id} - Retrieve an item by ID.
   POST /api/items - Create a new item.
   PUT /api/items/{id} - Update an existing item.
   DELETE /api/items/{id} - Delete an item.

5. **Authentication and Authorization**
   This project uses ASP.NET Core Identity for authentication and authorization. Users can register, log in, and access protected endpoints based on their roles.
   
   Register: POST /api/auth/register
   Login: POST /api/auth/login
   Protected Endpoint: GET /api/protected (requires authentication)

6. **Technologies Used**
   ASP.NET Core 8
   Entity Framework Core
   SQL Server
   ASP.NET Core Identity
   JWT (JSON Web Tokens) for authentication
   Swagger for API documentation

7. **Contributing**
   Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

8. **License**
   This project is licensed under the GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007.
   See the LICENSE file for details.
