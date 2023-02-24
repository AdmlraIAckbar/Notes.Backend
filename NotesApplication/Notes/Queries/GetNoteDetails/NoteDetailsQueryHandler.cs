using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Common.Exeptions;
using NotesApplication.Interfaces;
using NotesDomain;
namespace NotesApplication.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public NoteDetailsQueryHandler(INotesDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExeption(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
