using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jav.Dtos;
using jav.Entities;
using jav.Services.CRUDServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace jav.Controllers
{
  [Route("api/[controller]")]
  public class LessonsController : Controller
  {
    private ICRUDService<Lesson> _lessonService;
    public LessonsController(ICRUDService<Lesson> lessonService)
    {
      _lessonService = lessonService;
    }

    [HttpGet]
    public IEnumerable<Lesson> Index()
    {
      return _lessonService.GetAll();
    }

    [HttpGet("{id}", Name="Show")]
    public IActionResult Show(int id)
    {
      try {
        var lesson = _lessonService.GetById(id);
        return new ObjectResult(lesson);
      } catch (Exception) {
        return NotFound();
      }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Lesson lesson)
    {
      if (lesson == null) { return BadRequest(); }
      try {
        var newLesson = _lessonService.Create(lesson);
        return CreatedAtRoute("Show", new { id = newLesson.Id }, newLesson);
      } catch (Exception e) {
        return BadRequest(e.Message);
      }
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] JsonPatchDocument<Lesson> lessonParams)
    {
      if (lessonParams == null) { return BadRequest(); }
      try {
        var updatedLesson = _lessonService.Update(id, lessonParams);
        return new ObjectResult(updatedLesson);
      } catch (Exception e) {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Destroy(int id)
    {
      try {
        var deletedLesson = _lessonService.Destroy(id);
        return Ok(deletedLesson);
      } catch (Exception) {
        return NotFound();
      }
    }
  }
}
