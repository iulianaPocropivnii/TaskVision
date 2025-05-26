using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskVision.Enum;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Tasks
{
    internal class DeadlineTask: ITask
    {
        private readonly IDatabaseService _databaseService;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskPriority Priority { get; set; }
        public void UpdateTask()
        {
            _databaseService.UpdateDbTask(this);

        }
        public DeadlineTask(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public ITask Clone()
        {
            return new DeadlineTask(_databaseService)
            {
                Title = this.Title,
                Description = this.Description,
                Deadline = this.Deadline,
                Priority = this.Priority
            };
        }
    }
        
}
