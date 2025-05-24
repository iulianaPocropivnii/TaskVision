using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;
using TaskVision.Models.Tasks;

    namespace TaskVision.Services.Implementation
    {
        public class DatabaseService : IDatabaseService
        {
            private static readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "taskmanager.db3");

            private static DatabaseService _instance;
            private static readonly object _lock = new object();

            private readonly SQLiteConnection _database;

            private DatabaseService()
            {
                _database = new SQLiteConnection(DatabasePath);
                _database.Execute("PRAGMA foreign_keys = ON;");
                _database.CreateTable<SimpleTask>();
                _database.CreateTable<RecurringTask>();
                _database.CreateTable<DeadlineTask>();
            }

            public static IDatabaseService Instance
            {
                get
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new DatabaseService();

                        return _instance;
                    }
                }
            }

            public void AddDbTask(ITask task) => _database.Insert(task);
            public void RemoveDbTask(ITask task) => _database.Delete(task);
            public void UpdateDbTask(ITask updatedTask) => _database.Update(updatedTask);
        }
    }

