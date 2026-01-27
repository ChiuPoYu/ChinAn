# .NET 8 Web API Project

## Project Overview
本專案為 .NET 8 Web API，
採用三層式架構與 RESTful API 設計，
適用於中大型系統與長期維運專案。

---

## Tech Stack
- .NET 8 Web API
- EF Core
- MySQL
- AutoMapper
- Swagger / OpenAPI

---

## Architecture
- 三層式架構（Three-Tier Architecture）
- 不採用 MVVM（MVVM 為前端常用模式）
- RESTful API
- 統一 Response / Error Handling
- 可擴充錯誤碼設計

---

## Key Concepts
- 所有商業邏輯集中於 Service
- 所有資料存取集中於 Repository
- 所有錯誤由 Service 拋出，Middleware 統一處理
- 所有 API 回應皆為標準化格式

---

## API Design
- Base Path：`/api/v1`
- RESTful Resource-based 設計
- 支援分頁查詢

---

## Environment Configuration
### Local
- MySQL：localhost:3306
- 使用環境變數或 appsettings.Development.json

### Staging / Production
- 使用 CI/CD 或 Secret 管理連線資訊
- 不允許憑證進版控

---

## Documentation
- 架構設計：[ARCHITECTURE](AI-Construction/Api-Constructions/ARCHITECTURE.md)
- API 規範：[API_GUIDELINES](AI-Construction/Api-Constructions/API_GUIDELINES.md)
- 程式撰寫規範：[CODING_GUIDELINES](AI-Construction/Api-Constructions/CODING_GUIDELINES.md)

---

## Getting Started
1. 設定 MySQL 環境
2. 設定連線字串
3. 啟動專案
4. 開啟 Swagger 確認 API

---

## Notes
請務必遵守專案內規範文件，確保程式碼一致性與可維護性。
