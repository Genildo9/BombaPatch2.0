using AutoMapper;
using bombapatch.Domain;
using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;
using BombaPatch.Persistence;

namespace BombaPatch.Application
{
    public class JogoService : IJogoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IJogoPersist _jogoPersist;
        private readonly IMapper _mapper;

        public JogoService(IGeralPersist geralPersist, IJogoPersist jogoPersist, IMapper mapper)
        {
            _mapper = mapper;
            _jogoPersist = jogoPersist;
            _geralPersist = geralPersist;
        }

        public async Task<JogoDto> AddJogos(JogoDto model)
        {
            try
            {
                var jogo = _mapper.Map<Jogo>(model);
                _geralPersist.Add<Jogo>(jogo);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var jogoretorno = await _jogoPersist.GetJogoByIdAsync(jogo.Id);
                    jogoretorno.Resultado.CalcularResultado();
                    return _mapper.Map<JogoDto>(jogoretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<JogoDto> UpdateJogo(int jogoId, JogoDto model)
        {
            try
            {
                var jogo = await _jogoPersist.GetJogoByIdAsync(jogoId);
                if (jogo == null) return null;

                model.Id = jogo.Id;

                _mapper.Map(model, jogo);

                _geralPersist.Update<Jogo>(jogo);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var jogosretorno = await _jogoPersist.GetJogoByIdAsync(jogo.Id);
                    return _mapper.Map<JogoDto>(jogosretorno);
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
                var jogo = await _jogoPersist.GetJogoByIdAsync(jogoId);
                if (jogo == null) throw new Exception("Jogo para deletar não encontrado");

                _geralPersist.Delete<Jogo>(jogo);
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<JogoDto>> GetAllJogosAsync()
        {
            try
            {
                var jogos = await _jogoPersist.GetAllJogosAsync();
                if (jogos == null) return null;
                foreach (var item in jogos)
                {
                    item.Resultado.CalcularResultado();
                }

                var resultado = _mapper.Map<List<JogoDto>>(jogos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<JogoDto>> GetAllJogosByNomeAsync(string nome)
        {
            try
            {
                var jogo = await _jogoPersist.GetAllJogosByNomeAsync(nome);
                if (jogo == null) return null;

                var resultado = _mapper.Map<List<JogoDto>>(jogo);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JogoDto> GetAllJogoByIdAsync(int jogoId)
        {
            try
            {
                var jogos = await _jogoPersist.GetJogoByIdAsync(jogoId);
                if (jogos == null) return null;

                var resultado = _mapper.Map<JogoDto>(jogos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     
    }
}