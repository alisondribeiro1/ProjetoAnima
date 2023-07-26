import { createRouter, createWebHistory } from 'vue-router'
import Home from './Pages/Home.vue'
import Profile from './Pages/Profile.vue'
import Certificate from './Pages/Certificate.vue'
import Empresas from "./Pages/Empresas.vue"
import Individual from "./Pages/Individual.vue"
import Login from "./Pages/Login.vue"
import Create from "./Pages/Create.vue"

const routerHistory = createWebHistory()

const router = createRouter({
  history: routerHistory,
  routes: [
    {
      path: '/',
      component: Home
    },
    {
      path: '/Profile',
      component: Profile
    },
    {
      path: '/Certificate',
      component: Certificate
    },
    {
      path: '/Empresas',
      component: Empresas
    },
    {
      path: '/ParaVoce',
      component: Individual
    },
    {
      path: '/Login',
      component : Login
    },
    {
      path: '/Create',
      component : Create
    }

  ]
})

export default router