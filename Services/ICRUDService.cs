using System.Collections.Generic;
using jav.Dtos;
using jav.Entities;

namespace jav.Services
{
  public interface ICRUDInterface
  {
    IEnumerable<IEntity> GetAll();
    IEntity GetById(int id);
    IEntity Create(IDto entity);
    IEntity Update(IDto entity);
    IEntity Destroy(int id);
  }
}
