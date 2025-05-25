using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Tasks
{
    public class SimpleTask : ITask
    {
        private readonly IDatabaseService _databaseService;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void UpdateTask()
        {
            _databaseService.UpdateDbTask(this);

        }
        public SimpleTask(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
    }
}
