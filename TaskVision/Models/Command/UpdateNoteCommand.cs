using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Models.Notion;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Command
{
    public class UpdateNoteCommand : ICommand
    {
        private readonly INoteDatabaseService _noteService;
        private readonly SimpleNote _note;

        public UpdateNoteCommand(INoteDatabaseService noteService, SimpleNote note)
        {
            _noteService = noteService;
            _note = note;
        }

        public async Task ExecuteAsync()
        {
            await _noteService.UpdateNoteAsync(_note);
        }
    }


}
