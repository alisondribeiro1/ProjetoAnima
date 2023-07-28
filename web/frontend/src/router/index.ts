// Composables
import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "Login",
    component: () => import("@/views/Login.vue"),
  },
  {
    path: "/Home",
    name: "Home",
    component: () => import("@/views/HomeView.vue"),
  },
  {
    path: "/inscricao",
    name: "Inscricao",
    component: () => import("@/views/InscricaoView.vue"),
  },
  {
    path: "/certificados",
    name: "Certificados",
    component: () => import("@/views/CertificadosView.vue"),
  },
  {
    path: "/boletos",
    name: "Boletos",
    component: () => import("@/views/BoletosView.vue"),
  },
  {
    path: "/notas",
    name: "Notas",
    component: () => import("@/views/NotasView.vue"),
  },
  {
    path: "/cursos",
    name: "Cursos",
    component: () => import("@/views/CursosView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
