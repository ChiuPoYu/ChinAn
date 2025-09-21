<template>
  <form @submit.prevent="submitForm">
    <input v-model="vehicle" placeholder="車輛名稱" required />
    <input v-model="task" placeholder="維護項目" required />
    <input v-model="date" type="date" required />
    <button type="submit">新增紀錄</button>
  </form>
</template>

<script>
export default {
  data() {
    return {
      vehicle: '',
      task: '',
      date: ''
    }
  },
  methods: {
    submitForm() {
      this.$emit('addRecord', {
        vehicle: this.vehicle,
        task: this.task,
        date: this.date
      })
      this.vehicle = ''
      this.task = ''
      this.date = ''
    }
  }
}
</script>
