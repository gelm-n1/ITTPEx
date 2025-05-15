# ITTP Тестовое задание

## Основные технологии

- .NET 9 (ASP.NET Core)
- Entity Framework Core (PostgreSQL)
- JWT-аутентификация (Bearer Token)
- MediatR (CQRS-паттерн)
- Swagger UI (Документация API)
- Clean Architecture

## Примеры запросов созданных по заданию (Swagger)

### 1. Регистрация нового пользователя

![image](screens/register.png)

### Вход в систему

![image](screens/login.png)

### 2. Изменение имени, пола или даты рождения

![image](screens/change-profile.png)

### 3. Изменение пароля

![image](screens/change-password.png)

### 4. Изменение логина

![image](screens/change-login.png)

### 5. Запрос всех активных пользователей

![image](screens/get-active-users.png)

### 6. Запрос пользователя по логину

![image](screens/get-user-by-login-adm.png)

### 7. Запрос пользователя по лоигну и паролю

![image](screens/get-my-profile.png)

### 8. Запрос всех пользователей старше определенного возраста

-Старше 10
![image](screens/get-older-10.png)

-Старше 14
![image](screens/get-older-14.png)

### 9. Удаление пользователя

-Полное
![image](screens/full-delete.png)

-Мягкое
![image](screens/deactivate.png)

### 10. Восстановление пользователя

![image](screens/activate.png)

## База данных (PostgresSQL + EF Core)

### Сущности:

  - User
  - Role

### Миграция: 

```bash
dotnet ef migrations add InitialMigration --project ITTPEx.Infrastructure --startup-project ITTPEx.API
dotnet ef database update --project ITTPEx.Infrastructure --startup-project ITTPEx.API
```

