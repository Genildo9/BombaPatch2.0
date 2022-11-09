using AutoMapper;
using bombapatch.Domain;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Persistence;

namespace BombaPatch.Application
{
    public class SelecaoService : ISelecaoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ISelecaoPersist _selecaoPersist;
        private readonly IMapper _mapper;
        public SelecaoService(IGeralPersist geralPersist, ISelecaoPersist selecaoPersist, IMapper mapper)
        {
            _mapper = mapper;
            _selecaoPersist = selecaoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<SelecaoDto> AddSelecoes(SelecaoDto model)
        {
            try
            {
                var selecao = _mapper.Map<Selecao>(model);
                _geralPersist.Add<Selecao>(selecao);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var selecaoretorno = await _selecaoPersist.GetAllSelecaoByIdAsync(selecao.Id);
                    return _mapper.Map<SelecaoDto>(selecaoretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<SelecaoDto> UpdateSelecao(int selecaoId, SelecaoDto model)
        {
            try
            {
                var selecao = await _selecaoPersist.GetAllSelecaoByIdAsync(selecaoId);
                if (selecao == null) return null;

                model.Id = selecao.Id;

                _mapper.Map(model, selecao);

                _geralPersist.Update<Selecao>(selecao);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var selecaoretorno = await _selecaoPersist.GetAllSelecaoByIdAsync(selecao.Id);
                    return _mapper.Map<SelecaoDto>(selecaoretorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSelecao(int selecaoId)
        {
            try
            {
                var selecao = await _selecaoPersist.GetAllSelecaoByIdAsync(selecaoId);
                if (selecao == null) throw new Exception("Seleção para deletar não encontrada");

                _geralPersist.Delete<Selecao>(selecao);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SelecaoDto[]> GetAllSelecoesAsync()
        {
            try
            {
                var selecoes = await _selecaoPersist.GetAllSelecoesAsync();
                if (selecoes == null) return null;

                var resultado = _mapper.Map<SelecaoDto[]>(selecoes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SelecaoDto[]> GetAllSelecoesByNomeAsync(string nome)
        {
            try
            {
                var selecoes = await _selecaoPersist.GetAllSelecoesByNomeAsync(nome);
                if (selecoes == null) return null;

                var resultado = _mapper.Map<SelecaoDto[]>(selecoes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SelecaoDto> GetAllSelecaoByIdAsync(int selecaoId)
        {
            try
            {
                var selecao = await _selecaoPersist.GetAllSelecaoByIdAsync(selecaoId);
                if (selecao == null) return null;

                var resultado = _mapper.Map<SelecaoDto>(selecao);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}