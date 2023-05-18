using AutoMapper;
using ContactAPI.DTO;
using ContactAPI.Model;
using ContactAPI.Models;

namespace ContactAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        // SignupDTO = ApplicationUser
        public AutoMapperConfig()
        {
            CreateMap<ApplicationUser, SignUpDTO>().ReverseMap()
            .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
