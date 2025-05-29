using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskVision.Models.Notion;
using TaskVision.Services.Interfaces;

namespace TaskVision.Services.Implementation
{
    public class NoteDatabaseService : INoteDatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public NoteDatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<NoteGroup>().Wait();
            _db.CreateTableAsync<SimpleNote>().Wait();
        }

        public Task<List<NoteGroup>> GetAllGroupsAsync() => _db.Table<NoteGroup>().ToListAsync();

        public Task<List<SimpleNote>> GetNotesByGroupAsync(int groupId) =>
            _db.Table<SimpleNote>().Where(n => n.NoteGroupId == groupId).ToListAsync();

        public Task AddGroupAsync(NoteGroup group) => _db.InsertAsync(group);
        public Task DeleteGroupAsync(NoteGroup group) => _db.DeleteAsync(group);

        public Task AddNoteAsync(SimpleNote note) => _db.InsertAsync(note);
        public Task UpdateNoteAsync(SimpleNote note) => _db.UpdateAsync(note);
        public Task DeleteNoteAsync(SimpleNote note) => _db.DeleteAsync(note);
    }
}
