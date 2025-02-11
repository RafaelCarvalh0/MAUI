using AppTask.Database;
using AppTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Repositories
{
    public interface ITaskModelRepository
    {
        Task<IList<TaskModel>> GetAll();
        Task<TaskModel> GetById(int id);
        Task Add(TaskModel task);
        Task Update(TaskModel task);
        Task Delete(TaskModel task);
        Task DeleteAll(List<TaskModel> tasks);
    }

    public class TaskModelRepository : ITaskModelRepository
    {
        private AppTaskContext _db;
        public TaskModelRepository(AppTaskContext db)
        {
            _db = db;
        }

        public async Task<IList<TaskModel>> GetAll()
        {
            try
            {
                var query = await _db.Tasks.OrderByDescending(a => a.PrevisionDate).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TaskModel> GetById(int id)
        {
            try
            {
                var query = await _db.Tasks.Include(a => a.SubTasks).SingleOrDefaultAsync(a => a.Id == id);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Add(TaskModel task)
        {
            try
            {
                await _db.AddAsync(task);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(TaskModel task)
        {
            try
            {
                _db.Tasks.Update(task);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(TaskModel task)
        {
            try
            {
                #region Se não utilizar OnModelCreating(), deve excluir os filhos primeiro
                //task = await GetById(task.Id);
                //foreach(var subtask in task.SubTasks)
                //{
                //    _db.SubTasks.Remove(subtask);
                //}
                #endregion

                //Invés de remover pelo ID posso remover pelo objeto todo, pois o EF Core já faz a verificação do ID
                _db.Tasks.Remove(task);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAll(List<TaskModel> tasks)
        {
            try
            {
                _db.Tasks.RemoveRange(tasks);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
