using AutoMapper;
using AutoMapper.QueryableExtensions;
using GemApi.Application.Common.Inteerfaces;
using GemApi.Application.Common.Mappings;
using GemApi.Application.Common.Models;
using MediatR;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GemApi.Application.GemEvents.Queries
{
    public class GetAllEventsQuery : IRequest<PaginatedList<GemEventDto>>
    {
        public int ListId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, PaginatedList<GemEventDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllEventsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<GemEventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return await _context.GemEvent
                .AsNoTracking()
                .ProjectTo<GemEventDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(ge=>ge.StartDate)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
