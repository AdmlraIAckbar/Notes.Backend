
namespace NotesPersistance
{
    public class DbInitialize
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
