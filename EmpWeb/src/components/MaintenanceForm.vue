<template>
  <div class="modal-overlay" @click="$emit('close')">
    <div class="modal" @click.stop>
      <h3>記錄保養</h3>
      <form @submit.prevent="submitForm">
        <div class="form-group">
          <label>車牌號碼</label>
          <select v-model="formData.vehicleId" required>
            <option value="">請選擇車輛</option>
            <option v-for="vehicle in vehicles" :key="vehicle.id" :value="vehicle.id">
              {{ vehicle.plateNumber }} - {{ vehicle.model }}
            </option>
          </select>
        </div>
        
        <div class="form-group">
          <label>保養類型</label>
          <select v-model="formData.maintenanceType" required>
            <option value="">請選擇保養類型</option>
            <option value="regular">定期保養</option>
            <option value="repair">維修</option>
            <option value="inspection">檢查</option>
            <option value="emergency">緊急維修</option>
          </select>
        </div>
        
        <div class="form-group">
          <label>保養日期</label>
          <input v-model="formData.date" type="date" required>
        </div>
        
        <div class="form-group">
          <label>里程數</label>
          <input v-model="formData.mileage" type="number" placeholder="請輸入里程數">
        </div>
        
        <div class="form-group">
          <label>保養項目</label>
          <div class="checkbox-group">
            <label v-for="item in maintenanceItems" :key="item.value" class="checkbox-item">
              <input 
                type="checkbox" 
                :value="item.value" 
                v-model="formData.items"
              >
              {{ item.label }}
            </label>
          </div>
        </div>
        
        <div class="form-group">
          <label>保養內容描述</label>
          <textarea 
            v-model="formData.description" 
            rows="4" 
            placeholder="請詳細描述保養內容..."
          ></textarea>
        </div>
        
        <div class="form-group">
          <label>費用</label>
          <input v-model="formData.cost" type="number" step="0.01" placeholder="請輸入費用">
        </div>
        
        <div class="form-group">
          <label>技師</label>
          <input v-model="formData.technician" type="text" placeholder="請輸入技師姓名">
        </div>
        
        <div class="form-group">
          <label>下次保養提醒</label>
          <input v-model="formData.nextMaintenanceDate" type="date">
        </div>
        
        <div class="form-actions">
          <button type="button" @click="$emit('close')" class="btn btn-outline">取消</button>
          <button type="submit" class="btn btn-primary">儲存記錄</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: 'MaintenanceForm',
  props: {
    vehicles: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      formData: {
        vehicleId: '',
        maintenanceType: '',
        date: new Date().toISOString().split('T')[0],
        mileage: '',
        items: [],
        description: '',
        cost: '',
        technician: '',
        nextMaintenanceDate: ''
      },
      maintenanceItems: [
        { value: 'oil_change', label: '機油更換' },
        { value: 'filter_change', label: '濾清器更換' },
        { value: 'brake_check', label: '煞車檢查' },
        { value: 'tire_check', label: '輪胎檢查' },
        { value: 'battery_check', label: '電瓶檢查' },
        { value: 'engine_check', label: '引擎檢查' },
        { value: 'transmission_check', label: '變速箱檢查' },
        { value: 'air_conditioning', label: '冷氣系統' },
        { value: 'electrical_system', label: '電系檢查' },
        { value: 'other', label: '其他' }
      ]
    }
  },
  methods: {
    submitForm() {
      const maintenanceRecord = {
        id: Date.now(),
        ...this.formData,
        items: this.formData.items.join(', '),
        createdAt: new Date().toISOString()
      }
      
      this.$emit('submit', maintenanceRecord)
      
      // 重置表單
      this.formData = {
        vehicleId: '',
        maintenanceType: '',
        date: new Date().toISOString().split('T')[0],
        mileage: '',
        items: [],
        description: '',
        cost: '',
        technician: '',
        nextMaintenanceDate: ''
      }
    }
  }
}
</script>

<style scoped>
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
  max-width: 600px;
  width: 90%;
  max-height: 80vh;
  overflow-y: auto;
}

.modal h3 {
  margin-bottom: 1.5rem;
  color: #333;
}

.form-group {
  margin-bottom: 1.5rem;
}

.form-group label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: 500;
  color: #555;
}

.form-group input,
.form-group select,
.form-group textarea {
  width: 100%;
  padding: 0.75rem;
  border: 2px solid #e2e8f0;
  border-radius: 6px;
  font-size: 1rem;
  transition: border-color 0.3s ease;
}

.form-group input:focus,
.form-group select:focus,
.form-group textarea:focus {
  outline: none;
  border-color: #667eea;
}

.checkbox-group {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 0.5rem;
  margin-top: 0.5rem;
}

.checkbox-item {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  font-weight: normal;
  cursor: pointer;
}

.checkbox-item input[type="checkbox"] {
  width: auto;
  margin: 0;
}

.form-actions {
  display: flex;
  gap: 1rem;
  justify-content: flex-end;
  margin-top: 2rem;
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

@media (max-width: 768px) {
  .modal {
    padding: 1rem;
  }
  
  .checkbox-group {
    grid-template-columns: 1fr;
  }
  
  .form-actions {
    flex-direction: column;
  }
  
  .btn {
    width: 100%;
  }
}
</style>
