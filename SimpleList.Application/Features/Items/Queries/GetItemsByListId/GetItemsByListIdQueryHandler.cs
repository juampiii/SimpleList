using AutoMapper;
using MediatR;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Domain;

namespace SimpleList.Application.Features.Items.Queries.GetItemsByListId
{
    public class GetItemsByListIdQueryHandler : IRequestHandler<GetItemsByListIdQuery, List<ItemViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetItemsByListIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ItemViewModel>> Handle(GetItemsByListIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Item>? items = await _unitOfWork.GetRepository<Item>()
                .GetAsync(i => i.ListId == request.ListId);

            if (!items.Any())
            {
                return new List<ItemViewModel>();
            }

            return _mapper.Map<List<ItemViewModel>>(items);
        }
    }
}
