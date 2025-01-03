using AutoMapper;
using Fidelicard.Usuario.Core.Models;
using Fidelicard.Usuario.Infra.EntityMapping.DTO;

namespace Fidelicard.Usuario.Infra.EntityMapping.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UsuarioDTO, Usuarios>().ReverseMap();
        }
    }
}
