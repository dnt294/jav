using System;
using System.Collections.Generic;
using jav.Dtos;
using jav.Entities;
using jav.Helpers;

namespace jav.Services.CRUDServices
{
  public class LessonService : CRUDService<Lesson>
  {
    public LessonService(DataContext context) : base(context) { }
  }
}
