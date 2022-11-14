using AutoMapper;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Persistence;

namespace BombaPatch.Application
{
     public class EliminatoriaService : IEliminatoriaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEliminatoriaPersist _eliminatoriaPersist;
        private readonly IMapper _mapper;
        public EliminatoriaService(IGeralPersist geralPersist, IEliminatoriaPersist eliminatoriaPersist, IMapper mapper)
        {
            _mapper = mapper;
            _eliminatoriaPersist = eliminatoriaPersist;
            _geralPersist = geralPersist;

        }
        public async Task<EliminatoriaDto> AddEliminatoria(EliminatoriaDto model)
        {
            try
            {
                var eliminatoria = _mapper.Map<EliminatoriaDto>(model);
                _geralPersist.Add<EliminatoriaDto>(eliminatoria);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var eliminatoriaretorno = await _eliminatoriaPersist.GetEliminatoriaByIdAsync(eliminatoria.Id);
                    return _mapper.Map<EliminatoriaDto>(eliminatoriaretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EliminatoriaDto> UpdateEliminatoria(int eliminatoriaId, EliminatoriaDto model)
        {
            try
            {
                var eliminatoria = await _eliminatoriaPersist.GetEliminatoriaByIdAsync(eliminatoriaId);
                if (eliminatoria == null) return null;

                model.Id = eliminatoria.Id;

                _mapper.Map(model, eliminatoria);

                _geralPersist.Update<Eliminatoria>(eliminatoria);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var eliminatoriaretorno = await _eliminatoriaPersist.GetEliminatoriaByIdAsync(eliminatoria.Id);
                    return _mapper.Map<EliminatoriaDto>(eliminatoriaretorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEliminatoria(int eliminatoriaId)
        {
            try
            {
                var eliminatoria = await _eliminatoriaPersist.GetEliminatoriaByIdAsync(eliminatoriaId);
                if (eliminatoria == null) throw new Exception("Fase eliminatoria para deletar não encontrada");

                _geralPersist.Delete<Eliminatoria>(eliminatoria);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EliminatoriaDto>> GetEliminatoriaAsync()
        {
            try
            {
                var eliminatoria = await _eliminatoriaPersist.GetAllEliminatoriaAsync();
                if (eliminatoria == null) return null;

                var resultado = _mapper.Map<List<EliminatoriaDto>>(eliminatoria);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EliminatoriaDto>> GetAllEliminatoriaByNomeAsync(string nome)
        {
            try
            {
                var eliminatoria = await _eliminatoriaPersist.GetAllEliminatoriaByNomeAsync(nome);
                if (eliminatoria == null) return null;

                var resultado = _mapper.Map<List<EliminatoriaDto>>(eliminatoria);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EliminatoriaDto> GetAllEliminatoriaByIdAsync(int eliminatoriaId)
        {
            try
            {
                var eliminatoria = await _eliminatoriaPersist.GetEliminatoriaByIdAsync(eliminatoriaId);
                if (eliminatoria == null) return null;

                var resultado = _mapper.Map<EliminatoriaDto>(eliminatoria);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}