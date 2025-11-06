# EF Core Migration Instructions

## 1. Add a New Migration

After making changes to the entity classes or the `ApplicationDbContext`, you need to add a new migration to update the database schema. Run the following command in the Package Manager Console, or use the dotnet CLI:

### Package Manager Console
```
Add-Migration "Add_New_Entities_And_Relationships" -Project AssetManagement.DataAccess -StartupProject AssetManagement.Web
```

### dotnet CLI
```
dotnet ef migrations add "Add_New_Entities_And_Relationships" --project "AssetManagement.DataAccess" --startup-project "AssetManagement.Web"
```

This command will create a new migration file in the `AssetManagement.DataAccess/Migrations` directory.

## 2. Apply the Migration

Once the migration has been created, you need to apply it to the database. Run the following command:

### Package Manager Console
```
Update-Database -Project AssetManagement.DataAccess -StartupProject AssetManagement.Web
```

### dotnet CLI
```
dotnet ef database update --project "AssetManagement.DataAccess" --startup-project "AssetManagement.Web"
```

This will update the database schema to reflect the latest changes.
