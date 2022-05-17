using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Application.Extensions;
using SimpleList.Application.Features.Lists.Queries.GetListsByUserId;
using SimpleList.Application.Utils.Validations;
using SimpleList.Domain;

namespace SimpleList.Application.Features.Lists.Commands.EditList
{
    public class UpdateListCommandHandler : IRequestHandler<UpdateListCommand, ListViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateListCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateListCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<UpdateListCommandHandler> logger,
            IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ListViewModel> Handle(UpdateListCommand request, CancellationToken cancellationToken)
        {
            List? listToEdit = await _unitOfWork.GetRepository<List>()
                .GetByIdAsync(request.Id.GetValueOrDefault());

            Guard.Against.IsNull(listToEdit);

            _mapper.Map(request, listToEdit, typeof(UpdateListCommand), typeof(List));

            _unitOfWork.GetRepository<List>().UpdateEntity(listToEdit);
            await _unitOfWork.CompleteAsync();

            _logger.LogUpdateInformation(nameof(List), listToEdit.Id);

            return _mapper.Map<ListViewModel>(listToEdit);
        }
    }
}
