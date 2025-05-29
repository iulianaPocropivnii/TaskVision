using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Notion
{
    using SQLite;

    public class SimpleNote : INote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public int NoteGroupId { get; set; } // legătura cu folderul
    }

}
