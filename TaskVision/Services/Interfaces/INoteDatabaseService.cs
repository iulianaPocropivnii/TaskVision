using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Models.Notion;

namespace TaskVision.Services.Interfaces
{
    public interface INoteDatabaseService
    {
        Task<List<NoteGroup>> GetAllGroupsAsync();
        Task<List<SimpleNote>> GetNotesByGroupAsync(int groupId);

        Task AddGroupAsync(NoteGroup group);
        Task DeleteGroupAsync(NoteGroup group);

        Task AddNoteAsync(SimpleNote note);
        Task UpdateNoteAsync(SimpleNote note);
        Task DeleteNoteAsync(SimpleNote note);
    }

}
