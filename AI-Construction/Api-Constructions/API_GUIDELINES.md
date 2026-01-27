# API Guidelines

## API Versioning
- Base Path：`/api/v1`
- 所有 Controller 必須放在 `Controllers/V1`

---

## RESTful Design Rules

### Resource Naming
- 使用名詞複數
- 範例：
  - `/devices`
  - `/devices/{id}`
  - `/devices/{id}/configs`

### HTTP Methods
| Method | Usage |
|------|------|
| GET | 查詢 |
| POST | 新增 |
| PUT | 整筆更新 |
| PATCH | 部分更新 |
| DELETE | 刪除 |

---

## HTTP Status Codes
- 200 OK
- 201 Created
- 204 No Content
- 400 Bad Request
- 401 Unauthorized
- 403 Forbidden
- 404 Not Found
- 409 Conflict
- 422 Unprocessable Entity
- 500 Internal Server Error

---

## Error Code Extension Rule
- 錯誤碼以 HTTP Status Code 為基底
- 可擴充為企業內部錯誤碼
- 範例：
  - 404001 → Resource Not Found (Device)
  - 409001 → Resource Conflict

> 此為規範，不要求立即實作完整對照表

---

## Response Models

### ResultResponse（無資料）
```json
{
  "success": true,
  "code": 200000,
  "message": "Success"
}
```

### DataResponse<T>（單筆資料）
```json
{
  "success": true,
  "code": 200000,
  "message": "Success",
  "data": {}
}
```

### ListResponse<T>（清單 + 分頁）
```json
{
  "success": true,
  "code": 200000,
  "message": "Success",
  "data": [],
  "page": 1,
  "pageSize": 20,
  "total": 100,
  "totalPages": 5
}
```

### Pagination Rules
- `page`：從 1 開始
- `pageSize`：預設 20，最大 100
- 所有 GET Collection API 必須支援分頁

### Error Response Rule
- 所有錯誤回傳 `ResultResponse`
- 不回傳 `data` 欄位
