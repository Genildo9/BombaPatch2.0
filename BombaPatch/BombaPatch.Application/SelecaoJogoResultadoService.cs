using AutoMapper;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Persistence;
using BombaPatch.Persistence.Contratos;

namespace BombaPatch.Application
{
    public class SelecaoJogoResultadoService : ISelecaoJogoResultadoService
    {
         private readonly IGeralPersist _geralPersist;
        private readonly ISelecaoJogoResultadoPersist _selecaojogoresultadoPersist;
        private readonly IMapper _mapper;

        public SelecaoJogoResultadoService(IGeralPersist geralPersist, ISelecaoJogoResultadoPersist selecaojogoresultadoPersist, IMapper mapper)
        {
            _mapper = mapper;
            _selecaojogoresultadoPersist = selecaojogoresultadoPersist;
            _geralPersist = geralPersist;
        }

        public async Task<SelecaoJogoResultadoDto> AddSelecaoJogoResultado(SelecaoJogoResultadoDto model)
        {
            try
            {
                var selecaojogoresultado = _mapper.Map<SelecaoJogoResultado>(model);
                _geralPersist.Add<SelecaoJogoResultado>(selecaojogoresultado);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var jogoretorno = await _selecaojogoresultadoPersist.GetSelecaoJogoResultadoByIdAsync(selecaojogoresultado.Id);
                    return _mapper.Map<SelecaoJogoResultadoDto>(jogoretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<SelecaoJogoResultadoDto> UpdateSelecaoJogoResultado(int selecaojogoresultadoId, SelecaoJogoResultadoDto model)
        {
            try
            {
                var selecaojogoresultado = await _selecaojogoresultadoPersist.GetSelecaoJogoResultadoByIdAsync(selecaojogoresultadoId);
                if (selecaojogoresultado == null) return null;

                model.Id = selecaojogoresultado.Id;

                _mapper.Map(model, selecaojogoresultado);

                _geralPersist.Update<SelecaoJogoResultado>(selecaojogoresultado);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var jogosretorno = await _selecaojogoresultadoPersist.GetSelecaoJogoResultadoByIdAsync(selecaojogoresultado.Id);
                    return _mapper.Map<SelecaoJogoResultadoDto>(jogosretorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSelecaoJogoResultado(int selecaojogoresultadoId) 
        {
            try
            {
                var selecaojogoresultado = await _selecaojogoresultadoPersist.GetSelecaoJogoResultadoByIdAsync(selecaojogoresultadoId);
                if (selecaojogoresultado == null) throw new Exception("Jogo para deletar não encontrado");

                _geralPersist.Delete<SelecaoJogoResultado>(selecaojogoresultado);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SelecaoJogoResultadoDto>> GetAllSelecaoJogoResultadoAsync()
        {
            try
            {
                var selecaojogoresultado = await _selecaojogoresultadoPersist.GetAllSelecaoJogoResultadoAsync();
                if (selecaojogoresultado == null) return null;

                var resultado = _mapper.Map<List<SelecaoJogoResultadoDto>>(selecaojogoresultado);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SelecaoJogoResultadoDto>> GetAllSelecaoJogoResultadoByNomeAsync(string nome)
        {
            try
            {
                var selecaojogoresultado = await _selecaojogoresultadoPersist.GetAllSelecaoJogoResultadoByNomeAsync(nome);
                if (selecaojogoresultado == null) return null;

                var resultado = _mapper.Map<List<SelecaoJogoResultadoDto>>(selecaojogoresultado);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SelecaoJogoResultadoDto> GetAllSelecaoJogoResultadoByIdAsync(int selecaojogoresultadoId)
        {
            try
            {
                var selecaojogoresultado = await _selecaojogoresultadoPersist.GetSelecaoJogoResultadoByIdAsync(selecaojogoresultadoId);
                if (selecaojogoresultado == null) return null;

                var resultado = _mapper.Map<SelecaoJogoResultadoDto>(selecaojogoresultado);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}