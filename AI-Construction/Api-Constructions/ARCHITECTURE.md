# .NET 8 Web API Architecture

## Overview
本專案為企業級 .NET 8 Web API，採用三層式架構（Controller → Service → Repository），
以 RESTful API 為設計核心，使用 EF Core + MySQL 存取資料庫，
並遵循 SOLID 原則以確保高可維護性與可擴充性。

---

## Architecture Pattern

### Three-Tier Architecture

```
Controller
↓
Service
↓
Repository
↓
Database (MySQL)
```


### Responsibilities

#### Controller Layer
- API 路由與版本（`/api/v1`）
- Model Binding / 參數驗證
- 呼叫 Service
- 回傳統一 Response Model
- ❌ 不可存取 DbContext
- ❌ 不可撰寫商業邏輯
- ❌ 不可 try-catch

#### Service Layer
- 商業邏輯核心
- 資料轉換（Entity ↔ DTO，使用 AutoMapper）
- try-catch 必須寫在此層
- 捕捉例外後必須寫 Log
- 拋出自訂 HttpException
- 控制交易（Transaction）

#### Repository Layer
- EF Core 存取 MySQL
- 純資料存取（CRUD / Query）
- 不含商業邏輯
- 不丟 HttpException

---

## Folder Structure

```
.
├─ Controllers/
│  └─ V1/
├─ Services/
│  ├─ Interfaces/
│  └─ Implementations/
├─ Repositories/
│  ├─ Interfaces/
│  └─ Implementations/
├─ Models/
│  ├─ Entities/
│  ├─ Dtos/
│  ├─ Requests/
│  ├─ Responses/
│  ├─ Common/
│  └─ Exceptions/
├─ Data/
├─ Middlewares/
└─ Extensions/
```


---

## Dependency Injection
- DbContext：Scoped
- Service：Scoped
- Repository：Scoped
- 統一於 Program.cs 或 Extensions 註冊

---

## Database
- MySQL
- 主鍵統一使用 Guid
- 本地：localhost:3306
- Staging / Production：由環境變數或 Secret 注入
