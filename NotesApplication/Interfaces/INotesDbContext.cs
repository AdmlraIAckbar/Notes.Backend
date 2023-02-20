using Microsoft.EntityFrameworkCore;
using NotesDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
