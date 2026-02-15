using AutoMapper;
using Memori_Care.DTOs;
using Memori_Care.Models;

namespace Memori_Care.Profiles;

public class MemoriProfile : Profile
{

    public MemoriProfile()
    {
        CreateMap<Paciente, PacienteCreateDTO>().ReverseMap();
        CreateMap<Paciente, PacienteReadDTO>().ReverseMap();
        CreateMap<Paciente, PacienteUpdateDTO>().ReverseMap();
        CreateMap<Profissional, ProfissionalCreateDto>().ReverseMap();
        CreateMap<Profissional, ProfissionalReadDto>().ReverseMap();
        CreateMap<Profissional, ProfissionalUpdateDTO>().ReverseMap();
    }


}
