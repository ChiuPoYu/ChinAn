<template>
  <div id="app">
    <header class="header">
      <div class="header-content">
        <h1>🚗 車輛保養查詢系統</h1>
        <p class="subtitle">客戶查詢端</p>
      </div>
      
      <!-- 頁面選擇導航 -->
      <nav class="page-navigation">
        <button 
          class="nav-button" 
          :class="{ active: currentPage === 'maintenance' }"
          @click="switchPage('maintenance')"
        >
          <span class="nav-icon">🔧</span>
          保養紀錄
        </button>
        <button 
          class="nav-button" 
          :class="{ active: currentPage === 'parts' }"
          @click="switchPage('parts')"
        >
          <span class="nav-icon">📊</span>
          耗材替換里程
        </button>
      </nav>
    </header>
    
    <main class="main-content">
      <!-- 車輛資訊查詢 -->
      <div class="search-section" v-if="false">
        <h2>車輛資訊查詢</h2>
        <div class="search-form">
          <input 
            v-model="searchPlateNumber" 
            type="text" 
            placeholder="請輸入車牌號碼"
            @keyup.enter="searchVehicle"
          >
          <button @click="searchVehicle" class="btn btn-primary">查詢</button>
        </div>
      </div>

      <!-- 載入狀態 -->
      <div v-if="loading" class="loading">
        <div class="spinner"></div>
        <p>正在查詢車輛資訊...</p>
      </div>

      <!-- 錯誤訊息 -->
      <div v-if="error" class="error-message">
        <p>{{ error }}</p>
      </div>

      <!-- 頁面內容切換 -->
      <div v-if="vehicleInfo" class="page-content">
        <!-- 車輛基本資訊 -->
        <div class="vehicle-card">
          <h3>車輛基本資訊</h3>
          <div class="info-grid">
            <div class="info-item">
              <label>車牌號碼</label>
              <span class="plate-number">{{ vehicleInfo.plateNumber }}</span>
            </div>
            <div class="info-item">
              <label>車型</label>
              <span>{{ vehicleInfo.model }}</span>
            </div>
            <div class="info-item">
              <label>車主</label>
              <span>{{ vehicleInfo.owner }}</span>
            </div>
            <div class="info-item">
              <label>目前里程數</label>
              <span class="mileage">{{ vehicleInfo.currentMileage }} km</span>
            </div>
          </div>
        </div>

        <!-- 保養歷史記錄頁面 -->
        <transition name="page-slide" mode="out-in">
          <div v-if="currentPage === 'maintenance'" key="maintenance" class="page-maintenance">
            <div class="maintenance-history">
              <h3>保養歷史記錄</h3>
              
              <!-- 日期篩選 -->
              <div class="date-filter">
                <label>選擇查看日期：</label>
                <select v-model="selectedDate" @change="filterMaintenanceRecords">
                  <option value="">全部記錄</option>
                  <option v-for="date in availableDates" :key="date" :value="date">
                    {{ formatDate(date) }}
                  </option>
                </select>
              </div>

              <!-- 保養記錄列表 -->
              <div class="maintenance-records">
                <div 
                  v-for="record in filteredMaintenanceRecords" 
                  :key="record.id" 
                  class="maintenance-record"
                >
                  <div class="record-header">
                    <h4>{{ formatDate(record.date) }}</h4>
                    <span class="mileage">里程數: {{ record.mileage }} km</span>
                  </div>
                  
                  <div class="record-content">
                    <div class="maintenance-items">
                      <h5>保養項目：</h5>
                      <div class="items-grid">
                        <span 
                          v-for="item in record.maintenanceItems" 
                          :key="item" 
                          class="maintenance-item"
                        >
                          {{ getMaintenanceItemName(item) }}
                        </span>
                      </div>
                    </div>
                    
                    <div v-if="record.description" class="description">
                      <h5>保養內容：</h5>
                      <p>{{ record.description }}</p>
                    </div>
                    
                    <div class="record-footer">
                      <span class="cost">費用: NT$ {{ record.cost || '未記錄' }}</span>
                      <span class="technician">技師: {{ record.technician || '未記錄' }}</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <!-- 耗材替換里程頁面 -->
          <div v-else-if="currentPage === 'parts'" key="parts" class="page-parts">
            <PartsReplacementTable 
              :vehicle-info="vehicleInfo"
              :maintenance-records="maintenanceRecords"
            />
          </div>
        </transition>
      </div>

      <!-- 無資料顯示 -->
      <div v-if="!vehicleInfo && !loading && !error" class="no-data">
        <p>請輸入車牌號碼查詢車輛保養資訊</p>
      </div>
    </main>

    <!-- Footer -->
    <footer class="footer">
      <div class="footer-content">
        <div class="footer-section">
          <h4>聯絡資訊</h4>
          <div class="contact-info">
            <div class="contact-item">
              <span class="contact-icon">📞</span>
              <span>電話：03-334-0713</span>
            </div>
            <div class="contact-item">
              <span class="contact-icon">🏢</span>
              <span>慶安汽車保養廠</span>
            </div>
            <div class="contact-item">
              <span class="contact-icon">🕒</span>
              <span>營業時間：週一至週六 08:00-18:00</span>
            </div>
          </div>
        </div>
        
        <div class="footer-section">
          <h4>服務項目</h4>
          <ul class="service-list">
            <li>車輛保養維修</li>
            <li>耗材更換</li>
            <li>故障檢測</li>
            <li>定期檢查</li>
          </ul>
        </div>
        
        <div class="footer-section">
          <h4>關於我們</h4>
          <p>專業的汽車保養服務，提供完整的車輛維護解決方案，讓您的愛車保持最佳狀態。</p>
        </div>
      </div>
      
      <div class="footer-bottom">
        <p>&copy; 2024 慶安汽車保養廠. 版權所有.</p>
      </div>
    </footer>
  </div>
