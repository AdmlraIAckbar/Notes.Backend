using MediatR;
using NotesApplication.Interfaces;
using NotesDomain;

namespace NotesApplication.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateNoteCommandHandler(INotesDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note()
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,

                Id = Guid.NewGuid(),

                CreatedDate = DateTime.Now,
                EditDate = null
            };
            await _dbcontext.Notes.AddAsync(note, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
