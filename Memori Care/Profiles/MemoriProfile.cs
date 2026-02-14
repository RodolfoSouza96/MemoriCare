using AutoMapper;
using Memori_Care.DTOs;
using Memori_Care.Models;

namespace Memori_Care.Profiles;

public class MemoriProfile : Profile
{

    public MemoriProfile()
    {
        CreateMap<Paciente, PacienteCreateDto>().ReverseMap();
        CreateMap<Paciente, PacienteReadDTO>().ReverseMap();
    }


}
