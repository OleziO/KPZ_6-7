using AutoMapper;
using ComputerCompany.DTOs;
using ComputerCompany.Models;
using ComputerCompany.ViewModels;

namespace ComputerCompany
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GoodsDto, Goods>();
            CreateMap<ClientDto, Client>();

            CreateMap<Goods, GoodsViewModel>();
            CreateMap<Client, ClientViewModel>();
        }
    }
}