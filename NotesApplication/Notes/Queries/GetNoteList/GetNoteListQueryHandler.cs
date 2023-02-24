using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Interfaces;

namespace NotesApplication.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        public readonly INotesDbContext _dbContext;
        public readonly IMapper _mapper;
        public GetNoteListQueryHandler(INotesDbContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }
        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new NoteListVm { Notes = notesQuery };
        }
    }
}
