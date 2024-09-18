# Nutrition tracker


## How to

### Database

#### Start Dev DB Docker Container

> On terminal

```bash
docker-compose up -d
```

#### Create a migration

> On NutritionTracker.Infrastructure default projet on Package manager console

```bash
Add-Migration -o Database/Migrations MigrationName
```

#### Apply migrations

> On NutritionTracker.Infrastructure default projet on Package manager console

```bash
Update-Database
```

#### Build with linux CLI

> On linux bash at project root level

```bash
dotnet build
```

#### Run with linux CLI

> On linux bash at project root level

```bash
dotnet run --project NutritionTracker.API/NutritionTracker.API.csproj --lp http
```