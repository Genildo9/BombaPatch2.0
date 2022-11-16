using AutoMapper;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Persistence;
using BombaPatch.Persistence.Contratos;

namespace BombaPatch.Application
{
    public class PartidaService : IPartidaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPartidaPersist _partidaPersist;
        private readonly IMapper _mapper;

        public PartidaService(IGeralPersist geralPersist, IPartidaPersist partidaPersist, IMapper mapper)
        {
            _mapper = mapper;
            _partidaPersist = partidaPersist;
            _geralPersist = geralPersist;
        }

        public async Task<PartidaDto> AddPartidas(PartidaDto model)
        {
            try
            {
                var partida = _mapper.Map<Partida>(model);
                _geralPersist.Add<Partida>(partida);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var partidaretorno = await _partidaPersist.GetPartidaByIdAsync(partida.Id);
                    return _mapper.Map<PartidaDto>(partidaretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PartidaDto> UpdatePartida(int partidaId, PartidaDto model)
        {
            try
            {
                var partida = await _partidaPersist.GetPartidaByIdAsync(partidaId);
                if (partida == null) return null;

                model.Id = partida.Id;

                _mapper.Map(model, partida);

                _geralPersist.Update<Partida>(partida);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var partidaretorno = await _partidaPersist.GetPartidaByIdAsync(partida.Id);
                    return _mapper.Map<PartidaDto>(partidaretorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePartida(int partidaId) 
        {
            try
            {
                var partida = await _partidaPersist.GetPartidaByIdAsync(partidaId);
                if (partida == null) throw new Exception("Partida para deletar não encontrado");

                _geralPersist.Delete<Partida>(partida);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PartidaDto>> GetAllPartidasAsync()
        {
            try
            {
                var partidas = await _partidaPersist.GetAllPartidasAsync();
                if (partidas == null) return null;

                var resultado = _mapper.Map<List<PartidaDto>>(partidas);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PartidaDto>> GetAllPartidasByNomeAsync(string nome)
        {
            try
            {
                var partida = await _partidaPersist.GetAllPartidasByNomeAsync(nome);
                if (partida == null) return null;

                var resultado = _mapper.Map<List<PartidaDto>>(partida);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartidaDto> GetAllPartidaByIdAsync(int partidaId)
        {
            try
            {
                var partidas = await _partidaPersist.GetPartidaByIdAsync(partidaId);
                if (partidas == null) return null;

                var resultado = _mapper.Map<PartidaDto>(partidas);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}