# .NET REST WEB API

# Database
```
1. SQLite - Microsoft.EntityFrameworkCore.Sqlite
2. SQLServer - Microsoft.EntityFrameworkCore.SqlServer
3. PostgreSQL - Aspire.Npgsql.EntityFrameworkCore.PostgreSQL
```

# Migrations (for multiple DbContext)
```
1. dotnet ef migrations add Initial --context DbContextClass --output-dir ./Migrations/DbContextName
2. dotnet ef database update --context DbContextClass
```

# Migrations (for single DbContext)
```
1. dotnet ef migrations add Initial
2. dotnet ef database update
```
