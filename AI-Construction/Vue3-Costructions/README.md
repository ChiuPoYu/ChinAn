# 前端架構（Vue 3 + Vite SPA）

## Overview
本專案為企業級 Vue 3 前端（Vite SPA），用於呼叫 .NET 8 Web API。
具備：
- 標準化 API Response/Errors（ResultResponse/DataResponse/ListResponse）
- RBAC（訪客/客戶/管理者）
- HttpOnly Cookie Auth（JWT + Session/Cookie）
- 分頁列表支援（ListResponse）
- Azure Static Web Apps 部署（GitHub Actions）

---

## Tech Stack
- Vue 3 + Vite + TypeScript
- Element Plus
- SCSS
- Pinia (client state)
- TanStack Query (server state)
- Zod (validation)
- ESLint + Prettier
- Vitest + Vue Testing Library + Playwright

---

## Architecture
- 分層式資料夾結構（Layer-based folder structure）
- API client 放在 `src/api/`
- Stores 放在 `src/stores/`
- Queries 放在 `src/queries/`
- Schemas 放在 `src/schemas/`
- Pages 放在 `src/pages/`

更多說明：
- 架構設計：[ARCHITECTURE](AI-Construction/Vue3-Costructions/ARCHITECTURE.md)
- API Client：[API_CLIENT_GUIDE](AI-Construction/Vue3-Costructions/API_CLIENT_GUIDE.md)
- 程式撰寫規範：[CODING_GUIDELINES](AI-Construction/Vue3-Costructions/CODING_GUIDELINES.md)

---

## Environments（環境）
### Local（本機）
- Vite dev server: http://localhost:5173

### Staging Frontend（前端測試）
- https://proud-bush-036885100.1.azurestaticapps.net

### Production Frontend（前端正式）
- https://salmon-ocean-07c3a3b00.1.azurestaticapps.net

### Staging Backend（後端測試）
- https://chinan-api-hzccg2bafue3fzba.canadacentral-01.azurewebsites.net

### Production Backend（後端正式）
- TODO (not deployed yet)

---

## How API Base URL is Resolved
本專案允許不同環境使用不同 API 路徑/網域。
建議以 `window.location.origin` 判斷目前站點並回傳對應 API base。
（詳細見 `FRONTEND_API_CLIENT_GUIDE.md`）

---

## Local Development
1. Install deps
   - `npm ci`
2. Start dev
   - `npm run dev`
3. Open
   - http://localhost:5173

---

## Deployment (Azure Static Web Apps)
- GitHub Actions builds and uploads `dist/` artifacts
- Deploy job uploads `UserWeb/dist` with `skip_app_build: true`

> The workflow is already configured and working.
