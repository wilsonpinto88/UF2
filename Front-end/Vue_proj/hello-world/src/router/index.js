import { createRouter, createWebHashHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AboutView from '../views/AboutView.vue'
import GalleryView from '../views/GalleryView.vue'
import LoginView from '../views/LoginView.vue'


const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: AboutView
  },
  {
    path: '/gallery',
    name: 'gallery',
    // route level code-splitting
    // this generates a separate chunk (gallery.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: GalleryView
  },
  {
    path: '/login',
    name: 'login',
    // route level code-splitting
    // this generates a separate chunk (login.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: LoginView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router


// {
//   path: '/login',
//   name: 'login',
//   // route level code-splitting
//   // this generates a separate chunk (login.[hash].js) for this route
//   // which is lazy-loaded when the route is visited.
//   component: () => import(/* webpackChunkName: "login" */ '../views/LoginView.vue')
// }
