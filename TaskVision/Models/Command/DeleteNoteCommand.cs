using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Models.Notion;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Command
{
    public class DeleteNoteCommand : ICommand
    {
        private readonly INoteDatabaseService _noteService;
        private readonly SimpleNote _note;

        public DeleteNoteCommand(INoteDatabaseService noteService, SimpleNote note)
        {
            _noteService = noteService;
            _note = note;
        }

        public async Task ExecuteAsync()
        {
            await _noteService.DeleteNoteAsync(_note);
        }
    }

}
