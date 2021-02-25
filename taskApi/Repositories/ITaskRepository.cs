using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using taskApi.Database;
using taskApi.Models;

namespace taskApi.Repositories
{
    public interface ITaskRepository
    {
        Task<List<Status>> getStatuses();
        Task<List<User>> getUsers();
        Task<bool> createTask(TaskModel request);
        Task<Database.Task> getTaskById(string id);
        Task<List<Database.Task>> getActiveTasks();
        Task<Status> StatusById(string id);
        Task<Status> getNextStatus(string currStatus);
    }
}
