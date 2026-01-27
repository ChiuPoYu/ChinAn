# API Client Guide (Axios + HttpOnly Cookie + Response Standard)

## Goal
與後端 .NET 8 Web API 對接，遵循標準 Response：
- ResultResponse
- DataResponse<T>
- ListResponse<T>（含分頁欄位）

並支援：
- HttpOnly Cookie (Access/Refresh)
- withCredentials
- 統一錯誤處理（code/message）
- 錯誤碼 i18n 映射
- CSRF 防護策略（Cookie 模式必須考量）

---

## Base URL Strategy (Per Environment, Not a Single Fixed Key)
此專案允許不同環境有不同 API 路徑/網域，規範如下：
- Local: 使用本機設定
- Staging FE: 使用 Staging API
- Prod FE: 使用 Prod API (TODO until backend deployed)

### Recommended Implementation
- 在 `src/constants/env.ts` 建立一個 `resolveApiBaseUrl()`：
  - 依 `window.location.origin` 判斷目前是哪個前端站點
  - 回傳對應的 API Base URL
- 避免只靠單一 `VITE_API_BASE_URL`（因為你明確說不同站點會有不同路徑）

### Current Known URLs
- FE Staging: https://proud-bush-036885100.1.azurestaticapps.net
- FE Production: https://salmon-ocean-07c3a3b00.1.azurestaticapps.net
- BE Staging: https://chinan-api-hzccg2bafue3fzba.canadacentral-01.azurewebsites.net
- BE Production: TODO

---

## Axios Instance Rules
- must set `withCredentials: true` (HttpOnly cookie required)
- must set `baseURL` from resolveApiBaseUrl()
- must set timeout (e.g. 10s/20s)
- interceptors:
  - response success: unwrap response models when helpful
  - response error: normalize to a unified AppError

### Interceptor Error Normalization
Normalize error shape:
- httpStatus (number)
- code (number|string)
- message (string)
- traceId (optional)
- fieldErrors (optional)
- raw (original error)

---

## Response Models (Frontend Types)
Define in `src/types/api.ts`:

- ResultResponse:
  - success: boolean
  - code: number | string
  - message: string

- DataResponse<T> extends ResultResponse:
  - data: T

- ListResponse<T> extends ResultResponse:
  - data: T[]
  - page: number
  - pageSize: number
  - total: number
  - totalPages: number

---

## Error Code & i18n Mapping
- 在 `src/constants/error-messages.ts` 建立對照：
  - key: code (e.g. 404001)
  - value: { zhTW: "...", en?: "..." }
- 顯示訊息策略：
  1) 若後端 message 可直接用，使用後端 message
  2) 若需要統一文案/多語系，優先用前端 mapping
  3) 仍保留後端 message 作 fallback（debug/unknown code）

---

## Auth (JWT + HttpOnly Cookie)
- Access/Refresh token 皆存於 HttpOnly Cookie（前端不可讀取 token）
- 登入流程建議：
  1) POST /auth/login (server sets cookies)
  2) GET /auth/me (DataResponse<User>)
  3) Pinia authStore setUser + role
- 登出流程：
  1) POST /auth/logout (server clears cookies)
  2) clear store + invalidate queries

---

## CORS / Cookie / CSRF Notes (Must Align With Backend)
Because FE and BE are different origins:
- FE must call API with `withCredentials: true`
- BE must allow credentials and specify allowed origins (cannot be `*`)
- Cookies must use: `Secure; HttpOnly; SameSite=None` for cross-site cookie
- CSRF protection should be implemented:
  - Recommended: server issues CSRF token (non-HttpOnly) + client sends in header (e.g. X-CSRF)
  - Client must attach CSRF header for mutating requests (POST/PUT/PATCH/DELETE)

---

## API Module Rules
- each domain has its own module under `src/api/modules/`
  - auth.api.ts
  - device.api.ts
- each function:
  - strongly typed input/output
  - returns DataResponse<T>/ListResponse<T>/ResultResponse
- no UI logic in api modules