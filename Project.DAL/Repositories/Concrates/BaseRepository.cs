﻿using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrates
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        protected void Save()
        {
            _db.SaveChanges();
        }
        protected async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }


        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
            await SaveAsync();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public async Task<List<T>> GetActivesAsync()
        {
            return await _db.Set<T>().Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted).ToListAsync();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

       
        public List<T> GetFirstDatas(int count)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetLastDatas(int count)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public async Task UpdateAsync(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            T originalEntity = await FindAsync(item.ID);
            _db.Entry(originalEntity).CurrentValues.SetValues(item);
            await SaveAsync();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetPassivesAsync()
        {
            return await _db.Set<T>().Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted).ToListAsync();
        }

        public async Task<List<T>> GetModifiedsAsync()
        {
            return await _db.Set<T>().Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated).ToListAsync();
        }

        public async Task DeleteAsync(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            await SaveAsync();
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            T originalEntity = _db.Find<T>(item.ID);
            _db.Entry(originalEntity).CurrentValues.SetValues(item);
            Save();
        }

        public async Task DestroyAsync(T item)
        {
            _db.Set<T>().Remove(item);
            await SaveAsync();
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().Where(exp).ToListAsync();
        }
    }
}