</template>

<script>
import PartsReplacementTable from './components/PartsReplacementTable.vue'

// 暫時移除 API 服務導入，避免錯誤
// import apiService from './services/api.js'

export default {
  name: 'App',
  components: {
    PartsReplacementTable
  },
  data() {
    return {
      searchPlateNumber: '',
      loading: false,
      error: null,
      vehicleInfo: null,
      maintenanceRecords: [],
      selectedDate: '',
      availableDates: [],
      currentPage: 'maintenance',
      useMockData: true
    }
  },
  mounted() {
    // 頁面載入後自動查詢指定車牌
    this.searchPlateNumber = 'ABC'
    this.searchVehicle()
  },
  computed: {
    filteredMaintenanceRecords() {
      if (!this.selectedDate) {
        return this.maintenanceRecords
      }
      return this.maintenanceRecords.filter(record => record.date === this.selectedDate)
    }
  },
  methods: {
    /*switchPage(page) {
      this.currentPage = page
    },*/

    async searchVehicle() {
      if (!this.searchPlateNumber.trim()) {
        this.error = '請輸入車牌號碼'
        return
      }

      this.loading = true
      this.error = null
      this.vehicleInfo = null
      this.maintenanceRecords = []

      try {
        if (this.useMockData) {
          await this.fetchMockVehicleData(this.searchPlateNumber.trim())
        } else {
          await this.fetchRealVehicleData(this.searchPlateNumber.trim())
        }
      } catch (err) {
        this.error = '查詢失敗，請稍後再試'
        console.error('API Error:', err)
      } finally {
        this.loading = false
      }
    },

    async fetchRealVehicleData(plateNumber) {
      // 暫時使用模擬資料，避免 API 錯誤
      await this.fetchMockVehicleData(plateNumber)
      
      // TODO: 當 API 服務器準備好時，取消註釋以下代碼
      /*
      try {
        const [vehicleInfo, maintenanceRecords] = await Promise.all([
          apiService.getVehicleInfo(plateNumber),
          apiService.getMaintenanceRecords(plateNumber)
        ])

        this.vehicleInfo = vehicleInfo
        this.maintenanceRecords = maintenanceRecords
        this.availableDates = [...new Set(maintenanceRecords.map(record => record.date))].sort().reverse()
      } catch (error) {
        throw new Error(`無法取得車輛資料: ${error.message}`)
      }
      */
    },

    async fetchMockVehicleData(plateNumber) {
      // 模擬 API 延遲
      await new Promise(resolve => setTimeout(resolve, 1000))

      // 模擬 API 回傳資料
      const mockData = {
        plateNumber: plateNumber,
        model: 'Toyota Camry',
        owner: '王小明',
        currentMileage: 90000,
        maintenanceRecords: [
          {
            id: 1,
            date: '2024-01-15',
            mileage: 82000,
            maintenanceItems: ['oil_change', 'filter_change', 'brake_check'],
            description: '定期保養，更換機油及濾清器，檢查煞車系統',
            cost: 2500,
            technician: '李技師'
          },
          {
            id: 2,
            date: '2023-10-20',
            mileage: 78000,
            maintenanceItems: ['tire_check', 'battery_check', 'engine_check'],
            description: '輪胎檢查及電瓶檢測，引擎系統檢查',
            cost: 1800,
            technician: '陳技師'
          },
          {
            id: 3,
            date: '2023-07-10',
            mileage: 75000,
            maintenanceItems: ['oil_change', 'air_conditioning', 'electrical_system'],
            description: '機油更換，冷氣系統保養，電系檢查',
            cost: 3200,
            technician: '張技師'
          },
          {
            id: 4,
            date: '2023-04-05',
            mileage: 72000,
            maintenanceItems: ['transmission_check', 'electrical_system'],
            description: '變速箱檢查，電系系統維護',
            cost: 2800,
            technician: '王技師'
          },
          {
            id: 5,
            date: '2023-01-20',
            mileage: 68000,
            maintenanceItems: ['oil_change', 'filter_change', 'tire_check'],
            description: '定期保養，機油更換，輪胎檢查',
            cost: 2200,
            technician: '李技師'
          }
        ]
      }

      this.vehicleInfo = {
        plateNumber: mockData.plateNumber,
        model: mockData.model,
        owner: mockData.owner,
        currentMileage: mockData.currentMileage
      }

      this.maintenanceRecords = mockData.maintenanceRecords
      this.availableDates = [...new Set(mockData.maintenanceRecords.map(record => record.date))].sort().reverse()
    },

    filterMaintenanceRecords() {
      // 篩選邏輯已在 computed 中處理
    },

    formatDate(dateString) {
      const date = new Date(dateString)
      return date.toLocaleDateString('zh-TW', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit'
      })
    },

    getMaintenanceItemName(item) {
      const itemNames = {
        'oil_change': '機油更換',
        'filter_change': '濾清器更換',
        'brake_check': '煞車檢查',
        'tire_check': '輪胎檢查',
        'battery_check': '電瓶檢查',
        'engine_check': '引擎檢查',
        'transmission_check': '變速箱檢查',
        'air_conditioning': '冷氣系統',
        'electrical_system': '電系檢查',
        'other': '其他'
      }
      return itemNames[item] || item
    }
  }
}
</script>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  background-color: #f5f5f5;
  color: #333;
}

