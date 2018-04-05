<script>
import axios from 'axios'
import CreateForm from './create-form/CreateForm'
import UpdateForm from './update-form/UpdateForm'

export default {
  name: 'Lessons',
  data: function () {
    return {
      isShowCreateForm: false,
      lessons: [],
      editingLesson: null
    }
  },
  created () {
    axios.get('Lessons').then(response => { this.lessons = response.data })
  },
  components: {
    CreateForm, UpdateForm
  },
  methods: {
    showCreateForm () {
      this.isShowCreateForm = true
    },
    cancelForm () {
      this.isShowCreateForm = false
      this.editingLesson = null
    },
    lessonCreated (lesson) {
      this.lessons.push(lesson)
      this.isShowCreateForm = false
    },
    updateLesson (lesson) {
      this.editingLesson = lesson
    },
    lessonUpdated (newLesson, oldLesson) {
      this.editingLesson = null
      Object.assign(oldLesson, newLesson)
    },
    deleteLesson (lesson) {
      const result = confirm('Delete this ?')
      if (result) {
        axios.delete(`Lessons/${lesson.id}`).then(response => {
          this.lessons.splice(this.lessons.indexOf(lesson), 1)
        })
      }
    }
  }
}
</script>

<template src='./Lessons.html'>
