<template>
  <div class="parts-replacement-table">
    <div class="table-header">
      <h3>耗材替換里程記錄</h3>
      <p class="table-description">顯示各項耗材的替換歷史及下次建議更換里程</p>
    </div>

    <div class="table-container">
      <table class="parts-table">
        <thead>
          <tr>
            <th>耗材項目</th>
            <th>上次更換</th>
            <th>更換時里程</th>
            <th>建議間隔</th>
            <th>下次建議更換里程</th>
            <th>狀態</th>
          </tr>
        </thead>
        <tbody>
          <tr 
            v-for="part in partsData" 
            :key="part.id"
            :class="{ 'urgent': part.status === 'urgent', 'warning': part.status === 'warning' }"
          >
            <td class="part-name">
              <span class="part-icon">{{ part.icon }}</span>
              {{ part.name }}
            </td>
            <td class="last-change">{{ formatDate(part.lastChange) }}</td>
            <td class="change-mileage">{{ part.changeMileage.toLocaleString() }} km</td>
            <td class="interval">{{ part.interval }} km</td>
            <td class="next-change">{{ part.nextChange.toLocaleString() }} km</td>
            <td class="status">
              <span :class="['status-badge', part.status]">
                {{ getStatusText(part.status) }}
              </span>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- 建議區域 -->
    <div class="recommendations">
      <h4>保養建議</h4>
      <div class="recommendation-cards">
        <div 
          v-for="recommendation in recommendations" 
          :key="recommendation.id"
          :class="['recommendation-card', recommendation.type]"
        >
          <div class="recommendation-icon">{{ recommendation.icon }}</div>
          <div class="recommendation-content">
            <h5>{{ recommendation.title }}</h5>
            <p>{{ recommendation.description }}</p>
            <div v-if="recommendation.estimatedCost" class="estimated-cost">
              預估費用: NT$ {{ recommendation.estimatedCost }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PartsReplacementTable',
  props: {
    vehicleInfo: {
      type: Object,
      required: true
    },
    maintenanceRecords: {
      type: Array,
      required: true
    }
  },
  computed: {
    partsData() {
      const currentMileage = this.vehicleInfo.currentMileage
      
      return [
        {
          id: 1,
          name: '機油',
          icon: '🛢️',
          lastChange: '2024-01-15',
          changeMileage: 85000,
          interval: 5000,
          nextChange: 87000,
          status: this.getPartStatus(currentMileage, 87000, 85000)
        },
        {
          id: 2,
          name: '機油濾清器',
          icon: '🔧',
          lastChange: '2024-01-15',
          changeMileage: 80000,
          interval: 5000,
          nextChange: 87000,
          status: this.getPartStatus(currentMileage, 87000, 88000)
        },
        {
          id: 3,
          name: '空氣濾清器',
          icon: '💨',
          lastChange: '2023-10-20',
          changeMileage: 78000,
          interval: 15000,
          nextChange: 93000,
          status: this.getPartStatus(currentMileage, 93000, 90000)
        },
        {
          id: 4,
          name: '煞車片',
          icon: '🛑',
          lastChange: '2023-07-10',
          changeMileage: 75000,
          interval: 30000,
          nextChange: 105000,
          status: this.getPartStatus(currentMileage, 105000, 95000)
        },
        {
          id: 5,
          name: '變速箱油',
          icon: '⚙️',
          lastChange: '2023-04-05',
          changeMileage: 72000,
          interval: 40000,
          nextChange: 112000,
          status: this.getPartStatus(currentMileage, 112000, 100000)
        },
        {
          id: 6,
          name: '電瓶',
          icon: '🔋',
          lastChange: '2023-01-20',
          changeMileage: 68000,
          interval: 50000,
          nextChange: 118000,
          status: this.getPartStatus(currentMileage, 118000, 110000)
        },
        {
          id: 7,
          name: '輪胎',
          icon: '🛞',
          lastChange: '2022-12-15',
          changeMileage: 65000,
          interval: 60000,
          nextChange: 125000,
          status: this.getPartStatus(currentMileage, 125000, 120000)
        },
        {
          id: 8,
          name: '冷氣濾網',
          icon: '❄️',
          lastChange: '2023-10-20',
          changeMileage: 78000,
          interval: 10000,
          nextChange: 88000,
          status: this.getPartStatus(currentMileage, 88000, 86000)
        }
      ]
    },
    recommendations() {
      const currentMileage = this.vehicleInfo.currentMileage
      const recs = []

      // 檢查緊急項目
      this.partsData.forEach(part => {
        if (part.status === 'urgent') {
          recs.push({
            id: `urgent-${part.id}`,
            type: 'urgent',
            icon: '⚠️',
            title: `立即更換${part.name}`,
            description: `${part.name}已超過建議更換里程，建議立即處理`,
            estimatedCost: this.getEstimatedCost(part.name)
          })
        }
      })

      // 檢查警告項目
      this.partsData.forEach(part => {
        if (part.status === 'warning') {
          recs.push({
            id: `warning-${part.id}`,
            type: 'warning',
            icon: '⏰',
            title: `${part.name}即將到期`,
            description: `建議在 ${part.nextChange.toLocaleString()} km 時更換${part.name}`,
            estimatedCost: this.getEstimatedCost(part.name)
          })
        }
      })

      return recs
    }
  },
  methods: {
    getPartStatus(currentMileage, nextChange, warningThreshold) {
      if (currentMileage >= nextChange) {
        return 'urgent'
      } else if (currentMileage >= warningThreshold) {
        return 'warning'
      } else {
        return 'normal'
      }
    },
    getStatusText(status) {
      const statusMap = {
        'normal': '正常',
        'warning': '注意',
        'urgent': '急需'
      }
      return statusMap[status] || '未知'
    },
    formatDate(dateString) {
      const date = new Date(dateString)
      return date.toLocaleDateString('zh-TW', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit'
      })
    },
    getEstimatedCost(partName) {
      const costMap = {
        '機油': 800,
        '機油濾清器': 200,
        '空氣濾清器': 600,
        '煞車片': 3000,
        '變速箱油': 2500,
        '電瓶': 4000,
        '輪胎': 12000,
        '冷氣濾網': 300
      }
      return costMap[partName] || 1000
    }
  }
}
</script>

