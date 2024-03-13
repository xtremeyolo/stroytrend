import { createRouter, createWebHistory } from "vue-router"
import Home from "./components/Home.vue"
import Project from "./components/Project.vue"

const routes = [
  { path: '/', component: Home, name: 'Home' },
  { path: '/project/:id', component: Project, name: 'Project' },
]

export const router = createRouter({
  history: createWebHistory(),
  routes,
})