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

