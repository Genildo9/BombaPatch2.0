using AutoMapper;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Persistence;
using BombaPatch.Persistence.Contratos;

namespace BombaPatch.Application
{
    public class GrupoClassificacaoService: IGrupoClassificacaoService
    {
         private readonly IGeralPersist _geralPersist;
        private readonly IGrupoClassificacaoPersist _grupoClassificacaoPersist;
        private readonly IMapper _mapper;
        public GrupoClassificacaoService(IGeralPersist geralPersist, IGrupoClassificacaoPersist GrupoClassificacaoPersist, IMapper mapper)
        {
            _mapper = mapper;
            _grupoClassificacaoPersist = GrupoClassificacaoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<GrupoClassificacao> AddGrupoClassificacao(GrupoClassificacaoDto model)
        {
            try
            {
                var grupoClassificacao = _mapper.Map<GrupoClassificacao>(model);
                _geralPersist.Add<GrupoClassificacao>(grupoClassificacao);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var gruporetorno = await _grupoClassificacaoPersist.GetAllGrupoClassificacaoByIdAsync(grupoClassificacao.Id);
                    return _mapper.Map<GrupoClassificacao>(gruporetorno);//olhar isso
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<GrupoClassificacaoDto> UpdateGrupoClassificacao(int grupoClassificacaoId, GrupoClassificacaoDto model)
        {
            try
            {
                var grupoClassificacao = await _grupoClassificacaoPersist.GetAllGrupoClassificacaoByIdAsync(grupoClassificacaoId);
                if (grupoClassificacao == null) return null;

                model.Id = grupoClassificacao.Id;

                _mapper.Map(model, grupoClassificacao);

                _geralPersist.Update<GrupoClassificacao>(grupoClassificacao);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var gruporetorno = await _grupoClassificacaoPersist.GetAllGrupoClassificacaoByIdAsync(grupoClassificacao.Id);
                    return _mapper.Map<GrupoClassificacaoDto>(gruporetorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteGrupoClassificacao(int grupoClassificacaoId) 
        {
            try
            {
                var grupo = await _grupoClassificacaoPersist.GetAllGrupoClassificacaoByIdAsync(grupoClassificacaoId);
                if (grupo == null) throw new Exception("Grupo não encontrado para deletar");

                _geralPersist.Delete<GrupoClassificacao>(grupo);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GrupoClassificacao>> GetAllGrupoClassificacaoAsync()
        {
            try
            {
                var gruposclassificacao = await _grupoClassificacaoPersist.GetAllGruposClassificacaoAsync();
                if (gruposclassificacao == null) return null;

                var resultado = _mapper.Map<List<GrupoClassificacao>>(gruposclassificacao);//olhar isso

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GrupoClassificacaoDto>> GetAllGruposClassificacaoByNomeAsync(string nome)
        {
            try
            {
                var gruposclassificacao = await _grupoClassificacaoPersist.GetAllGruposClassificacaoByNomeAsync(nome);
                if (gruposclassificacao == null) return null;

                var resultado = _mapper.Map<List<GrupoClassificacaoDto>>(gruposclassificacao);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GrupoClassificacaoDto> GetAllGrupoClassificacaoByIdAsync(int grupoClassificacaoId)
        {
            try
            {
                var grupoClassificacao = await _grupoClassificacaoPersist.GetAllGrupoClassificacaoByIdAsync(grupoClassificacaoId);
                if (grupoClassificacao == null) return null;

                var resultado = _mapper.Map<GrupoClassificacaoDto>(grupoClassificacao);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                }
        }
    }
}