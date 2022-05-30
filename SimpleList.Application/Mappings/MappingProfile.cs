using AutoMapper;
using SimpleList.Application.Features.Items.Commands.CreateItem;
using SimpleList.Application.Features.Items.Queries.GetItemsByListId;
using SimpleList.Application.Features.Lists.Commands.CreateList;
using SimpleList.Application.Features.Lists.Commands.EditList;
using SimpleList.Application.Features.Lists.Queries.GetListsByUserId;
using SimpleList.Domain;

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
            
            CreateMap<Domain.Item, ItemViewModel>();
            CreateMap<CreateItemCommand, Item>();
        }
    }
}
