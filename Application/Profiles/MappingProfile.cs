using Application.Features.Persons.Commands.Create;
using Application.Features.Persons.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonListVM>().ReverseMap();
            CreateMap<Person, CreatePersonCommand>().ReverseMap();
        }
    }
}
