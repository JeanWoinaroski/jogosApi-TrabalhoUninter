using AutoMapper;
using ProjetoFaculdade.DTOs;
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Empresa, EmpresaReadDto>();
            CreateMap<EmpresaCreateDto, Empresa>();
            CreateMap<EmpresaUpdateDto, Empresa>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Funcionario, FuncionarioReadDto>()
                .ForMember(dest => dest.EmpresaNome, opt => opt.MapFrom(src => src.Empresa != null ? src.Empresa.Nome : null));
            CreateMap<FuncionarioCreateDto, Funcionario>();
            CreateMap<FuncionarioUpdateDto, Funcionario>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // nested maps
            CreateMap<Funcionario, FuncionarioReadDto>();
        }
    }
}
