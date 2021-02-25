using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taskApi.Database;
using taskApi.Models;

namespace taskApi.Repositories
{
    public class TaskRepository: ITaskRepository, IDisposable
    {
        private tasksDBContext dbContext;

        public TaskRepository(tasksDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<User>> getUsers()
        {
            var result = dbContext.Users.Where(x => x.IsActive == 1).ToList();
            return result;
        }


        public async Task<List<Status>> getStatuses()
        {
            var result = dbContext.Statuses.ToList();
            return result;
        }

        public async Task<bool> createTask(TaskModel request)
        {
            Database.Task task = new Database.Task();
            task.Name = request.taskName;
            task.WorkingHours = request.workingHours;
            task.UserId = request.userId;
            task.StatusId = dbContext.Statuses.Where(x => x.Status1 == request.currentStatus).FirstOrDefault().Id;
            dbContext.Update(task);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Database.Task>> getActiveTasks()
        {
            var result = dbContext.Tasks.Where(x => x.IsActive != 0).ToList();
            return result;
        }

        public async Task<Database.Task> getTaskById(string id)
        {
            int newId = Int32.Parse(id);
            var result = dbContext.Tasks.Where(x => x.Id == newId).FirstOrDefault();
            return result;
        }

        public async Task<Status> StatusById(string id)
        {
            int newId = Int32.Parse(id);
            var result = dbContext.Statuses.Where(x => x.Id == newId).FirstOrDefault();
            return result;
        }

        public async Task<Status> getNextStatus(string currStatus)
        {
            var currStatusId = dbContext.Statuses.Where(x => x.Status1.Equals(currStatus)).FirstOrDefault().Id;
            if (currStatus != null)
            {
                var nextStatusId = dbContext.StatusFlows.Where(x => x.FromStatusId == currStatusId).FirstOrDefault().ToStatusId;
                var result = dbContext.Statuses.Where(x => x.Id == nextStatusId).FirstOrDefault();
                return result;
            }
            
            return null;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }

        
    }
}
