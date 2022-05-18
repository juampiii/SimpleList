using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Application.Extensions;
using SimpleList.Domain;

namespace SimpleList.Application.Features.Lists.Commands.CreateList
{
    public class CreateListCommandHandler : IRequestHandler<CreateListCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateListCommandHandler> _logger;

        public CreateListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CreateListCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreateListCommand request, CancellationToken cancellationToken)
        {
            List newList = _mapper.Map<List>(request);
            _unitOfWork.GetRepository<List>().AddEntity(newList);

            await _unitOfWork.CompleteAsync();

            _logger.LogBaseDomainModelCreation<List>(newList.Id);

            return newList.Id;
        }
    }
}
