using AutoMapper;
using SimpleList.Application.Features.Lists.Commands.CreateList;
using SimpleList.Application.Features.Lists.Commands.EditList;
using SimpleList.Application.Features.Lists.Queries.GetListsByUserId;

namespace SimpleList.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.List, ListViewModel>();
            CreateMap<CreateListCommand, Domain.List>();
            CreateMap<UpdateListCommand, ListViewModel>();
            CreateMap<UpdateListCommand, Domain.List>();
        }
    }
}
