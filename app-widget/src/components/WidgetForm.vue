<template>
  <form @submit.prevent="submitForm">
    <div class="mb-3">
      <label>Name</label>
      <input type="text" v-model="formData.name" class="form-control" required />
    </div>

    <div class="mb-3">
      <label>Price</label>
      <input type="number" v-model="formData.price" class="form-control" required />
    </div>

    <div class="mb-3">
      <label>Category</label>
      <select v-model="formData.category" class="form-select" required>
        <option disabled value="">Please select</option>
        <option>Fantasy</option>
        <option>Sci-Fi</option>
        <option>Romance</option>
        <option>Crime</option>
        <option>YA</option>
      </select>
    </div>

    <div class="mb-3">
      <label>Date Added</label>
      <input type="date" v-model="formData.dateAdded" class="form-control" required />
    </div>

    <button type="submit" class="btn btn-success">Add Widget</button>
  </form>
</template>

<script>
export default {
  data() {
    return {
      formData: {
        name: '',
        price: '',
        category: '',
        dateAdded: ''
      }
    }
  },
  methods: {
    submitForm() {
      this.$emit('add-widget', this.formData)
      this.formData = { name: '', price: '', category: '', dateAdded: '' }
    }
  }
}
</script>
