# Frontend Architecture (Vue 3 + Vite SPA)

## Overview
本前端專案用於呼叫 .NET 8 Web API（RESTful、標準化 Response/Errors）。
採用企業級可維護架構：Layer-based 分層、TypeScript 強制、Pinia 管理 Client State、
TanStack Query 管理 Server State（快取、分頁、重試）、Zod 管理表單與資料驗證、
Element Plus 作為 UI 基礎元件庫，並支援 RBAC（訪客/客戶/管理者）。

---

## Why SPA (and when SSR/SSG)
### SPA (Chosen)
適合：登入後系統、後台、重互動、權限控制（RBAC）、與 API 強解耦。
部署：Azure Static Web Apps 對 SPA 最自然。

### SSR (Not chosen now)
適合：公開 SEO 頁（行銷頁、文章頁、需要搜尋/社群 preview）。
成本：需要 Server runtime 與 hydration、權限/快取更複雜。

### SSG (Not chosen now)
適合：文件站、公告、Help Center 等「內容型」網站。
建議策略：App 仍為 SPA；若需要 SEO 文件頁，另起 docs 站採 SSG。

---

## Layer-based Folder Structure

```
src/
├─ assets/
├─ styles/
├─ tokens/            # design tokens: colors, spacing, typography
├─ base/              # reset, global base styles (minimal)
├─ element-plus/      # theme overrides, variables
├─ constants/         # app constants, route names, roles, error code mapping keys
├─ types/             # global TS types (Response models, enums)
├─ utils/             # pure helpers (date, format, permission helpers)
├─ api/               # HTTP client + typed endpoints
│  ├─ http/            # axios instance, interceptors, csrf helper
│  └─ modules/         # api modules (auth.api.ts, device.api.ts)
├─ stores/            # Pinia stores (client-state)
│  ├─ auth.store.ts
│  └─ ui.store.ts
├─ queries/           # TanStack Query hooks (server-state)
│  ├─ auth.queries.ts
│  └─ device.queries.ts
├─ router/
│  ├─ index.ts
│  ├─ guards.ts
│  └─ routes.ts
├─ schemas/           # Zod schemas (forms + runtime validation)
│  ├─ auth.schema.ts
│  └─ device.schema.ts
├─ components/        # shared components (atomic / reusable)
├─ pages/             # route pages
│  ├─ login/
│  ├─ devices/
│  └─ admin/
├─ layouts/           # app layouts (guest/admin)
├─ App.vue
└─ main.ts
```

### Folder Rules
- `api/`：只負責「HTTP 呼叫」與「型別/response parsing」；不得含 UI 邏輯。
- `stores/`：Pinia 只存「client state」（登入狀態、角色、UI狀態）；不得存列表快取資料。
- `queries/`：所有列表/詳情等 server data 由 TanStack Query 管理；統一 query keys 命名規則。
- `schemas/`：所有表單驗證 schema（Zod）集中；避免散落在 components。
- `pages/`：頁面層；組裝 components、呼叫 queries/store；不直接寫底層 http。
- `utils/`：純函式，必須可單元測試，且不依賴 Vue runtime。

---

## State Strategy
### Client State (Pinia)
- auth: isAuthenticated, user, role, permissions
- ui: theme, language, sidebar state, global loading flags (optional)

### Server State (TanStack Query)
- list/detail/search/pagination
- caching, retries, background refetch, invalidate on mutations
- 禁止用 Pinia 取代 Query 快取（避免資料一致性問題）

---

## RBAC (Roles)
- Guest (訪客): 未登入
- Customer (客戶): 一般登入使用者
- Admin (管理者): 管理權限

RBAC 需落實於：
1. Router Guard（路由層）
2. UI 層（按鈕/功能顯示）
3. API 層錯誤處理（403 統一處理）

---

## Environment & Deployment
- Local dev: Vite default port `5173`
- Azure Static Web Apps (GitHub Actions) deploy `dist/`
- 每個環境（local/dev/prod）允許不同 API Base Path（不同站點路徑/網域不同）
- Production API Base 先以 TODO 佔位，待後端正式站部署後填入
