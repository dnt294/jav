<script>
import axios from 'axios'

export default {
  name: 'CreateForm',
  data: function () {
    return {
      input: {
        index: '',
        bookName: ''
      }
    }
  },
  methods: {
    submit () {
      axios.post('Lessons', { index: this.input.index, bookName: this.input.bookName })
        .then(response => { this.$emit('lessonCreated', response.data) }, error => { alert(error.message) })
    },
    cancel () {
      this.$emit('cancelForm')
    }
  }
}
</script>

<template src='./CreateForm.html'>
