<template>
  <div class="container mt-4">
    <h2>Widget Manager</h2>

    <div class="mb-3">
      <button class="btn btn-primary me-2" @click="showList = true; showAdd = false">List Widgets</button>
      <button class="btn btn-success" @click="showAdd = true; showList = false">Add Widget</button>
    </div>

    <WidgetList
      v-if="showList"
      :widgets="widgets"
      :selectedWidget="selectedWidget"
      @view-widget="selectedWidget = $event"
      @close-widget="selectedWidget = null"
      @delete-widget="deleteWidget"
      @edit-widget="editWidget"
    />

    <WidgetForm
      v-if="showAdd"
      @add-widget="addWidget"
    />
  </div>
</template>

<script>
import WidgetList from '../components/WidgetList.vue'
import WidgetForm from '../components/WidgetForm.vue'

export default {
  components: {
    WidgetList,
    WidgetForm
  },
  data() {
    return {
      widgets: [],
      selectedWidget: null,
      showList: false,
      showAdd: false
    }
  },
  methods: {
    getWidgets() {
      fetch('http://localhost:5014/api/widgets')
        .then(res => res.json())
        .then(data => {
          this.widgets = data
        })
    },
    addWidget(widget) {
      fetch('http://localhost:5014/api/widgets', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(widget)
      }).then(() => {
        this.getWidgets()
        this.showList = true
        this.showAdd = false
      })
    },
    editWidget(widget) {
  fetch('http://localhost:5014/api/widgets/' + widget.id, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(widget)
  }).then(() => {
    this.getWidgets()
    this.selectedWidget = null
  })
},
    deleteWidget(id) {
      fetch('http://localhost:5014/api/widgets/' + id, {
        method: 'DELETE'
      }).then(() => {
        this.getWidgets()
        this.selectedWidget = null
      })
    }
  },
  mounted() {
    this.getWidgets()
  }
}
</script>
