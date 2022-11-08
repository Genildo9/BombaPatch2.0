using bombapatch.Domain;
using BombaPatch.Application.Contratos;
using BombaPatch.Persistence;

namespace BombaPatch.Application
{
    public class SelecaoService : ISelecaoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ISelecaoPersist _selecaoPersist;
        public SelecaoService(IGeralPersist geralPersist, ISelecaoPersist selecaoPersist)
        {
            _selecaoPersist = selecaoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Selecao> AddSelecoes(Selecao model)
        {
            try
            {
                _geralPersist.Add<Selecao>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _selecaoPersist.GetAllSelecaoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception (ex.Message);
            }
        }

        public async Task<Selecao> UpdateSelecao(int selecaoId, Selecao model)
        {
            try
            {
                var selecao = await _selecaoPersist.GetAllSelecaoByIdAsync(selecaoId);
                if (selecao == null) return null;

                model.Id =selecao.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _selecaoPersist.GetAllSelecaoByIdAsync(model.Id);
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

         public async Task<Selecao[]> GetAllSelecoesAsync()
        {
            try
            {
                var selecoes = await _selecaoPersist.GetAllSelecoesAsync();
                if (selecoes == null) return null;

                return selecoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Selecao[]> GetAllSelecoesByNomeAsync(string nome)
        {
            try
            {
                var selecoes = await _selecaoPersist.GetAllSelecoesByNomeAsync(nome);
                if (selecoes == null) return null;

                return selecoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Selecao> GetAllSelecaoByIdAsync(int selecaoId)
        {
            try
            {
                var selecoes = await _selecaoPersist.GetAllSelecaoByIdAsync(selecaoId);
                if (selecoes == null) return null;

                return selecoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}