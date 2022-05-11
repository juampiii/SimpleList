using AutoMapper;
using MediatR;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Application.Features.Lists.Queries.GetAllLists;

namespace SimpleList.Application.Features.Lists.Queries.GetListsByUserId
{
    public class GetListsByUserIdQueryHandler : IRequestHandler<GetListsByUserIdQuery, List<ListViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetListsByUserIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ListViewModel>> Handle(GetListsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var lists = await _unitOfWork.ListRepository.GetListsByUserIdAsync(request.UserId);

            return _mapper.Map<List<ListViewModel>>(lists);
        }
    }
}
