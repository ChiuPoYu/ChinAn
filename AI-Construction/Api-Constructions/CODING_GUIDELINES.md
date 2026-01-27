# Coding Guidelines

## General Rules
- 使用 .NET 8
- 使用 EF Core 存取 MySQL
- 必須撰寫 XML 註解
- 禁止魔法數字與硬編碼字串

---

## Validation Rules

### Required
- 所有 Request DTO 必須使用 DataAnnotations
  - Required / Range / StringLength / RegularExpression

### Extended Rule
> 當驗證邏輯超過 DTO 屬性層級（跨欄位、條件式、集合）時，允許導入 FluentValidation。

---

## AutoMapper Rules
- 必須使用 AutoMapper 進行 Entity ↔ DTO 轉換
- Mapping Profile 統一管理
- 禁止在 Controller / Repository 進行 mapping

---

## Exception Handling Rules
- try-catch 只能寫在 Service
- catch 必須記錄 Log
- 拋出 HttpException
- Controller 不處理例外

---

## Logging
- 使用 ILogger
- Log 必須包含 Context（例如 Resource Id）

---

## XML Comments
- 所有 public 類別 / 方法 / DTO 屬性 必須有 XML 註解
- Swagger 必須載入 XML 文件

---

## EF Core Rules
- 查詢使用 AsNoTracking()
- 所有操作使用 async
- SaveChangesAsync 建議由 Service 控制

---

## Naming Rules
- Interface：IXXX
- Request DTO：CreateXxxRequest / UpdateXxxRequest
- Response DTO：XxxResponse
