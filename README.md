
# Description 
_______________
Web API for simulating a library system (Create, Read, Update, Delete operations).

## Run Locally
______________________
*Important: .NET 8 required*

Clone the project

```bash
  git clone https://github.com/RomanShidlovsky/LibraryApi.git
```

Go to the project directory

```bash
cd ./LibraryApi/WebApi
```

Connection string to MS SQL Server can be set in "ConnectionStrings/DefaultConnection" inside appsettings.json    

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=librarydb;Trusted_Connection=True;"
  }
```

JWT parameters can be changed in section "JWT" inside appsettings.json

```json
"Jwt": {
    "Key": "super-secret-E47C87FF-48EC-4FB2-ABDA-514CB4B1B365",
    "Issuer": "shidlovsky.roman",
    "TokenValidityInMinutes": 30,
    "RefreshTokenValidityInDays": 7
  }
```

Start the server

```bash
  dotnet run --project .\WebApi.csproj --launch-profile https
```

Go to swagger page 

<https://localhost:7258/swagger/index.html>

## Functionality
_______________________
There are three roles provided by default:
- Client
- Admin
- SuperAdmin

For Anonymous:
- Register as Client
- Login
- Refresh access token
- Get all authors
- Get author by id
- Get all books
- Get book by id
- Get book by ISBN
- Get all genres
- Get genre by id

For Client:
- Anonymous functionality
- Create subscription
- Return book
- Get user by id

For Admin:
- Client functionality
- CRUD for Book, Genre and Subscription entities

For SuperAdmin:
- Admin functionality
- Create and Delete Role
- Managing user roles
- Delete user

## Default user credentials
________________
- For Client 
  - UserName: Client
  - Password: Client1!
- For Admin
  - UserName: Admin
  - Password: Admin1!
- For SuperAdmin
  - UserName: SuperAdmin
  - Password: SuperAdmin1!

## Authorization

For authorization use the button "Authorize" on top of SwaggerUI page.

Enter the Bearer Authorization string as following: 

```bash
Bearer {token}
```

where token is access token received during authentication.
