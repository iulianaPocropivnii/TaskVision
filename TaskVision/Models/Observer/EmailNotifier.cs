using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Observer
{
    public class EmailNotifier : IObserver
    {
        private readonly string _recipientEmail;

        public EmailNotifier(string recipientEmail)
        {
            _recipientEmail = recipientEmail;
        }

        public void Update(string message)
        {
            Console.WriteLine($"[EMAIL to {_recipientEmail}]: {message}");
        }
    }
}