<style scoped>
.parts-replacement-table {
  background: white;
  border-radius: 12px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.table-header {
  margin-bottom: 2rem;
  text-align: center;
}

.table-header h3 {
  color: #333;
  margin-bottom: 0.5rem;
  font-size: 1.5rem;
}

.table-description {
  color: #666;
  font-size: 1rem;
}

.table-container {
  overflow-x: auto;
  margin-bottom: 2rem;
}

.parts-table {
  width: 100%;
  border-collapse: collapse;
  background: white;
  border-radius: 8px;
  overflow: hidden;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.parts-table th {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 1rem;
  text-align: left;
  font-weight: 600;
  font-size: 0.9rem;
}

.parts-table td {
  padding: 1rem;
  border-bottom: 1px solid #e2e8f0;
  vertical-align: middle;
}

.parts-table tr:hover {
  background: #f8f9fa;
}

.parts-table tr.urgent {
  background: #fed7d7;
}

.parts-table tr.warning {
  background: #fef5e7;
}

.part-name {
  font-weight: 600;
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.part-icon {
  font-size: 1.2rem;
}

.last-change {
  color: #666;
}

.change-mileage,
.next-change {
  font-weight: 500;
  color: #333;
}

.interval {
  color: #666;
}

.status-badge {
  padding: 0.25rem 0.75rem;
  border-radius: 20px;
  font-size: 0.8rem;
  font-weight: 500;
  text-align: center;
  min-width: 60px;
  display: inline-block;
}

.status-badge.normal {
  background: #c6f6d5;
  color: #22543d;
}

.status-badge.warning {
  background: #faf089;
  color: #744210;
}

.status-badge.urgent {
  background: #fed7d7;
  color: #c53030;
}

.recommendations {
  margin-top: 2rem;
}

.recommendations h4 {
  color: #333;
  margin-bottom: 1rem;
}

.recommendation-cards {
  display: grid;
  gap: 1rem;
}

.recommendation-card {
  display: flex;
  align-items: flex-start;
  gap: 1rem;
  padding: 1rem;
  border-radius: 8px;
  border-left: 4px solid;
}

.recommendation-card.urgent {
  background: #fed7d7;
  border-left-color: #e53e3e;
}

.recommendation-card.warning {
  background: #fef5e7;
  border-left-color: #dd6b20;
}

.recommendation-icon {
  font-size: 1.5rem;
  margin-top: 0.25rem;
}

.recommendation-content h5 {
  margin-bottom: 0.5rem;
  color: #333;
}

.recommendation-content p {
  color: #666;
  margin-bottom: 0.5rem;
  line-height: 1.4;
}

.estimated-cost {
  font-weight: 600;
  color: #48bb78;
  font-size: 0.9rem;
}

@media (max-width: 768px) {
  .parts-table {
    font-size: 0.8rem;
  }
  
  .parts-table th,
  .parts-table td {
    padding: 0.5rem;
  }
  
  .recommendation-card {
    flex-direction: column;
    text-align: center;
  }
}
</style>