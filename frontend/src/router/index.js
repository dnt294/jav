import Vue from 'vue'
import Router from 'vue-router'
import Lessons from '@/components/lessons/Lessons'

Vue.use(Router)

export default new Router({
  routes: [
    { path: '/', component: Lessons }
  ]
})