#app {
  min-height: 100vh;
}

.header {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 2rem;
  text-align: center;
}

.header-content {
  margin-bottom: 1.5rem;
}

.header h1 {
  font-size: 2.5rem;
  margin-bottom: 0.5rem;
}

.subtitle {
  font-size: 1.2rem;
  opacity: 0.9;
}

.page-navigation {
  display: flex;
  justify-content: center;
  gap: 1rem;
  margin-top: 1rem;
}

.nav-button {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  padding: 0.75rem 1.5rem;
  background: rgba(255, 255, 255, 0.1);
  border: 2px solid rgba(255, 255, 255, 0.3);
  border-radius: 8px;
  color: white;
  font-size: 1rem;
  font-weight: 500;
  cursor: pointer;
  transition: all 0.3s ease;
  backdrop-filter: blur(10px);
}

.nav-button:hover {
  background: rgba(255, 255, 255, 0.2);
  border-color: rgba(255, 255, 255, 0.5);
  transform: translateY(-2px);
}

.nav-button.active {
  background: rgba(255, 255, 255, 0.9);
  color: #667eea;
  border-color: white;
}

.nav-icon {
  font-size: 1.2rem;
}

.main-content {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
  min-height: calc(100vh - 200px);
}

.page-content {
  display: grid;
  gap: 2rem;
}

/* 頁面切換動畫 */
.page-slide-enter-active,
.page-slide-leave-active {
  transition: all 0.4s ease;
}

.page-slide-enter-from {
  opacity: 0;
  transform: translateX(30px);
}

.page-slide-leave-to {
  opacity: 0;
  transform: translateX(-30px);
}

.page-maintenance,
.page-parts {
  min-height: 400px;
}

.search-section {
  background: white;
  border-radius: 12px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  margin-bottom: 2rem;
}

.search-section h2 {
  margin-bottom: 1rem;
  color: #333;
}

.search-form {
  display: flex;
  gap: 1rem;
  align-items: center;
}

.search-form input {
  flex: 1;
  padding: 0.75rem;
  border: 2px solid #e2e8f0;
  border-radius: 6px;
  font-size: 1rem;
}

.search-form input:focus {
  outline: none;
  border-color: #667eea;
}

.btn {
  padding: 0.75rem 1.5rem;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 500;
  transition: all 0.3s ease;
}

.btn-primary {
  background: #667eea;
  color: white;
}

.btn-primary:hover {
  background: #5a6fd8;
  transform: translateY(-2px);
}

.loading {
  text-align: center;
  padding: 2rem;
}

.spinner {
  width: 40px;
  height: 40px;
  border: 4px solid #f3f3f3;
  border-top: 4px solid #667eea;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  margin: 0 auto 1rem;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.error-message {
  background: #fed7d7;
  color: #c53030;
  padding: 1rem;
  border-radius: 6px;
  margin-bottom: 2rem;
  text-align: center;
}

