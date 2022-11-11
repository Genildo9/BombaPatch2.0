using AutoMapper;
using bombapatch.Domain;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Persistence;

namespace BombaPatch.Application
{
    public class GrupoService : IGrupoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IGrupoPersist _grupoPersist;
        private readonly IMapper _mapper;
        public GrupoService(IGeralPersist geralPersist, IGrupoPersist GrupoPersist, IMapper mapper)
        {
            _mapper = mapper;
            _grupoPersist = GrupoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Grupo> AddGrupo(GrupoDto model)
        {
            try
            {
                var grupo = _mapper.Map<Grupo>(model);
                _geralPersist.Add<Grupo>(grupo);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var gruporetorno = await _grupoPersist.GetGrupoByIdAsync(grupo.Id);
                    return _mapper.Map<Grupo>(gruporetorno);//olhar isso
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<GrupoDto> UpdateGrupo(int grupoId, GrupoDto model)
        {
            try
            {
                var grupo = await _grupoPersist.GetGrupoByIdAsync(grupoId);
                if (grupo == null) return null;

                model.Id = grupo.Id;

                _mapper.Map(model, grupo);

                _geralPersist.Update<Grupo>(grupo);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var gruporetorno = await _grupoPersist.GetGrupoByIdAsync(grupo.Id);
                    return _mapper.Map<GrupoDto>(gruporetorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteGrupo(int grupoId) 
        {
            try
            {
                var grupo = await _grupoPersist.GetGrupoByIdAsync(grupoId);
                if (grupo == null) throw new Exception("Grupo não encontrado para deletar");

                _geralPersist.Delete<Grupo>(grupo);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Grupo>> GetAllGrupoAsync()
        {
            try
            {
                var grupos = await _grupoPersist.GetAllGruposAsync();
                if (grupos == null) return null;

                var resultado = _mapper.Map<List<Grupo>>(grupos);//olhar isso

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GrupoDto>> GetAllGruposByNomeAsync(string nome)
        {
            try
            {
                var grupos = await _grupoPersist.GetAllGruposByNomeAsync(nome);
                if (grupos == null) return null;

                var resultado = _mapper.Map<List<GrupoDto>>(grupos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GrupoDto> GetAllGrupoByIdAsync(int grupoId)
        {
            try
            {
                var grupo = await _grupoPersist.GetGrupoByIdAsync(grupoId);
                if (grupo == null) return null;

                var resultado = _mapper.Map<GrupoDto>(grupo);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}