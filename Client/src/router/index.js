import { createRouter, createWebHistory } from 'vue-router'
import EntityManagement from '../views/EntityManagement.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/entity-management' 
    },
    {
      path: '/entity-management',
      name: 'entity',
      component: EntityManagement
    },
    {
      path: '/web-service-ops',
      name: 'webservice',
      component: EntityManagement 
    }
  ]
})

export default router