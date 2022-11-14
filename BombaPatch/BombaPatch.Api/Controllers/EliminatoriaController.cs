using System.Linq;
using AutoMapper;
using bombapatch.Domain;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace BombaPatch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EliminatoriaController : ControllerBase
    {
        private readonly ISelecaoService _selecaoService;
        private readonly IMapper _mapper;
        private readonly IEliminatoriaService _eliminatoriaService;
        private readonly ISelecaoJogoResultadoService _selecaojogoresultadoService;
        private readonly IGrupoClassificacaoService _grupoClassificacaoService;
        private readonly IGrupoService _grupoService;
        public EliminatoriaController(IGrupoService grupoService,
         IGrupoClassificacaoService grupoClassificacaoService, ISelecaoJogoResultadoService selecaojogoresultadoService, 
         IEliminatoriaService eliminatoriaService, IMapper mapper, ISelecaoService selecaoService)
        {
            _grupoService = grupoService;
            _grupoClassificacaoService = grupoClassificacaoService;
            _selecaojogoresultadoService = selecaojogoresultadoService;
            _eliminatoriaService = eliminatoriaService;
            _mapper = mapper;
            _selecaoService = selecaoService;
        }
    [HttpPost]
    public async Task<IActionResult> GerarElimitorias(FaseEnum fase)
    {
        try
        {
            var eliminatoria = await _eliminatoriaService.GetEliminatoriaAsync();
            switch (fase)
            {
                case FaseEnum.Oitavas:
                var grupos = await _grupoService.GetAllGrupoAsync();
                var selecoesDto = await _selecaoService.GetAllSelecoesAsync();
                var selecoes = _mapper.Map<List<Selecao>>(selecoesDto);
                var selecaoJogoResultadoDto = await _selecaojogoresultadoService.GetAllSelecaoJogoResultadoAsync();
                var selecaoJogoResultado = _mapper.Map<List<SelecaoJogoResultado>>(selecaoJogoResultadoDto);
                foreach (var item in grupos)
                {
                    var selecoesFiltradas = selecoes.Where(x => x.GrupoId == item.Id).ToList();
                    var grupoclassificacao= item.ClassificarGrupo(selecaoJogoResultado, selecoesFiltradas);                
                }
                GerarOitavas(grupos);

                    break;
                case FaseEnum.Quartas:
                   GerarQuartas(eliminatoria); 
                    break;
                case FaseEnum.Semi:
                GerarSemi(eliminatoria);
                    break;
                case FaseEnum.DisputaTerceiroLugar:
                GerarDisputaTerceiroLugar(eliminatoria);
                    break;
                case FaseEnum.Final:
                GerarDisputaFinal(eliminatoria);
                    break;
                default:
                    break;
            }

            return Ok();
        }
        catch (Exception ex)
        {
             return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar resultados. Erro: {ex.Message}");
        }
        
    }
    private void GerarOitavas(List<Grupo> grupo)
        {
            var eliminatorias = new List<Eliminatoria>();

            //chave a
            var contadorGrupo = 1;
            for (int i = 1; i <= 8; i++)
            {
                if(i <= 4)
                {
                    var eliminatoriaA = new EliminatoriaDto
                    {
                        SelecaoA = grupo.First(x => x.Id == contadorGrupo).SelecaoClassificada1,
                        SelecaoB = grupo.First(x => x.Id == contadorGrupo++).SelecaoClassificada2,
                        NumeroJogo = i,
                        Fase = FaseEnum.Oitavas
                    };
                    _eliminatoriaService.AddEliminatoria(eliminatoriaA);
                    //add eliminatoria
                    
                    contadorGrupo++;
                }
            }

            //chave b
            contadorGrupo = 0;
            for (int i = 5; i <= 8; i++)
            {

                
                    var eliminatoriaB = new EliminatoriaDto
                    {
                        SelecaoA = grupo.First(x => x.Id == contadorGrupo).SelecaoClassificada2,
                        SelecaoB = grupo.First(x => x.Id == contadorGrupo++).SelecaoClassificada1,
                        NumeroJogo = i,
                        Fase = FaseEnum.Oitavas
                    };
                    //add eliminatoria
                    _eliminatoriaService.AddEliminatoria(eliminatoriaB);
                    contadorGrupo++;
                
            }
        }
        private void GerarQuartas(List<EliminatoriaDto> eliminatorias)
        {
            eliminatorias = eliminatorias.Where(x => x.Fase == FaseEnum.Oitavas).ToList();
            var contadorJogo = 1;
            for (int i = 1; i <= 4; i++)
            {
                var eliminatoria = new EliminatoriaDto
                {
                    SelecaoA = eliminatorias.First(x => x.NumeroJogo == contadorJogo).SelecaoVencedora,
                    SelecaoB = eliminatorias.First(x => x.NumeroJogo == contadorJogo++).SelecaoVencedora,
                    NumeroJogo = i,
                    Fase = FaseEnum.Quartas
                };
                _eliminatoriaService.AddEliminatoria(eliminatoria);
                //add eliminatoria
                contadorJogo++;
            }
        }
        private void GerarSemi(List<EliminatoriaDto> eliminatorias)
        {
            eliminatorias.Where(x => x.Fase == FaseEnum.Quartas).ToList();
            var contadorJogo = 1;
            for (int i = 1; i <= 2; i++)
            {
                var eliminatoria = new EliminatoriaDto
                {
                    SelecaoA = eliminatorias.First(x => x.NumeroJogo == contadorJogo).SelecaoVencedora,
                    SelecaoB = eliminatorias.First(x => x.NumeroJogo == contadorJogo++).SelecaoVencedora,
                    NumeroJogo = i,
                    Fase = FaseEnum.Semi
                };
                //add eliminatoria
                _eliminatoriaService.AddEliminatoria(eliminatoria);
                contadorJogo++;
            }
        }
        private void GerarDisputaTerceiroLugar(List<EliminatoriaDto> eliminatorias)
        {
            eliminatorias.Where(x => x.Fase == FaseEnum.Semi).ToList();

                var eliminatoria = new EliminatoriaDto
                {
                    SelecaoA = eliminatorias.First(x => x.NumeroJogo == 1).SelecaoPerdedora,
                    SelecaoB = eliminatorias.First(x => x.NumeroJogo == 2).SelecaoPerdedora,
                    NumeroJogo = 1,
                    Fase = FaseEnum.DisputaTerceiroLugar
                };
                _eliminatoriaService.AddEliminatoria(eliminatoria);

        }
        private void GerarDisputaFinal(List<EliminatoriaDto> eliminatorias)
        {
            eliminatorias.Where(x => x.Fase == FaseEnum.Semi).ToList();
            //add eliminatoria

            var eliminatoriaFinal = new EliminatoriaDto
            {
                SelecaoA = eliminatorias.First(x => x.NumeroJogo == 1).SelecaoVencedora,
                SelecaoB = eliminatorias.First(x => x.NumeroJogo == 2).SelecaoVencedora,
                NumeroJogo = 1,
                Fase = FaseEnum.Final
            };
            _eliminatoriaService.AddEliminatoria(eliminatoriaFinal);
            //add eliminatoria

        }
    }
}