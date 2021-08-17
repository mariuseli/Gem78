using AutoMapper;
using GemApi.Application.Common.Inteerfaces;
using GemApi.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GemApi.Application.GemEvents.Commands
{
    public class CreateEventCommand : IRequest<int>
    {
        public GemEventDto NewEvent {get;set;}
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.GemEvent.AddAsync(request.NewEvent.ToDb());
                await _context.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(result.Entity.Id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
