using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVision.Models.ChainOfResponsability
{
    public class ValidationResult
    {
        public bool IsValid { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
