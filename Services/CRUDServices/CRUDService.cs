using System;
using System.Collections.Generic;
using jav.Dtos;
using jav.Entities;
using jav.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace jav.Services.CRUDServices
{
  public interface ICRUDService<T> where T: class, IEntity
  {
    IEnumerable<T> GetAll();
    T GetById(int id);
    T Create(T entity);
    T Update(int id, JsonPatchDocument<T> entity);
    T Destroy(int id);
  }
  public abstract class CRUDService<T> : ICRUDService<T> where T: class, IEntity
  {
    private DataContext _context;
    public CRUDService(DataContext context) {
      _context = context;
    }
    public IEnumerable<T> GetAll() {
      return GetSet();
    }
    public T GetById(int id) {
      return GetSet().Find(id);
    }
    public T Create(T entity) {
      GetSet().Add(entity);
      _context.SaveChanges();
      return entity;
    }
    public T Update(int id, JsonPatchDocument<T> patchEntity) {
      var oldRecord = GetById(id);
      if (null == oldRecord) { throw new Exception("Record not found."); }
      patchEntity.ApplyTo(oldRecord);
      GetSet().Update(oldRecord);
      _context.SaveChanges();
      return oldRecord;
    }
    public T Destroy(int id) {
      var entity = GetById(id);
      if (null != entity)
      {
        GetSet().Remove(entity);
        _context.SaveChanges();
        return entity;
      } else { throw new Exception("Record not found."); }
    }
    DbSet<T> GetSet() {
      return _context.Set<T>();
    }
  }
}
