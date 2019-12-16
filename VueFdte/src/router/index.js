import Vue from 'vue'
import Router from 'vue-router'
import Marujo from "../components/Marujo/Marujo";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Marujo',
      component: Marujo
    }
  ]
})
