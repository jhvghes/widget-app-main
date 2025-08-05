import { createRouter, createWebHistory } from 'vue-router'
import WidgetsView from './views/WidgetsView.vue'

const routes = [
  {
    path: '/',
    name: 'Widgets',
    component: WidgetsView
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
