<template>
  <div class="maintenance-form">
    <!-- 這個元件現在主要用於顯示保養項目說明 -->
    <div class="maintenance-info">
      <h3>常見保養項目說明</h3>
      <div class="maintenance-items-info">
        <div v-for="(item, key) in maintenanceItemsInfo" :key="key" class="item-info">
          <span class="item-name">{{ item.name }}</span>
          <span class="item-description">{{ item.description }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'MaintenanceForm',
  data() {
    return {
      maintenanceItemsInfo: {
        'oil_change': {
          name: '機油更換',
          description: '定期更換引擎機油，保持引擎正常運轉'
        },
        'filter_change': {
          name: '濾清器更換',
          description: '更換機油濾清器、空氣濾清器等，確保過濾效果'
        },
        'brake_check': {
          name: '煞車檢查',
          description: '檢查煞車片、煞車油、煞車系統運作狀況'
        },
        'tire_check': {
          name: '輪胎檢查',
          description: '檢查輪胎磨損、胎壓、輪胎平衡及定位'
        },
        'battery_check': {
          name: '電瓶檢查',
          description: '檢查電瓶電量、電極清潔度、充電系統'
        },
        'engine_check': {
          name: '引擎檢查',
          description: '檢查引擎運轉狀況、點火系統、燃油系統'
        },
        'transmission_check': {
          name: '變速箱檢查',
          description: '檢查變速箱油、離合器、傳動系統'
        },
        'air_conditioning': {
          name: '冷氣系統',
          description: '檢查冷媒、冷氣濾網、空調系統運作'
        },
        'electrical_system': {
          name: '電系檢查',
          description: '檢查車燈、電路、電子設備運作狀況'
        },
        'other': {
          name: '其他',
          description: '其他特殊保養項目或維修項目'
        }
      }
    }
  }
}
</script>

<style scoped>
.maintenance-form {
  background: white;
  border-radius: 12px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  margin-bottom: 2rem;
}

.maintenance-info h3 {
  margin-bottom: 1.5rem;
  color: #333;
  text-align: center;
}

.maintenance-items-info {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 1rem;
}

.item-info {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  padding: 1rem;
  background: #f8f9fa;
  border-radius: 8px;
  border-left: 4px solid #667eea;
}

.item-name {
  font-weight: bold;
  color: #667eea;
  font-size: 1.1rem;
}

.item-description {
  color: #666;
  font-size: 0.9rem;
  line-height: 1.4;
}

@media (max-width: 768px) {
  .maintenance-items-info {
    grid-template-columns: 1fr;
  }
  
  .item-info {
    padding: 0.75rem;
  }
}
</style>
