// API 服務檔案
// 在 Vite 中使用 import.meta.env 讀取環境變數；避免於瀏覽器出現 process 未定義
const API_BASE_URL = (typeof import.meta !== 'undefined' && import.meta.env && import.meta.env.VITE_API_URL)
  ? import.meta.env.VITE_API_URL
  : 'http://localhost:3000/api'

class ApiService {
  constructor() {
    this.baseURL = API_BASE_URL
  }

  // 通用請求方法
  async request(endpoint, options = {}) {
    const url = `${this.baseURL}${endpoint}`
    const config = {
      headers: {
        'Content-Type': 'application/json',
        ...options.headers
      },
      ...options
    }

    try {
      const response = await fetch(url, config)
      
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`)
      }
      
      return await response.json()
    } catch (error) {
      console.error('API Request failed:', error)
      throw error
    }
  }

  // 查詢車輛資訊
  async getVehicleInfo(plateNumber) {
    return this.request(`/vehicles/${encodeURIComponent(plateNumber)}`)
  }

  // 查詢車輛保養記錄
  async getMaintenanceRecords(plateNumber) {
    return this.request(`/vehicles/${encodeURIComponent(plateNumber)}/maintenance`)
  }

  // 根據日期查詢保養記錄
  async getMaintenanceRecordsByDate(plateNumber, date) {
    return this.request(`/vehicles/${encodeURIComponent(plateNumber)}/maintenance?date=${date}`)
  }

  // 查詢所有可用的保養日期
  async getAvailableDates(plateNumber) {
    return this.request(`/vehicles/${encodeURIComponent(plateNumber)}/maintenance/dates`)
  }
}

// 建立單例實例
const apiService = new ApiService()

export default apiService

// 使用範例：
// import apiService from '@/services/api'
// 
// // 查詢車輛資訊
// const vehicleInfo = await apiService.getVehicleInfo('ABC-1234')
// 
// // 查詢保養記錄
// const records = await apiService.getMaintenanceRecords('ABC-1234')
// 
// // 根據日期查詢
// const recordsByDate = await apiService.getMaintenanceRecordsByDate('ABC-1234', '2024-01-15')
