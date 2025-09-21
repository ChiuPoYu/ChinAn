<template>
  <div id="app">
    <header class="header">
      <h1>車輛保養管理系統</h1>
      <p class="subtitle">員工管理端</p>
    </header>
    
    <main class="main-content">
      <div class="dashboard">
        <div class="stats-grid">
          <div class="stat-card">
            <h3>總車輛數</h3>
            <p class="stat-number">{{ totalVehicles }}</p>
          </div>
          <div class="stat-card">
            <h3>待保養</h3>
            <p class="stat-number">{{ pendingMaintenance }}</p>
          </div>
          <div class="stat-card">
            <h3>本月完成</h3>
            <p class="stat-number">{{ completedThisMonth }}</p>
          </div>
        </div>
        
        <div class="action-section">
          <h2>快速操作</h2>
          <div class="action-buttons">
            <button @click="showAddVehicle = true" class="btn btn-primary">
              新增車輛
            </button>
            <button @click="showMaintenanceForm = true" class="btn btn-secondary">
              記錄保養
            </button>
            <button @click="showVehicleList = true" class="btn btn-outline">
              查看車輛列表
            </button>
          </div>
        </div>
      </div>
      
      <!-- 新增車輛表單 -->
      <div v-if="showAddVehicle" class="modal-overlay" @click="showAddVehicle = false">
        <div class="modal" @click.stop>
          <h3>新增車輛</h3>
          <form @submit.prevent="addVehicle">
            <div class="form-group">
              <label>車牌號碼</label>
              <input v-model="newVehicle.plateNumber" type="text" required>
            </div>
            <div class="form-group">
              <label>車型</label>
              <input v-model="newVehicle.model" type="text" required>
            </div>
            <div class="form-group">
              <label>車主姓名</label>
              <input v-model="newVehicle.owner" type="text" required>
            </div>
            <div class="form-group">
              <label>聯絡電話</label>
              <input v-model="newVehicle.phone" type="tel" required>
            </div>
            <div class="form-actions">
              <button type="button" @click="showAddVehicle = false" class="btn btn-outline">取消</button>
              <button type="submit" class="btn btn-primary">新增</button>
            </div>
          </form>
        </div>
      </div>
      
      <!-- 保養記錄表單 -->
      <MaintenanceForm 
        v-if="showMaintenanceForm" 
        @close="showMaintenanceForm = false"
        @submit="handleMaintenanceSubmit"
      />
      
      <!-- 車輛列表 -->
      <div v-if="showVehicleList" class="modal-overlay" @click="showVehicleList = false">
        <div class="modal large" @click.stop>
          <h3>車輛列表</h3>
          <div class="vehicle-list">
            <div v-for="vehicle in vehicles" :key="vehicle.id" class="vehicle-item">
              <div class="vehicle-info">
                <h4>{{ vehicle.plateNumber }}</h4>
                <p>{{ vehicle.model }} - {{ vehicle.owner }}</p>
                <p class="phone">{{ vehicle.phone }}</p>
              </div>
              <div class="vehicle-actions">
                <button @click="editVehicle(vehicle)" class="btn btn-sm btn-outline">編輯</button>
                <button @click="deleteVehicle(vehicle.id)" class="btn btn-sm btn-danger">刪除</button>
              </div>
            </div>
          </div>
          <div class="form-actions">
            <button @click="showVehicleList = false" class="btn btn-outline">關閉</button>
          </div>
        </div>
      </div>
    </main>
  </div>
</template>

<script>
import MaintenanceForm from './components/MaintenanceForm.vue'

