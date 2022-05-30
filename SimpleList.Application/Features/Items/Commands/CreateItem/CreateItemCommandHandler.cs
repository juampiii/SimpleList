using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Application.Extensions;
using SimpleList.Application.Features.Items.Queries.GetItemsByListId;
using SimpleList.Application.Utils.Validations;
using SimpleList.Domain;

namespace SimpleList.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ItemViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateItemCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<CreateItemCommandHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ItemViewModel> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.GetRepository<List>().GetByIdAsync(request.ListId.Value);
            Guard.Against.IsNull(list);

            Item newItem = _mapper.Map<Item>(request);
            _unitOfWork.GetRepository<Item>().AddEntity(newItem);

            await _unitOfWork.CompleteAsync();
            _logger.LogBaseDomainModelCreation<Item>(newItem.Id);

            return _mapper.Map<ItemViewModel>(newItem);
        }
    }
}
