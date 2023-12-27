import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import AdminVue from '../views/Admin.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/admin',
      name: 'admin',
      component: () => import('../views/Admin.vue'),
      children: [
      {
        path: '/bacsi', 
        name: 'bacsi',
        component: () => import('../components/admin/bacsi.vue')
      },
      {
        path: '/chuyenkhoa', 
        name: 'chuyenkhoa',
        component: () => import('../components/admin/chuyenkhoa.vue')
      },
      {
        path: '/benhnhan', 
        name: 'benhnhan',
        component: () => import('../components/admin/benhnhan.vue')
      },
      {
        path: '/thuoc', 
        name: 'thuoc',
        component: () => import('../components/admin/thuoc.vue')
      },
      {
        path: '/dichvu', 
        name: 'dichvu',
        component: () => import('../components/admin/dichvu.vue')
      },
      {
        path: '/hoadon', 
        name: 'hoadon',
        component: () => import('../components/admin/hoadon.vue')
      },
      // Các route con khác nếu cần
    ]
    },
  ]
})

export default router