export default {
  name: 'App',
  components: {
    MaintenanceForm
  },
  data() {
    return {
      showAddVehicle: false,
      showMaintenanceForm: false,
      showVehicleList: false,
      totalVehicles: 0,
      pendingMaintenance: 0,
      completedThisMonth: 0,
      vehicles: [],
      newVehicle: {
        plateNumber: '',
        model: '',
        owner: '',
        phone: ''
      }
    }
  },
  mounted() {
    this.loadData()
  },
  methods: {
    loadData() {
      // 模擬載入資料
      this.vehicles = [
        {
          id: 1,
          plateNumber: 'ABC-1234',
          model: 'Toyota Camry',
          owner: '王小明',
          phone: '0912-345-678'
        },
        {
          id: 2,
          plateNumber: 'DEF-5678',
          model: 'Honda Civic',
          owner: '李小華',
          phone: '0987-654-321'
        }
      ]
      this.totalVehicles = this.vehicles.length
      this.pendingMaintenance = 3
      this.completedThisMonth = 12
    },
    addVehicle() {
      const vehicle = {
        id: Date.now(),
        ...this.newVehicle
      }
      this.vehicles.push(vehicle)
      this.totalVehicles = this.vehicles.length
      this.newVehicle = { plateNumber: '', model: '', owner: '', phone: '' }
      this.showAddVehicle = false
    },
    editVehicle(vehicle) {
      // 編輯車輛邏輯
      console.log('編輯車輛:', vehicle)
    },
    deleteVehicle(id) {
      if (confirm('確定要刪除這輛車嗎？')) {
        this.vehicles = this.vehicles.filter(v => v.id !== id)
        this.totalVehicles = this.vehicles.length
      }
    },
    handleMaintenanceSubmit(maintenanceData) {
      console.log('保養記錄:', maintenanceData)
      this.showMaintenanceForm = false
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

.header h1 {
  font-size: 2.5rem;
  margin-bottom: 0.5rem;
}

.subtitle {
  font-size: 1.2rem;
  opacity: 0.9;
}

.main-content {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

.dashboard {
  background: white;
  border-radius: 12px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  margin-bottom: 2rem;
}

.stats-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 1.5rem;
  margin-bottom: 2rem;
}

.stat-card {
  background: linear-gradient(135deg, #f093fb 0%, #f5576c 100%);
  color: white;
  padding: 1.5rem;
  border-radius: 8px;
  text-align: center;
}

.stat-card h3 {
  font-size: 1rem;
  margin-bottom: 0.5rem;
  opacity: 0.9;
}

.stat-number {
  font-size: 2rem;
  font-weight: bold;
}

.action-section h2 {
  margin-bottom: 1rem;
  color: #333;
}

.action-buttons {
  display: flex;
  gap: 1rem;
  flex-wrap: wrap;
}

.btn {
  padding: 0.75rem 1.5rem;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 500;
  transition: all 0.3s ease;
  text-decoration: none;
  display: inline-block;
}

.btn-primary {
  background: #667eea;
  color: white;
}

.btn-primary:hover {
  background: #5a6fd8;
  transform: translateY(-2px);
}

.btn-secondary {
  background: #48bb78;
  color: white;
}

.btn-secondary:hover {
  background: #38a169;
  transform: translateY(-2px);
}

.btn-outline {
  background: transparent;
  color: #667eea;
  border: 2px solid #667eea;
}

.btn-outline:hover {
  background: #667eea;
  color: white;
}

.btn-danger {
  background: #f56565;
  color: white;
}

.btn-danger:hover {
  background: #e53e3e;
}

.btn-sm {
  padding: 0.5rem 1rem;
  font-size: 0.875rem;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
}

.modal {
  background: white;
  border-radius: 12px;
  padding: 2rem;
  max-width: 500px;
  width: 90%;
  max-height: 80vh;
  overflow-y: auto;
}

.modal.large {
  max-width: 800px;
}

.modal h3 {
  margin-bottom: 1.5rem;
  color: #333;
}

.form-group {
  margin-bottom: 1rem;
}

.form-group label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: 500;
  color: #555;
}

.form-group input {
  width: 100%;
  padding: 0.75rem;
  border: 2px solid #e2e8f0;
  border-radius: 6px;
  font-size: 1rem;
  transition: border-color 0.3s ease;
}

.form-group input:focus {
  outline: none;
  border-color: #667eea;
}

.form-actions {
  display: flex;
  gap: 1rem;
  justify-content: flex-end;
  margin-top: 1.5rem;
}

.vehicle-list {
  max-height: 400px;
  overflow-y: auto;
}

.vehicle-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  border: 1px solid #e2e8f0;
  border-radius: 6px;
  margin-bottom: 0.5rem;
}

.vehicle-info h4 {
  color: #333;
  margin-bottom: 0.25rem;
}

.vehicle-info p {
  color: #666;
  font-size: 0.9rem;
}

.vehicle-info .phone {
  color: #999;
  font-size: 0.8rem;
}

.vehicle-actions {
  display: flex;
  gap: 0.5rem;
}

@media (max-width: 768px) {
  .header h1 {
    font-size: 2rem;
  }
  
  .main-content {
    padding: 1rem;
  }
  
  .action-buttons {
    flex-direction: column;
  }
  
  .btn {
    width: 100%;
  }
  
  .vehicle-item {
    flex-direction: column;
    align-items: flex-start;
    gap: 1rem;
  }
  
  .vehicle-actions {
    width: 100%;
    justify-content: flex-end;
  }
}
</style>
