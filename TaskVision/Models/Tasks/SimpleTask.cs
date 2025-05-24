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
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
