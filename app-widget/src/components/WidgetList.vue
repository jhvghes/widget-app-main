<template>
  <div>
    <!-- Table -->
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>Name</th>
          <th>Price</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="widget in widgets" :key="widget.id">
          <td>{{ widget.name }}</td>
          <td>{{ widget.price }}</td>
          <td>
            <button class="btn btn-info btn-sm me-1" @click="$emit('view-widget', widget)">View</button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- Modal -->
    <div v-if="selectedWidget" class="modal fade show d-block" tabindex="-1" style="background-color: rgba(0,0,0,0.5);">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Widget Details</h5>
            <button type="button" class="btn-close" @click="$emit('close-widget')"></button>
          </div>

          <div class="modal-body">
            <!-- Edit Form -->
            <div v-if="editing">
              <div class="mb-3">
                <label>Name</label>
                <input type="text" class="form-control" v-model="editData.name" />
              </div>
              <div class="mb-3">
                <label>Price</label>
                <input type="number" class="form-control" v-model="editData.price" />
              </div>
              <div class="mb-3">
                <label>Category</label>
                <select class="form-select" v-model="editData.category">
                  <option>Fantasy</option>
                  <option>Sci-Fi</option>
                  <option>Romance</option>
                  <option>Crime</option>
                  <option>YA</option>
                </select>
              </div>
              <div class="mb-3">
                <label>Date Added</label>
                <input type="date" class="form-control" v-model="editData.dateAdded" />
              </div>
            </div>

            <!-- Read-Only View -->
            <div v-else>
              <p><strong>Name:</strong> {{ selectedWidget.name }}</p>
              <p><strong>Price:</strong> {{ selectedWidget.price }}</p>
              <p><strong>Category:</strong> {{ selectedWidget.category }}</p>
              <p><strong>Date Added:</strong> {{ selectedWidget.dateAdded }}</p>
            </div>
          </div>

          <div class="modal-footer">
            <template v-if="editing">
              <button class="btn btn-success" @click="saveEdit">Save</button>
              <button class="btn btn-secondary" @click="cancelEdit">Cancel</button>
            </template>
            <template v-else>
              <button class="btn btn-warning" @click="startEdit">Edit</button>
              <button class="btn btn-danger" @click="$emit('delete-widget', selectedWidget.id)">Delete</button>
              <button class="btn btn-secondary" @click="$emit('close-widget')">Close</button>
            </template>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ['widgets', 'selectedWidget'],
  data() {
    return {
      editing: false,
      editData: {
        id: 0,
        name: '',
        price: '',
        category: '',
        dateAdded: ''
      }
    }
  },
  watch: {
    selectedWidget(newWidget) {
      if (newWidget) {
        this.editing = false
        this.editData = { ...newWidget }
      }
    }
  },
  methods: {
    startEdit() {
      this.editing = true
    },
    cancelEdit() {
      this.editing = false
      this.editData = { ...this.selectedWidget }
    },
    saveEdit() {
      this.$emit('edit-widget', { ...this.editData })
      this.editing = false
    }
  }
}
</script>
