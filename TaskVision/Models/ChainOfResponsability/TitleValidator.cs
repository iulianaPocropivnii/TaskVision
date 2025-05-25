using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.ChainOfResponsability
{
    public class TitleValidator : TaskHandler
    {
        public override bool Handle(ITask task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                Console.WriteLine("Titlul taskului nu este valid.");
                return false;
            }

            return base.Handle(task);
        }
    }
}
