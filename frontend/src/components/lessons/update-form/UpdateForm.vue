<script>
import axios from 'axios'
import jsonpatch from 'fast-json-patch'

export default {
  name: 'UpdateForm',
  data: function () {
    return {
      input: Object.assign({}, this.editingLesson)
    }
  },
  watch: {
    editingLesson: function (val) {
      this.input = Object.assign({}, val)
    }
  },
  props: ['editingLesson'],
  methods: {
    submit () {
      const diff = jsonpatch.compare(this.editingLesson, this.input)
      axios.patch(`Lessons/${this.editingLesson.id}`, diff)
        .then(
          response => { this.$emit('lessonUpdated', response.data, this.editingLesson) },
          error => { alert(error.message) }
        )
    },
    cancel () {
      this.$emit('cancelForm')
    }
  }
}
</script>

<template src='./UpdateForm.html'>
