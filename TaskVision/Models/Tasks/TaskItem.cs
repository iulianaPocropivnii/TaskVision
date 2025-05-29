using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVision.Models.Tasks
{
    public class TaskItem
    {
        public string Title { get; set; } = string.Empty;

        // Data la care are loc taskul
        public DateTime Date { get; set; }

        // Intervalul de timp
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        // Culoare pentru afisare (opțional, folosită în CSS)
        public string Color { get; set; } = "#6c63ff";
    }


}
