using AutoMapper;
using MediatR;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Application.Features.Lists.Queries.GetAllLists;

namespace SimpleList.Application.Features.Lists.Queries.GetListsByUserId
{
    public class GetListsByUserIdQueryHandler : IRequestHandler<GetListsByUserIdQuery, List<ListViewModel>>
    {
        private readonly IListRepositoryAsync _repositoryAsync;
        private readonly IMapper _mapper;

        public GetListsByUserIdQueryHandler(
            IListRepositoryAsync repositoryAsync, 
            IMapper mapper) 
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<List<ListViewModel>> Handle(GetListsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var lists = await _repositoryAsync.GetListsByUserIdAsync(request.UserId);

            return _mapper.Map<List<ListViewModel>>(lists);
        }
    }
}
