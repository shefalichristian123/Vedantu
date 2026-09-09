# Vedantu – Codespaces-Ready Online Learning Web Application

A starter full-stack educational web application built with ASP.NET Core MVC, C#, Entity Framework Core and SQLite.

## No local SQL Server / LocalDB required

This version has been changed from SQL Server LocalDB to **SQLite**.

The database is a local file named `VedantuDB.db` that the application creates automatically. In GitHub Codespaces, the ASP.NET development environment runs in the cloud.

You do NOT need to install Visual Studio, .NET SDK, SQL Server, SQL Server Express, or LocalDB on your computer to work on this version through Codespaces.

## Technology

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQLite
- HTML5
- CSS3
- JavaScript
- Cookie authentication
- BCrypt password hashing

## Included features

- Responsive educational-platform home page
- Student registration
- Email uniqueness validation
- Secure password hashing
- Student login
- Remember-me authentication
- Student dashboard
- Logout
- Automatic SQLite database creation
- GitHub Codespaces configuration

## Run in GitHub Codespaces

1. Create a GitHub repository.
2. Upload/extract all files from this project into the repository.
3. Open the repository on GitHub.
4. Click **Code → Codespaces → Create codespace on main**.
5. Wait for the Codespace to finish creating.
6. In the Codespaces terminal, run:

   `dotnet run --urls http://0.0.0.0:5080`

7. When GitHub asks about port 5080, choose **Open in Browser**.

The `.devcontainer/devcontainer.json` file automatically provides the .NET development environment and restores/builds the project.

## Run manually in the Codespaces terminal

```bash
dotnet restore
dotnet build
dotnet run --urls http://0.0.0.0:5080
```

## Database

The connection string is:

`Data Source=VedantuDB.db`

The application calls `EnsureCreated()` at startup, so the `Students` table is created automatically.

The generated database file is ignored by Git using `.gitignore`.

## Student flow

Register:

`/Account/Register`

Login:

`/Account/Login`

Dashboard:

`/Account/Dashboard`

## Important

This is an original educational-platform project and is not affiliated with or a copy of the real Vedantu website. Replace branding, logos, images, and content with your own before publishing.

## Next modules

The same foundation can be extended with:

- Courses
- Course enrollment
- Online exams
- Exam timer and results
- Book store
- Shopping cart
- Checkout
- Payment gateway
- Orders
- Admin panel
- Student management
