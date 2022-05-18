using MediatR;
using Microsoft.Extensions.Logging;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Application.Extensions;
using SimpleList.Application.Utils.Validations;
using SimpleList.Domain;

namespace SimpleList.Application.Features.Lists.Commands.DeleteList
{
    public class DeleteListCommandHandler : IRequestHandler<DeleteListCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteListCommandHandler> _logger;

        public DeleteListCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<DeleteListCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<int> Handle(DeleteListCommand request, CancellationToken cancellationToken)
        {
            List? listToDelete = await _unitOfWork.GetRepository<List>()
                .GetByIdAsync(request.Id.Value);

            Guard.Against.IsNull(listToDelete);

            _unitOfWork.GetRepository<List>().DeleteEntity(listToDelete);

            await _unitOfWork.CompleteAsync();

            _logger.LogBaseDomainModelDelete<List>(listToDelete.Id);

            return listToDelete.Id;
        }
    }
}
