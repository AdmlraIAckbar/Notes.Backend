using MediatR;
using NotesApplication.Common.Exeptions;
using NotesApplication.Interfaces;

namespace NotesApplication.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler: IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;
        public DeleteNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExeption(nameof(Notes),request.Id);
            }

            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
