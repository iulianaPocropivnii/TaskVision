using SQLite;
using TaskVision.Models.Tasks;
using TaskVision.Services.Interfaces;
using System.Linq;

namespace TaskVision.Services.Implementation
{
    public class DatabaseService : IDatabaseService
    {
        private readonly SQLiteConnection _database;

        public DatabaseService()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "taskmanager.db3");
            _database = new SQLiteConnection(path);

            // 1) Creăm tabele pentru toate tipurile de task
            _database.CreateTable<SimpleTask>();
            _database.CreateTable<DeadlineTask>();
            _database.CreateTable<RecurringTask>();
        }

        public List<ITask> GetAllTasks()
        {
            // 2) Citim fiecare tabel şi combinăm rezultatele
            var simple = _database.Table<SimpleTask>()
                                     .ToList()
                                     .Cast<ITask>();
            var deadlines = _database.Table<DeadlineTask>()
                                     .ToList()
                                     .Cast<ITask>();
            var recur = _database.Table<RecurringTask>()
                                     .ToList()
                                     .Cast<ITask>();

            // Opțional: poți ordona după Start/Deadline
            return simple
                  .Concat(deadlines)
                  .Concat(recur)
                  .OrderBy(t => t.Start)
                  .ToList();
        }

        public void AddTask(ITask task)
        {
            // 3) Insert în funcție de tip
            switch (task)
            {
                case SimpleTask st:
                    _database.Insert(st);
                    break;
                case DeadlineTask dt:
                    _database.Insert(dt);
                    break;
                case RecurringTask rt:
                    _database.Insert(rt);
                    break;
            }
        }

        public void UpdateTask(ITask task)
        {
            // 4) Update în funcție de tip
            switch (task)
            {
                case SimpleTask st:
                    _database.Update(st);
                    break;
                case DeadlineTask dt:
                    _database.Update(dt);
                    break;
                case RecurringTask rt:
                    _database.Update(rt);
                    break;
            }
        }

        public void RemoveTask(ITask task)
        {
            // 5) Delete în funcție de tip
            switch (task)
            {
                case SimpleTask st:
                    _database.Delete(st);
                    break;
                case DeadlineTask dt:
                    _database.Delete(dt);
                    break;
                case RecurringTask rt:
                    _database.Delete(rt);
                    break;
            }
        }
    }
}
