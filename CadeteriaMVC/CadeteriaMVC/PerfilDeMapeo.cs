using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaMVC.Entidades;
using CadeteriaMVC.ViewModel;

namespace CadeteriaMVC
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();
        }
    }
}
