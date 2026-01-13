# UserWeb - 車輛保養查詢系統

## 功能特色

### 🔍 車輛資訊查詢
- 輸入車牌號碼查詢車輛基本資訊
- 顯示車型、車主、目前里程數等資訊

### 📋 保養歷史記錄
- 顯示所有保養記錄
- 按日期篩選查看特定保養記錄
- 詳細的保養項目說明

### 🛠️ 保養項目顯示
包含以下常見保養項目：
- 機油更換
- 濾清器更換
- 煞車檢查
- 輪胎檢查
- 電瓶檢查
- 引擎檢查
- 變速箱檢查
- 冷氣系統
- 電系檢查
- 其他項目

## API 整合

### 資料結構
```javascript
// 車輛資訊
{
  plateNumber: "ABC-1234",
  model: "Toyota Camry",
  owner: "王小明",
  currentMileage: 85000
}

// 保養記錄
{
  id: 1,
  date: "2024-01-15",
  mileage: 2000,
  maintenanceItems: ["oil_change", "filter_change", "brake_check"],
  description: "定期保養，更換機油及濾清器，檢查煞車系統",
  cost: 2500,
  technician: "李技師"
}
```

### API 端點
- `GET /api/vehicles/{plateNumber}` - 取得車輛資訊
- `GET /api/vehicles/{plateNumber}/maintenance` - 取得保養記錄
- `GET /api/vehicles/{plateNumber}/maintenance?date={date}` - 按日期查詢保養記錄

## 使用方式

1. 在搜尋框輸入車牌號碼
2. 點擊「查詢」按鈕或按 Enter 鍵
3. 查看車輛基本資訊
4. 使用日期下拉選單篩選保養記錄
5. 查看詳細的保養項目和內容

## 開發設定

### 切換 API 模式
在 `src/App.vue` 中修改 `useMockData` 變數：
- `true`: 使用模擬資料
- `false`: 使用真實 API

### 環境變數
建立 `.env` 檔案：
```
VUE_APP_API_URL=http://localhost:3000/api
VUE_APP_USE_MOCK_DATA=true
```

## 技術特色

- 響應式設計，支援手機和桌面
- 現代化 UI 設計
- 載入狀態和錯誤處理
- 模組化 API 服務
- 支援真實 API 和模擬資料
