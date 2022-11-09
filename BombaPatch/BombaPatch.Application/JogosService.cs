using AutoMapper;
using bombapatch.Domain;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Persistence;

namespace BombaPatch.Application
{
    public class JogosService : IJogosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IJogosPersist _jogosPersist;
        private readonly IMapper _mapper;

        public JogosService(IGeralPersist geralPersist, IJogosPersist jogosPersist, IMapper mapper)
        {
            _mapper = mapper;
            _jogosPersist = jogosPersist;
            _geralPersist = geralPersist;
        }

        public async Task<JogosDto> AddJogos(JogosDto model)
        {
            try
            {
                var jogo = _mapper.Map<Jogos>(model);
                _geralPersist.Add<Jogos>(jogo);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var jogoretorno = await _jogosPersist.GetAllJogoByIdAsync(jogo.Id);
                    return _mapper.Map<JogosDto>(jogoretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<JogosDto> UpdateJogo(int jogosId, JogosDto model)
        {
            try
            {
                var jogo = await _jogosPersist.GetAllJogoByIdAsync(jogosId);
                if (jogo == null) return null;

                model.Id = jogo.Id;

                _mapper.Map(model, jogo);

                _geralPersist.Update<Jogos>(jogo);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var jogosretorno = await _jogosPersist.GetAllJogoByIdAsync(jogo.Id);
                    return _mapper.Map<JogosDto>(jogosretorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteJogo(int jogoId)
        {
            try
            {
                var jogo = await _jogosPersist.GetAllJogoByIdAsync(jogoId);
                if (jogo == null) throw new Exception("Jogo para deletar não encontrado");

                _geralPersist.Delete<Jogos>(jogo);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JogosDto[]> GetAllJogosAsync()
        {
            try
            {
                var jogo = await _jogosPersist.GetAllJogosAsync();
                if (jogo == null) return null;

                var resultado = _mapper.Map<JogosDto[]>(jogo);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JogosDto[]> GetAllJogosByNomeAsync(string nome)
        {
            try
            {
                var jogo = await _jogosPersist.GetAllJogosByNomeAsync(nome);
                if (jogo == null) return null;

                var resultado = _mapper.Map<JogosDto[]>(jogo);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JogosDto> GetAllJogoByIdAsync(int jogoId)
        {
            try
            {
                var jogos = await _jogosPersist.GetAllJogoByIdAsync(jogoId);
                if (jogos == null) return null;

                var resultado = _mapper.Map<JogosDto>(jogos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     
    }
}