using Microsoft.EntityFrameworkCore;
using NotesDomain;

namespace NotesApplication.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
