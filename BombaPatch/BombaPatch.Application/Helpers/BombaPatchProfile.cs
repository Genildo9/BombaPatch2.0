using AutoMapper;
using bombapatch.Domain;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;


//Aqui vai receber todos os mapeamentos
namespace BombaPatch.Application.Helpers
{
    public class BombaPatchProfile : Profile
    {
        public BombaPatchProfile()
        {
            CreateMap<Selecao, SelecaoDto>().ReverseMap();
            CreateMap<Jogadores, JogadoresDto>().ReverseMap();
            CreateMap<GrupoSelecoes, GrupoSelecoesDto>().ReverseMap();
        }
    }
}