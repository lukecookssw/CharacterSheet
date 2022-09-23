using AutoMapper;
using AutoMapper.QueryableExtensions;
using CharacterSheet.Application.Common.Exceptions;
using CharacterSheet.Application.Common.Interfaces;
using CharacterSheet.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CharacterSheet.Application.Characters.Queries.GetCharacter;

public class GetCharacter : IRequest<CharacterDto>
{
    public int Id { get; set; }
    public GetCharacter(int id)
    {
        this.Id = id;
    }
}

public class GetPlayerCharacterHandler : IRequestHandler<GetCharacter, CharacterDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlayerCharacterHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context    = context;
        _mapper     = mapper;
    }

    public async Task<CharacterDto> Handle(GetCharacter request, CancellationToken cancellationToken)
    {
        var v = _context.Characters.ToList();
        var character = await _context.Characters
            .Where(x => x.Id == request.Id)
            .ProjectTo<CharacterDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (character == null)
        {
            throw new NotFoundException($"Character with id { request.Id } not found");
        }
        return character;
    }
}
