<template>
  <div class="container">
    <h1>🚗 車輛維護系統</h1>
    <MaintenanceForm @addRecord="addRecord" />
    <h2>維護紀錄</h2>
    <ul>
      <li v-for="(record, index) in records" :key="index">
        {{ record.date }} - {{ record.vehicle }} - {{ record.task }}
        <button @click="deleteRecord(index)">刪除</button>
      </li>
    </ul>
  </div>
</template>

<script>
import MaintenanceForm from './components/MaintenanceForm.vue'

export default {
  components: { MaintenanceForm },
  data() {
    return {
      records: []
    }
  },
  methods: {
    addRecord(record) {
      this.records.push(record)
    },
    deleteRecord(index) {
      this.records.splice(index, 1)
    }
  }
}
</script>

<style>
.container {
  max-width: 600px;
  margin: auto;
  font-family: sans-serif;
}
button {
  margin-left: 10px;
}
</style>