.vehicle-info-section {
  display: grid;
  gap: 2rem;
}

.vehicle-card {
  background: white;
  border-radius: 12px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.vehicle-card h3 {
  margin-bottom: 1.5rem;
  color: #333;
}

.info-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 1rem;
}

.info-item {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.info-item label {
  font-weight: 500;
  color: #666;
  font-size: 0.9rem;
}

.info-item span {
  font-size: 1.1rem;
  color: #333;
}

.plate-number {
  font-weight: bold;
  color: #667eea;
  font-size: 1.3rem;
}

.mileage {
  font-weight: bold;
  color: #48bb78;
}

.maintenance-history {
  background: white;
  border-radius: 12px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.maintenance-history h3 {
  margin-bottom: 1.5rem;
  color: #333;
}

.date-filter {
  margin-bottom: 2rem;
  display: flex;
  align-items: center;
  gap: 1rem;
}

.date-filter label {
  font-weight: 500;
  color: #666;
}

.date-filter select {
  padding: 0.5rem;
  border: 2px solid #e2e8f0;
  border-radius: 6px;
  font-size: 1rem;
}

.maintenance-records {
  display: grid;
  gap: 1.5rem;
}

.maintenance-record {
  border: 1px solid #e2e8f0;
  border-radius: 8px;
  padding: 1.5rem;
  background: #f8f9fa;
}

.record-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
  padding-bottom: 0.5rem;
  border-bottom: 1px solid #e2e8f0;
}

.record-header h4 {
  color: #333;
  font-size: 1.2rem;
}

.maintenance-items h5,
.description h5 {
  margin-bottom: 0.5rem;
  color: #666;
  font-size: 0.9rem;
}

.items-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(120px, 1fr));
  gap: 0.5rem;
  margin-bottom: 1rem;
}

.maintenance-item {
  background: #667eea;
  color: white;
  padding: 0.25rem 0.5rem;
  border-radius: 4px;
  font-size: 0.8rem;
  text-align: center;
}

.description p {
  color: #666;
  line-height: 1.5;
  margin-bottom: 1rem;
}

.record-footer {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-size: 0.9rem;
  color: #666;
}

.cost {
  font-weight: bold;
  color: #48bb78;
}

.technician {
  font-style: italic;
}

.no-data {
  text-align: center;
  padding: 3rem;
  color: #666;
  font-size: 1.1rem;
}

@media (max-width: 768px) {
  .header h1 {
    font-size: 2rem;
  }
  
  .main-content {
    padding: 1rem;
  }
  
  .search-form {
    flex-direction: column;
  }
  
  .search-form input,
  .btn {
    width: 100%;
  }
  
  .info-grid {
    grid-template-columns: 1fr;
  }
  
  .record-header {
    flex-direction: column;
    align-items: flex-start;
    gap: 0.5rem;
  }
  
  .record-footer {
    flex-direction: column;
    align-items: flex-start;
    gap: 0.5rem;
  }
  
  .items-grid {
    grid-template-columns: 1fr;
  }
  
  .page-navigation {
    flex-direction: column;
    gap: 0.5rem;
  }
  
  .nav-button {
    justify-content: center;
  }
}

/* Footer 樣式 */
.footer {
  background: linear-gradient(135deg, #2d3748 0%, #4a5568 100%);
  color: white;
  margin-top: 3rem;
  padding: 2rem 0 1rem;
}

.footer-content {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 2rem;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 2rem;
  margin-bottom: 2rem;
}

.footer-section h4 {
  margin-bottom: 1rem;
  color: #e2e8f0;
  font-size: 1.2rem;
}

.contact-info {
  display: flex;
  flex-direction: column;
  gap: 0.75rem;
}

.contact-item {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  color: #cbd5e0;
}

.contact-icon {
  font-size: 1.1rem;
  width: 20px;
}

.service-list {
  list-style: none;
  padding: 0;
}

.service-list li {
  padding: 0.25rem 0;
  color: #cbd5e0;
  position: relative;
  padding-left: 1rem;
}

.service-list li:before {
  content: "•";
  color: #667eea;
  position: absolute;
  left: 0;
}

.footer-section p {
  color: #cbd5e0;
  line-height: 1.6;
}

.footer-bottom {
  border-top: 1px solid #4a5568;
  padding-top: 1rem;
  text-align: center;
  color: #a0aec0;
}

@media (max-width: 768px) {
  .footer-content {
    grid-template-columns: 1fr;
    padding: 0 1rem;
  }
  
  .footer {
    padding: 1.5rem 0 1rem;
  }
}
</style>